/*
  Merge sort algorithm
  Copyright 2016, Sjors van Gelderen
*/

using System;
using System.Linq;
using System.Collections.Generic;

namespace Program
{    
    class Program
    {
	//Collection to sort
	static int[] collection_0 = {3, 5, 1, 6, 2, 2, 8, 6};
	static int[] collection_1 = {5, 2, 6, 3, 6, 8, 2, 1};
	static int[] collection_2 = {2, 1, 3, 4, 5};
	static int[] collection_3 = {5, 5, 5, 5, 5, 5, 5, 4};
	
        static void Main(string[] _args)
	{
	    if(_args.Length > 0)
	    {
		Console.WriteLine("This program does not accept any arguments!");
	    }

	    Console.WriteLine("Merge sort example - Copyright 2016, Sjors van Gelderen");
	    
	    MergeSort(collection_0);
	    MergeSort(collection_1);
	    MergeSort(collection_2);
	    MergeSort(collection_3);
	}
	
	/*
	  Merge sort algorithm
	  Complexity: O(n log n)
	*/
	static void MergeSort(int[] _collection)
	{
	    Console.WriteLine("Performing merge sort on: " + IntArrayToString(_collection));

	    //Slice array into two halves
	    int[] left  = _collection.Take(_collection.Length / 2).ToArray();
	    int[] right = _collection.Skip(_collection.Length / 2).Take(_collection.Length - _collection.Length / 2).ToArray();
	    
	    //Sort left and right arrays for merge sort
	    Array.Sort(left);
	    Array.Sort(right);

	    Console.WriteLine("Left: " + IntArrayToString(left));
	    Console.WriteLine("Right: " + IntArrayToString(right));
	    
	    //Used to keep track of the currently sorted numbers
	    var sorted = new List<int>();

	    //Indices for stepping through the arrays
	    int left_index  = 0;
	    int right_index = 0;
	    
	    while(left_index < left.Length && right_index < right.Length)
	    {
		if(left[left_index] < right[right_index])
		{
		    Console.WriteLine("{0} < {1}", left[left_index], right[right_index]);
		    sorted.Add(left[left_index]);
		    left_index++;
		}
		else
		{
		    Console.WriteLine("{0} > {1}", left[left_index], right[right_index]);
		    sorted.Add(right[right_index]);
		    right_index++;
		}   
	    }
	    
	    if(left_index == left.Length)
	    {
		sorted.AddRange(right.Skip(right_index).Take(right.Length - right_index));
	    }
	    else
	    {
		sorted.AddRange(left.Skip(left_index).Take(left.Length - left_index));
	    }

	    Console.WriteLine("Result: " + IntArrayToString(sorted.ToArray()) + "!\n");
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
