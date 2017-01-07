/*
  Insertion sort algorithm example
  Copyright 2016, Sjors van Gelderen
*/

using System;
using System.Collections.Generic;

namespace Program
{    
    static class Program
    {
	// Generate string from elements in a collection
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
	
	/*
	  Insertion sort algorithm
	  Complexity: O(n^2)
	*/
	static void InsertionSort<T>(ref T[]_collection) where T : IComparable
	{
	    Console.WriteLine("Performing insertion sort on {0}",
			      StringFromCollection(ref _collection));
	    
	    for(int i = 1; i < _collection.Length; i++)
	    {
		//Set index variable
		int index = i;
		while(true)
		{
		    if(index > 0)
		    {
			// Perform comparison
			var comparison = _collection[index].CompareTo(_collection[index - 1]);
			if(comparison < 0)
			{
			    Console.WriteLine("{0} <-> {1}",
					      _collection[index],
					      _collection[index - 1]);
			    
			    //Swap the elements
			    T temp = _collection[index - 1];
			    _collection[index - 1] = _collection[index];
			    _collection[index] = temp;
			    
			    //Decrease the index
			    index--;
			    continue;
			}
		    }

		    break;
		}
	    }

	    Console.WriteLine("Insertion sort result: {0}",
			      StringFromCollection(ref _collection));
	}
	
        static void Main()
	{
	    Console.WriteLine("Insertion sort algorithm example - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);

	    var random = new Random();
	    
	    for(int i = 0; i < 3; i++)
	    {
		var collection = new int[16];
		for(int o = 0; o < collection.Length; o++)
		{
		    collection[o] = random.Next(100);
		}
		InsertionSort<int>(ref collection);
	    }
	}
    }
}
