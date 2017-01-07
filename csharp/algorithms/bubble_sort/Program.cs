/*
  Bubble sort algorithm example
  Copyright 2017, Sjors van Gelderen
*/

using System;
using System.Collections.Generic;

namespace Program
{
    static class Program
    {
	static string StringFromCollection<T>(ref T[] _collection)
	{
	    string buffer = "[";
	    foreach(var element in _collection)
	    {
		buffer += element.ToString();
		buffer += ", ";
	    }
	    buffer += "]";
	    return buffer;
	}
    
	static void BubbleSort<T>(ref T[] _collection) where T : IComparable
	{
	    var c = _collection; // Alias
	    
	    Console.WriteLine("Bubble sort on {0}",
			      StringFromCollection(ref c));
	    
	    for(int i = 0; i < c.Length; i++)
	    {
		for(int o = c.Length - 1; o > i; o--)
		{
		    var comparison = c[o].CompareTo(c[o - 1]);
		    if(comparison < 0)
		    {
			// Swap operation
			Console.WriteLine("{0} <-> {1}", c[o], c[o - 1]);
			var temp = c[o - 1];
			c[o - 1] = c[o];
			c[o] = temp;
		    }
		}
	    }
	    
	    Console.WriteLine("Bubble sort result: {0}",
			      StringFromCollection(ref c));
	}

	static void Main()
	{
	    Console.WriteLine("Bubble sort algorithm example - "
			      + "Copyright 2017, Sjors van Gelderen"
			      + Environment.NewLine);
	    
	    var random = new Random();
	    
	    for(int i = 0; i < 3; i++)
	    {
		var collection = new int[16];
		for(int o = 0; o < 16; o++)
		{
		    collection[o] = random.Next(100);
		}
		BubbleSort<int>(ref collection);
	    }
	}
    }
}
