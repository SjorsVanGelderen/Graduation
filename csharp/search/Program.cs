/*
  Linear and binary search algorithms
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{    
    class Program
    {
	//Array in which to search
	static readonly int[] collection = {3, 5, 1, 6, 2, 2, 8, 6};
	
        static void Main(string[] _args)
	{
	    if(_args.Length > 0)
	    {
		Console.WriteLine("This program does not accept any arguments!");
	    }

	    Console.WriteLine("Search algorithms example - Copyright 2016, Sjors van Gelderen");

	    LinearSearch(8, collection);
	    LinearSearch(9, collection);
	    LinearSearch(2, collection);

	    BinarySearch(8, collection);
	    BinarySearch(9, collection);
	    BinarySearch(2, collection);
	}
	
	/*
	  Linear search algorithm
	  Finds the first instance of the target element in a collection
	  Complexity: O(n)
	*/
	static void LinearSearch(int _target, int[] _collection)
	{
	    Console.WriteLine("Linear search for {0} performed on: {1}", _target, IntArrayToString(_collection));
	    
	    for(int i = 0; i < _collection.Length; i++)
	    {
		if(_collection[i] == _target)
		{
		    Console.WriteLine("Found " + _target.ToString() + " at index " + i.ToString() + "!\n");
		    return;
		}

		Console.WriteLine("Touching index " + i.ToString());
	    }

	    Console.WriteLine("The target element is not in the collection!\n");
	}

	/*
	  Binary search algorithm
	  Finds the first instance of the target element in a collection
	  Complexity: O(log n)
	*/
	static void BinarySearch(int _target, int[] _collection)
	{
	    Console.WriteLine("Binary search for {0} performed on: {1}", _target, IntArrayToString(_collection));
	    
	    //Array must be sorted for binary search
	    Array.Sort(_collection);

	    int pivot = _collection.Length / 2;
	    int old_pivot = 0;
	    
	    while(true)
	    {
		old_pivot = pivot;

		if(_collection[pivot] < _target)
		{
		    Console.WriteLine("Touching index: {0}", pivot);
		    pivot = (_collection.Length - pivot) / 2 + pivot;
		}
		else if(_collection[pivot] > _target)
		{
		    Console.WriteLine("Touching index: {0}", pivot);
		    pivot = pivot / 2;
		}
		else
		{
		    Console.WriteLine("Found target at index: {0}!\n", pivot);
		    return;
		}

		if(pivot == old_pivot)
		{
		    Console.WriteLine("The target element is not in the collection!\n");
		    return;
		}
	    }
	}

	//Creates a string representation of an integer array
	static string IntArrayToString(int[] _array)
	{
	    string buffer = "[";
	    
	    for(int i = 0; i < _array.Length; i++)
	    {
		buffer += _array[i].ToString();
		
		if(i < _array.Length - 1)
		{
		    buffer += ", ";
		}
	    }

	    buffer += "]";
	    return buffer;
	}
    }
}
