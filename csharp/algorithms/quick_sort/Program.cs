/*
  Quicksort algorithm example
  Copyright 2016, Sjors van Gelderen
*/

using System;
using System.Linq;

namespace Quicksort
{
    static class Program
    {
	// Generate a string from elements in a collection
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
	  Quicksort algorithm
	  Complexity: O(n^2)
	*/
	static void Quicksort<T>(ref T[] _collection, int _start, int _end) where T : IComparable
	{
	    if(_end > _start)
	    {
		// Set bounds and pivot
		int left = _start;
		int right = _end;
		int pivot_index = left;
		
		Console.WriteLine("Pivot: {0} at {1}",
				  _collection[pivot_index],
				  pivot_index);

		// Conquer
		while(left <= right)
		{
		    while(_collection[left].CompareTo(_collection[pivot_index]) < 0)
		    {
			Console.WriteLine("{0} < {1}, moving right",
					  _collection[left],
					  _collection[pivot_index]);
			left++;
		    }

		    while(_collection[right].CompareTo(_collection[pivot_index]) > 0)
		    {
			Console.WriteLine("{0} > {1}, moving left",
					  _collection[right],
					  _collection[pivot_index]);
			right--;
		    }

		    if(left <= right)
		    {
			// Swap operation
			Console.WriteLine("{0} <-> {1}",
					  _collection[left],
					  _collection[right]);

			T temp = _collection[left];
			_collection[left] = _collection[right];
			_collection[right] = temp;
			left++;
			right--;
		    }
		}

		// Divide
		Quicksort(ref _collection, _start, right);
		Quicksort(ref _collection, left, _end);
	    }
	}
	
        static void Main()
	{
	    Console.WriteLine("Quicksort algorithm example - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);
	    
	    var random = new Random();
	    
	    for(int i = 0; i < 3; i++)
	    {
		var collection = Enumerable.Range(0, random.Next(16))
		    .Select(r => random.Next(100))
		    .ToArray();

		Console.WriteLine("Quicksort on {0}",
				  StringFromCollection(ref collection));
		Quicksort(ref collection, 0, collection.Length - 1);
		Console.WriteLine("Quicksort result: {0}",
				  StringFromCollection(ref collection));
	    }
	}
    }
}
