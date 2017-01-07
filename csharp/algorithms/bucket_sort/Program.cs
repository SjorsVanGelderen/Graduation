/*
  Bucket sort algorithm example
  Copyright 2017, Sjors van Gelderen
*/

using System;
using System.Collections.Generic;

namespace Program
{
    static class Program
    {
	// Generate a string for printing a collection
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
	  Finds min and max bounds of values in a collection
	  Complexity: O(n)
	*/
	static void FindBounds<T>(out T _min, out T _max, T[] _collection) where T : IComparable
	{
	    _min = _collection[0];
	    _max = _collection[0];
	    
	    for(int i = 1; i < _collection.Length; i++)
	    {
		var element = _collection[i];
		var compare = element.CompareTo(_min);
		if(compare < 0)
		{
		    _min = element;
		}
		
		compare = element.CompareTo(_max);
		if(compare > 0)
		{
		    _max = element;
		}
	    }
	}
	
	/*
	  Insertion sort algorithm
	  Complexity: O(n^2)
	  Used as intermediate in bucket sort
	*/
	static T[] InsertionSort<T>(T[] _collection) where T : IComparable
	{
	    Console.WriteLine("Insertion sort on: {0}",
			      StringFromCollection(ref _collection));
	    
	    for(int i = 1; i < _collection.Length; i++)
	    {
		int iter_index = i;
		T current = _collection[i];
		while(true)
		{
		    if(iter_index > 0)
		    {
			T swap_candidate = _collection[iter_index - 1];
			var comparison = current.CompareTo(swap_candidate);
			if(comparison < 0)
			{
			    // Console.WriteLine("{0} < {1}", current, swap_candidate);
			    _collection[iter_index - 1] = current;
			    _collection[iter_index] = swap_candidate;
			    iter_index--;
			    continue;
			}
		    }
		    
		    break;
		}
	    }

	    Console.WriteLine("Insertion sort result: {0}",
			      StringFromCollection(ref _collection));

	    return _collection;
	}

	/*
	  Bucket sort algorithm
	  Complexity: O(n^2)
	  Unfortunately subtraction on generics is not currently supported, hence the type int[]
	  Implementing an arithmetic interface for generics is outside of the scope of this example
	*/
	static int[] BucketSort(ref int[] _collection, int _bucket_size)
	{
	    // Calculate collection value bounds
	    int min, max;
	    FindBounds(out min, out max, _collection);
	    
	    Console.WriteLine("Min: {0}, Max: {1}", min, max);
	    
	    // List of empty 'buckets'
	    var buckets = new List<int>[(max - min) / _bucket_size + 1];
	    for(int i = 0; i < buckets.Length; i++)
	    {
		buckets[i] = new List<int>();
	    }
	    
	    // Distribute values in collection among buckets
	    foreach(var element in _collection)
	    {
		int bucket_index = (element - min) / _bucket_size;
		buckets[bucket_index].Add(element);
		Console.WriteLine("Appended {0} to bucket {1}",
				  element, bucket_index);
	    }

	    // Sort each bucket
	    var sorted_list = new List<int>();
	    for(int i = 0; i < buckets.Length; i++)
	    {
		var sorted_bucket = InsertionSort<int>(buckets[i].ToArray());
		foreach(var element in sorted_bucket)
		{
		    sorted_list.Add(element);
		}
	    }
	    
	    return sorted_list.ToArray();
	}
	
	static void Main()
	{
	    Console.WriteLine("Bucket sort algorithm example - "
			      + "Copyright 2017, Sjors van Gelderen"
			      + Environment.NewLine);

	    var random = new Random();
	    
	    for(int i = 0; i < 3; i++)
	    {
		// Generate a random collection
		var collection = new int[16];
		for(int o = 0; o < collection.Length; o++)
		{
		    collection[o] = random.Next(100);
		}

		// Execute bucket sort on the collection
		var result_collection = BucketSort(ref collection, 5);

		// Print the result
		var result_string = StringFromCollection(ref result_collection);
		Console.WriteLine("Result: {0}", result_string);
	    }
	}
    }
}
