/*
  Searching algorithms examples
  Copyright 2016, Sjors van Gelderen
*/

using System;
using System.Collections.Generic;

namespace Program
{
    static class Program
    {
	// Generate a string from all elements in the collection
	static string StringFromCollection<T>(T[] _collection)
	{
	    var buffer = "[ ";
	    foreach(var element in _collection)
	    {
		buffer += element.ToString() + ", ";
	    }
	    buffer += " ] ";
	    return buffer;
	}

	/*
	  Linear search algorithm
	  Complexity: O(n)
	*/
	static int LinearSearch<T>(T _value, T[] _collection)
	{
	    Console.WriteLine("Linear search for {0} in {1}",
			      _value,
			      StringFromCollection(_collection));

	    int iterations = 0;
	    
	    for(int i = 0; i < _collection.Length; i++)
	    {
		if(_collection[i].Equals(_value))
		{
		    Console.WriteLine("Found {0} at {1} after {2} iterations!",
				      _value,
				      i,
				      iterations);
		    return i;
		}
		
		iterations++;
	    }

	    Console.WriteLine("Element {0} was not found in the collection!", _value);
	    return -1;
	}

	/*
	  Binary search algorithm
	  Complexity: O(log n)
	*/
        static int BinarySearch<T>(T _value, T[] _collection) where T : IComparable
	{
	    Console.WriteLine("Binary search for {0} in {1}",
			      _value,
			      StringFromCollection(_collection));

	    var pivot = _collection.Length / 2;
	    var iterations = 0;

	    while(true)
	    {
		Console.WriteLine("Touching index {0}", pivot);

		var old_pivot = pivot;
		var comparison = _collection[pivot].CompareTo(_value);
		
		if(comparison < 0)
		{
		    Console.WriteLine("Moving right");
		    pivot = (_collection.Length - pivot) / 2 + pivot;
		}
		else if(comparison > 0)
		{
		    Console.WriteLine("Moving left");
		    pivot /= 2;
		}
		else
		{
		    Console.WriteLine("Found {0} at {1} after {2} iterations!",
				      _value,
				      pivot,
				      iterations);
		    
		    return pivot;
		}

		if(pivot == old_pivot)
		{
		    Console.WriteLine("Could not find {0}", _value);
		    return -1;
		}

		iterations++;
	    }
	}
	
	static void Main()
	{
	    Console.WriteLine("Searching algorithms examples - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);

	    // Linear search demonstration with integer collection
	    var int_collection = new int[]{ 0, 3, 2, 7, 5, 9 };
	    LinearSearch<int>(4, int_collection);
	    LinearSearch<int>(9, int_collection);

	    // Binary search demonstration with integer collection
	    var sorted_int_collection = new int[]{ 0, 1, 2, 3, 4, 5, 6 };
	    BinarySearch<int>(4, sorted_int_collection);
	    BinarySearch<int>(9, sorted_int_collection);

	    // Linear search demonstration with string collection
	    var string_collection = new string[]{ "sam", "and", "max" };
	    LinearSearch<string>("sam", string_collection);
	    LinearSearch<string>("max", string_collection);
	    LinearSearch<string>("road", string_collection);
	}
    }
}
