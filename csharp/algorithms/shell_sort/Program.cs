/*
  Shell sort algorithm example
  Copyright 2016, Sjors van Gelderen
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    class Program
    {
	/*
	  Shell sort algorithm
	  Complexity: O(n log^2 n)
	*/
	static void ShellSort(int[] _collection, int _gap)
	{
	    Console.WriteLine("Performing shell sort on " + IntArrayToString(_collection) + "!");

	    //Split the array into chunks and sort them
	    for(int i = 0; i < _collection.Length; i += _gap)
	    {
		int end = i + _gap > _collection.Length ? _collection.Length : i + _gap;
		InsertionSort(_collection, i, end);
	    }

	    //Finally, sort the full collection
	    InsertionSort(_collection, 0, _collection.Length);
	    
	    Console.WriteLine("Result: {0}", IntArrayToString(_collection));
	}
	
	/*
	  Insertion sort algorithm
	  Complexity: O(n)
	  Used for intermediate steps of shell sort
	*/
	static void InsertionSort(int[] _collection, int _start, int _end)
	{
	    Console.WriteLine("Sorting elements from {0} to {1}", _start, _end);
	    for(int i = _start; i < _end; i++)
	    {
		//Set index variable
		int index = i;
		while(index > 0 && _collection[index] < _collection[index - 1])
		{
		    Console.WriteLine("Swapping " + _collection[index - 1].ToString() +
				      " with " + _collection[index].ToString());
		    
		    //Swap the elements
		    int temp = _collection[index - 1];
		    _collection[index - 1] = _collection[index];
		    _collection[index] = temp;
		    
		    //Decrease the index
		    index--;
		}
	    }

	    Console.WriteLine("Intermediate result: " + IntArrayToString(_collection) + "!" + Environment.NewLine);
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
	
        static void Main(string[] _args)
	{
	    Console.WriteLine("Shell sort algorithm example - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);

	    var random = new Random();
	    
	    for(int i = 0; i < 3; i++)
	    {
		var collection = new int[16];
		for(int o = 0; o < 16; o++)
		{
		    collection[o] = random.Next(100);
		}
		ShellSort(collection, 3);
	    }
	}
    }
}
