/*
  Threading example
  Copyright 2017, Sjors van Gelderen

  Resources used:
  https://msdn.microsoft.com/en-us/library/mt679040.aspx - Thread pool
  https://msdn.microsoft.com/en-us/library/ms228964.aspx - Synchronization mechanisms
  https://msdn.microsoft.com/en-us/library/c5kehkcz.aspx - Exclusive lock
  https://msdn.microsoft.com/en-us/library/system.threading.mutex.aspx - Mutex
  https://msdn.microsoft.com/en-us/library/system.threading.readerwriterlockslim.aspx - ReadWriterLockSlim
  https://msdn.microsoft.com/en-us/library/system.threading.semaphore(v=vs.110).aspx - Semaphore
*/

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Program
{
    // Used by general thread (Fibonacci) demo
    class FibonacciWorker
    {
	public int N { get; } // Which number in the sequence to generate
	public int Result { get; set; } // Result of the algorithm
	
	private ManualResetEvent done; // Flag to set when done
	
	public FibonacciWorker(int _n, ManualResetEvent _done)
	{
	    N = _n;
	    done = _done;
	}

	// Thread pool callback
	public void Callback(Object _threadContext)
	{
	    // Get thread ID
	    int thread_id = (int)_threadContext;
	    Console.WriteLine("Thread {0} started", thread_id);

	    // Run the work
	    Result = Fibonacci(N);

	    // Set done flag
	    Console.WriteLine("Thread {0} finished", thread_id);
	    done.Set();
	}
	
	// Inefficient recursive Fibonacci implementation
	private static int Fibonacci(int _n)
	{
	    return _n < 2 ? _n : Fibonacci(_n - 1) + Fibonacci(_n - 2);
	}
    }

    // Used by exclusive lock demo
    class Hero
    {
	private int health = 100; // The property to be manipulated by the threads
	private Object health_lock = new Object(); // Lock object for health property
	
	public void Damage(int _amount, int _delay)
	{
	    Console.WriteLine("Hero is in contest with {0}!",
			      Thread.CurrentThread.Name);

	    // Sleep an arbitrary amount of time
	    Thread.Sleep(_delay);
	    
	    // Locks the health property so only this thread may manipulate it
	    lock(health_lock)
	    {
		health -= _amount;
		if(health <= 0)
		{
		    health = 0;
		    Console.WriteLine("The hero perished...");
		}
		
		Console.WriteLine("The hero suffers {0} damage!"
				  + Environment.NewLine
				  + "{1} health points remain.",
				  _amount, health);
	    }
	}
    }

    // Used by Mutex demo
    class MutexThread
    {
	// Static mutex means its not owned by any particular instance
	private static Mutex mutex = new Mutex();

	// Dummy work procedure for the thread
	public static void Work()
	{
	    Console.WriteLine("{0} is preparing to use the resource",
			      Thread.CurrentThread.Name);
	    UseResource();
	    Console.WriteLine("{0} is done with its work",
			      Thread.CurrentThread.Name);
	}

	// Safe access to the resource is done through this procedure
	static void UseResource()
	{
	    // Block with WaitOne until mutex is freed
	    Console.WriteLine("{0} is requesting the mutex",
			      Thread.CurrentThread.Name);
	    mutex.WaitOne();

	    // Do some dummy work, here sleep for 1 second
	    Thread.Sleep(1000);
	    Console.WriteLine("{0} is done with the resource",
			      Thread.CurrentThread.Name);

	    // Free the mutex for other threads
	    mutex.ReleaseMutex();
	    Console.WriteLine("{0} has released the mutex",
			      Thread.CurrentThread.Name);
	}
    }

    // Used by ReadWriterLockSlim demo
    class HiscoreTable
    {
	private ReaderWriterLockSlim hiscore_table_lock = new ReaderWriterLockSlim();
	private Dictionary<string, int> hiscore_table = new Dictionary<string, int>();

	// Read a score from the table
	public void Read(string _name)
	{
	    hiscore_table_lock.EnterReadLock();
	    try
	    {
		if(hiscore_table.ContainsKey(_name))
		{
		    Console.WriteLine("{0} read {1}: {2}",
				      Thread.CurrentThread.Name,
				      _name,
				      hiscore_table[_name]);
		}
		else
		{
		    Console.WriteLine("{0} tried to read {1}, "
				      + "but no corresponding entry exists!",
				      Thread.CurrentThread.Name, _name);
		}
	    }
	    finally
	    {
		hiscore_table_lock.ExitReadLock();
	    }
	}

	// Update or add a score to the table
	public void Enter(string _name, int _score)
	{
	    // Lock resource for other threads, open for reading in current thread
	    hiscore_table_lock.EnterUpgradeableReadLock();
	    try
	    {
		if(hiscore_table.ContainsKey(_name))
		{
		    if(hiscore_table[_name] != _score)
		    {
			// Record must be updated
			hiscore_table_lock.EnterWriteLock();
			try
			{
			    hiscore_table[_name] = _score;
			    Console.WriteLine("{0} updated {1}: {2}",
				  Thread.CurrentThread.Name,
				  _name,
				  _score);
			}
			finally
			{
			    hiscore_table_lock.ExitWriteLock();
			}
		    }
		}
		else
		{
		    // New record must be added
		    hiscore_table_lock.EnterWriteLock();
		    try
		    {
			hiscore_table.Add(_name, _score);
			Console.WriteLine("{0} added {1}: {2}",
				  Thread.CurrentThread.Name,
				  _name,
				  _score);
		    }
		    finally
		    {
			hiscore_table_lock.ExitWriteLock();
		    }
		}
	    }
	    finally
	    {
		// Release lock on resource
		hiscore_table_lock.ExitUpgradeableReadLock();
	    }
	}

	// Delete a score from the table
	public void Delete(string _name)
	{
	    hiscore_table_lock.EnterUpgradeableReadLock();
	    try
	    {
		if(hiscore_table.ContainsKey(_name))
		{
		    hiscore_table_lock.EnterWriteLock();
		    try
		    {
			hiscore_table.Remove(_name);
			Console.WriteLine("{0} deleted {1}",
					  Thread.CurrentThread.Name,
					  _name);
		    }
		    finally
		    {
			hiscore_table_lock.ExitWriteLock();
		    }
		}
	    }
	    finally
	    {
		hiscore_table_lock.ExitUpgradeableReadLock();
	    }
	}
    }
    
    class Program
    {
	// Thread names
	private static string[] names = {
	    "Tarquin",
	    "Mercutio",
	    "Falstaff",
	    "Bassanio",
	    "Lucrece",
	    "Collatine",
	    "Timon",
	    "Apemantus",
	    "Douglas",
	    "Edward"
	};
	
	// Demonstrates a basic multithreaded application
	static void GeneralThreadingDemo()
	{
	    Console.WriteLine("General thread demo with Fibonacci sequence");
	    
	    // The amount of Fibonacci numbers to calculate
	    const int PROBLEM_SIZE = 16;

	    // Keep track of all workers calculating the sequence
	    var done_events = new ManualResetEvent[PROBLEM_SIZE];
	    var sequence = new FibonacciWorker[PROBLEM_SIZE];
	    
	    Console.WriteLine("Running {0} tasks", PROBLEM_SIZE);
	    for(int i = 0; i < PROBLEM_SIZE; i++)
	    {
		// Create new done event, set it to false
		done_events[i] = new ManualResetEvent(false);

		// Create a new worker for index i in sequence with this done event
		sequence[i] = new FibonacciWorker(i, done_events[i]);

		// Actually queue the new worker so that it may start when a thread becomes available
		ThreadPool.QueueUserWorkItem(sequence[i].Callback, i);
	    }

	    // Wait for worker threads to finish
	    WaitHandle.WaitAll(done_events);
	    Console.WriteLine("Finished all operations!");

	    // Since all are finished, print the results
	    foreach(var worker in sequence)
	    {
		Console.WriteLine("Fibonacci of {0} is {1}", worker.N, worker.Result);
	    }

	    Console.Write(Environment.NewLine);
	}

	// Demonstrates the use of an exclusive lock
	static void ExclusiveLockDemo()
	{
	    Console.WriteLine("Exclusive lock demo");
	    
	    var random = new Random();

	    // Prepare threads
	    const int NUM_THREADS = 10;
	    var threads = new Thread[NUM_THREADS];
	    var hero = new Hero();
	    
	    for(int i = 0; i < NUM_THREADS; i++)
	    {
		threads[i] = new Thread(new ThreadStart(() => hero.Damage(10, random.Next(1000))));
		threads[i].Name = names[i];
	    }

	    // Start threads
	    foreach(var thread in threads)
	    {
		thread.Start();
	    }

	    // Block until all threads are finished
	    foreach(var thread in threads)
	    {
		thread.Join();
	    }

	    Console.Write(Environment.NewLine);
	}
	
	// Demonstrates the use of a mutex
	static void MutexDemo()
	{
	    Console.WriteLine("Mutex demo");

	    // Create a few worker threads
	    const int NUM_THREADS = 3;
	    var threads = new Thread[NUM_THREADS];
	    
	    for(int i = 0; i < NUM_THREADS; i++)
	    {
		threads[i] = new Thread(new ThreadStart(MutexThread.Work));
		threads[i].Name = String.Format("Thread {0}", i);
	    }

	    // Start the worker threads
	    foreach(var thread in threads)
	    {
		thread.Start();
	    }

	    // Block until all threads are finished
	    foreach(var thread in threads)
	    {
		thread.Join();
	    }
	    
	    Console.Write(Environment.NewLine);
	}

	// ReadWriterLockSlim demo methods
	static void TeslaTest(HiscoreTable _table)
	{
	    _table.Enter("Tesla", 10);
	    _table.Enter("Tesla", 10);
	    _table.Enter("Tesla", 100);
	    _table.Delete("Faraday");
	}
	
	static void EdisonTest(HiscoreTable _table)
	{
	    _table.Enter("Edison", 1000);
	    _table.Delete("Edison");
	    _table.Delete("Tesla");
	}
	
	static void FaradayTest(HiscoreTable _table)
	{
	    _table.Enter("Edison", 100);
	    _table.Enter("Faraday", 23);
	    _table.Enter("Faraday", 100);
	    _table.Enter("Edison", 100);
	}

	delegate void ThreadDelegate();
	
	static void ReadWriterLockSlimDemo()
	{
	    Console.WriteLine("ReadWriterLockSlim demo");

	    var random = new Random();
	    
	    // The data the threads will attempt to manipulate
	    var hiscore_table = new HiscoreTable();
	    
	    // Create a few worker threads
	    const int NUM_THREADS = 10;
	    var threads = new Thread[NUM_THREADS];

	    // Assign random tasks to the threads
	    for(int i = 0; i < NUM_THREADS; i++)
	    {
		ThreadDelegate thread_delegate = () => {};
		switch(random.Next(3))
		{
		    case 0:
			thread_delegate = () => TeslaTest(hiscore_table);
			break;

		    case 1:
			thread_delegate = () => EdisonTest(hiscore_table);
			break;

		    case 2:
			thread_delegate = () => FaradayTest(hiscore_table);
			break;
		}
		threads[i] = new Thread(new ThreadStart(thread_delegate));
		threads[i].Name = String.Format("Thread {0}", i);
	    }
	    
	    // Start the threads
	    for(int i = 0; i < NUM_THREADS; i++)
	    {
		threads[i].Start();
	    }
	    
	    // Block until all threads are finished
	    for(int i = 0; i < NUM_THREADS; i++)
	    {
		threads[i].Join();
	    }

	    Console.Write(Environment.NewLine);
	}

	// Semaphore demo methods
	static void SemaphoreWork(Semaphore _semaphore, int _delay)
	{
	    
	    // Wait for the semaphore's signal
	    Console.WriteLine("{0} is waiting for the semaphore's signal",
			      Thread.CurrentThread.Name);

	    _semaphore.WaitOne();

	    // Simulate work by sleeping a random amount of time
	    Console.WriteLine("{0} enters the protected space",
			      Thread.CurrentThread.Name);
	    Thread.Sleep(_delay);

	    // Tell the semaphore we're done here
	    _semaphore.Release();
	    Console.WriteLine("{0} leaves the protected space",
			      Thread.CurrentThread.Name);
	}
	
	static void SemaphoreDemo()
	{
	    Console.WriteLine("Semaphore demo");
	    
	    var random = new Random();

	    // The semaphore regulates access to the protected space
	    var semaphore = new Semaphore(0, 3);

	    // Wait before granting access
	    Thread.Sleep(500);
	    semaphore.Release(3); // Open the space for 3 worker threads
	    
	    // Create worker threads
	    const int NUM_THREADS = 10;
	    var threads = new Thread[NUM_THREADS];
	    for(int i = 0; i < NUM_THREADS; i++)
	    {
		threads[i] = new Thread(new ThreadStart(() => SemaphoreWork(semaphore, random.Next(1500))));
		threads[i].Name = names[i];
	    }
	    
	    // Start the threads
	    foreach(var thread in threads)
	    {
		thread.Start();
	    }

	    // Block until threads are finished
	    foreach(var thread in threads)
	    {
		thread.Join();
	    }

	    Console.Write(Environment.NewLine);
	}
	
	static void Main()
	{
	    Console.WriteLine("Threading example - "
			      + "Copyright 2017, Sjors van Gelderen"
			      + Environment.NewLine);

	    GeneralThreadingDemo();
	    ExclusiveLockDemo();
	    MutexDemo();
	    ReadWriterLockSlimDemo();
	    SemaphoreDemo();
	}
    }
}
