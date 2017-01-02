/*
  Adapter design pattern example
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{
    // Domain specific interface
    abstract class IteratorAdapter
    {
	public abstract string GetNext();
    }
    
    // The subject the adapter will be targeting
    class UnsafeIterator
    {
	private int counter = 0;
	private string[] contents = new string[]{ "Tic", "Tac", "Toe" };
        
	public string GetNext()
	{
	    var temp = contents[counter];
	    counter++;
	    return temp;
	}

	public bool HasNext()
	{
	    return counter < contents.Length - 1;
	}

        public void Reset()
	{
	    counter = 0;
	}
    }
    
    // The adapter, which fixes a problem with the subject
    class SafeIterator : IteratorAdapter
    {
	private UnsafeIterator unsafe_iterator = new UnsafeIterator();

	public override string GetNext()
	{
	    if(!unsafe_iterator.HasNext())
	    {
		unsafe_iterator.Reset();
	    }

	    return unsafe_iterator.GetNext();
	}
    }
    
    static class Program
    {
	static void Main()
	{
	    Console.WriteLine("Adapter design pattern example - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);

	    Console.WriteLine("Unsafe iterator demonstration:");
	    var unsafe_iterator = new UnsafeIterator();
	    for(int i = 0; i < 4; i++)
	    {
		try
		{
		    Console.WriteLine(unsafe_iterator.GetNext());
		}
		catch(IndexOutOfRangeException _e)
		{
		    // Will happen because the unsafe iterator only contains 3 items
		    // Actually, the Reset and HasNext method should have been used manually
		    Console.WriteLine("Error: {0}", _e.Message);
		}
	    }

	    Console.WriteLine("Safe iterator demonstration");
	    IteratorAdapter safe_iterator = new SafeIterator();
	    for(int i = 0; i < 4; i++)
	    {
		//Won't trigger an error because the adapter made the iterator safe
		Console.WriteLine(safe_iterator.GetNext());
	    }
	}
    }
}
