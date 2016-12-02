/*
  Threads example
  Copyright 2016, Sjors van Gelderen
*/

using System;
using System.Threading;

namespace Threads
{
    public class Program
    {
	class ThreadController()
	{
	    private List<Thread> threads = new List<Thread>();
	    
	    public void AddThread();
	}

	static void Print(string _what_to_print)
	{
	    for(int cycle = 0; cycle < 1000; cycle++)
	    {
		Console.Write(_what_to_print);
	    }
	}
	
	public static void Main()
	{
	    Console.WriteLine("Threads example - Copyright 2016, Sjors van Gelderen" + Environment.NewLine);

	    
	}
    }
}
