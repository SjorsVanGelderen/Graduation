/*
  Queue data structure example
  Copyright 2016, Sjors van Gelderen
*/

using System;
using System.Collections.Generic;

namespace Program
{
    /*
      Describes a queue and associated functionality
      The queue is a FIFO data structure
    */
    class Queue<T>
    {
	List<T> contents = new List<T>(); // Elements stored in the queue
	
	// Add an element to the queue
	public void Enqueue(T _value)
	{
	    Console.WriteLine("Enqueueing {0}", _value);
	    
	    contents.Add(_value);
	}
	
	// Remove an element from the queue
	public T Dequeue()
	{
	    if(contents.Count == 0)
	    {
		throw new InvalidOperationException();
	    }
	    
	    var item = contents[0];
	    Console.WriteLine("Dequeueing {0}", item);
	    contents.RemoveAt(0);
	    return item;
	}
	
	// Check whether the queue is empty
	public bool IsEmpty()
	{
	    return contents.Count == 0;
	}
    }
    
    static class Program
    {
	static void Main()
	{
	    Console.WriteLine("Queue data structure example - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine
			      + Environment.NewLine);

	    // Create a queue and populate it
	    var queue = new Queue<string>();
	    queue.Enqueue("Get up from seat");
	    queue.Enqueue("Put on coat and shoes");
	    queue.Enqueue("Go to store");
	    queue.Enqueue("Buy milk");
	    queue.Enqueue("Go back home");
	    queue.Enqueue("Put milk in refridgerator");
	    queue.Enqueue("Celebrate");
	    
	    // Perform all tasks in the queue
	    while(!queue.IsEmpty())
	    {
		try
		{
		    queue.Dequeue();
		}
		catch(InvalidOperationException _e)
		{
		    Console.WriteLine("Failed to dequeue! Message: {0}", _e.Message);
		}
	    }
	}
    }   
}
