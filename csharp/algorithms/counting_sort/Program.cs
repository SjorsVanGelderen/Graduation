/*
  Counting sort algorithm example
  Copyright 2017, Sjors van Gelderen
*/

using System;
using System.Collections.Generic;

namespace Program
{
    static class Program
    {
	// Generate string from elements in the collection
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

	// Find min max range of values in collection
	static void FindBounds<T>(out T _min, out T _max, ref T[] _collection) where T : IComparable
	{
	    _min = _collection[0];
	    _max = _collection[0];
	    
	    for(int i = 1; i < _collection.Length; i++)
	    {
		var comparison = _collection[i].CompareTo(_min);
		if(comparison < 0)
		{
		    _min = _collection[i];
		}
		
		comparison = _collection[i].CompareTo(_max);
		if(comparison > 0)
		{
		    _max = _collection[i];
		}
	    }
	}

	/*
	  Counting sort algorithm
	  Complexity: O(n+k) where k is the number of possible values in the min max range
	  Not generic as min max bounds must be returned as int
	*/
	static void CountingSort(ref int[] _collection)
	{
	    Console.WriteLine("Counting sort on {0}",
			      StringFromCollection(ref _collection));
	    
	    // Get max bound, min bound is ignored
	    int min, max;
	    FindBounds<int>(out min, out max, ref _collection);
	    Console.WriteLine("Max: {0}", max);
	    
	    // Set up buckets to store the counts
	    var buckets = new int[max + 1];
	    
	    // Generate histogram of key frequencies by counting in buckets
	    foreach(var element in _collection)
	    {
		buckets[element]++;
		Console.WriteLine("Bucket {0}: {1}", element, buckets[element]);
	    }

	    // Initialize the sorting index
	    int sorting_index = 0;
	    
	    // Use counts and sorting index to sort the collection
	    for(int i = 0; i < buckets.Length; i++)
	    {
		while(buckets[i] > 0)
		{
		    _collection[sorting_index] = i;
		    sorting_index++;
		    buckets[i]--;
		    Console.WriteLine("Bucket {0}: {1}", i, buckets[i]);
		}
	    }

	    Console.WriteLine("Counting sort result: {0}",
			      StringFromCollection(ref _collection));
	}
	
	static void Main()
	{
	    Console.WriteLine("Counting sort algorithm example - "
			      + "Copyright 2017, Sjors van Gelderen"
			      + Environment.NewLine);

	    var random = new Random();

	    for(int i = 0; i < 3; i++)
	    {
		var collection = new int[16];
		for(int o = 0; o < collection.Length; o++)
		{
		    collection[o] = random.Next(100);
		}
		CountingSort(ref collection);
	    }
	}
    }
}
