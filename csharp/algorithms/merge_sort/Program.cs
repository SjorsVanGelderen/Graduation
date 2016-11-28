/*
  Merge sort algorithm
  Copyright 2016, Sjors van Gelderen
*/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace Program
{    
    class Program
    {
	//Collection to sort
	static List<int[]> collections = new List<int[]>();
	
	/*
	  Merge sort algorithm
	  Complexity: O(n log n)
	*/
	static void MergeSort(int[] _collection, int _left,  int _right)
	{
	    if(_right > _left)
	    {
		int middle = (_left + _right) / 2;
	        
		//Divide the current subproblem into two lesser subproblems
		MergeSort(_collection, _left, middle);
		MergeSort(_collection, middle + 1, _right);

		Merge(_collection, _left, middle + 1, _right);
	    }
	}

	static void Merge(int[] _collection, int _left, int _middle, int _right)
	{
	    var result = new int[_right - _left + 1];
	    int result_index = 0;
	    int left_index = _left;
	    int right_index = _middle;
	    
	    //Combine the arrays
	    while(left_index <= _middle - 1 && right_index <= _right)
	    {
		Console.WriteLine("Comparing {0} and {1}", _collection[left_index], _collection[right_index]);
		
		if(_collection[left_index] <= _collection[right_index])
		{
		    Console.WriteLine("{0} <= {1}", _collection[left_index], _collection[right_index]);
		    result[result_index] = _collection[left_index];
		    left_index++;
		}
		else
		{
		    Console.WriteLine("{0} >= {1}", _collection[left_index], _collection[right_index]);
		    result[result_index] = _collection[right_index];
		    right_index++;
		}
		
		result_index++;
	    }
	    
	    //Append the remaining elements
	    while(left_index <= _middle - 1)  //Just reverse this
	    {
		Console.WriteLine("Pushing remaining element from left: {0}", _collection[left_index]);
		result[result_index] = _collection[left_index];
		left_index++;
		result_index++;
	    }
	    
	    while(right_index <= _right) //And this please
	    {
		Console.WriteLine("Pushing remaining element from right: {0}", _collection[right_index]);
		result[result_index] = _collection[right_index];
		right_index++;
		result_index++;
	    }

	    Console.WriteLine("Intermediate result: {0}", IntArrayToString(result));
	    
	    //Introduce the results into the original array
	    for(int i = 0; i < result.Length; i++)
	    {
		_collection[_left + i] = result[i];
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
	
        static void Main(string[] _args)
	{
	    if(_args.Length > 0)
	    {
		Console.WriteLine("This program does not accept any arguments!" + Environment.NewLine);
	    }

	    Console.WriteLine("Merge sort example - Copyright 2016, Sjors van Gelderen" + Environment.NewLine);

	    collections.Add(new int[]{ 3, 5, 1, 6, 2, 2, 8, 6 });
	    collections.Add(new int[]{ 5, 2, 6, 3, 6, 8, 2, 1 });
	    collections.Add(new int[]{ 2, 1, 3, 4, 5 });
	    collections.Add(new int[]{ 5, 5, 5, 5, 5, 5, 5, 4 });
	    
	    foreach(var collection in collections)
	    {
		Console.WriteLine(Environment.NewLine + "Performing merge sort on: {0}", IntArrayToString(collection));
		MergeSort(collection, 0, collection.Length - 1);
		Console.WriteLine("Result: {0}", IntArrayToString(collection));
	    }
	}
    }
}
