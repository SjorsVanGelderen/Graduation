/*
  Quicksort algorithm example
  Copyright 2016, Sjors van Gelderen
*/

using System;
using System.Linq;

namespace Quicksort
{
    public class Program
    {
	/*
	  Quicksort algorithm
	  Complexity: O(n^2)
	*/
	static void Quicksort<T>(T[] _collection, int _start, int _end) where T : IComparable<T>
	{
	    if(_end > _start)
	    {
		int left = _start;
		int right = _end;
		int pivot_index = left;
		
		Console.WriteLine("Pivot: {0} at {1}",
				  _collection[pivot_index],
				  pivot_index);
		
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

		Quicksort(_collection, _start, right);
		Quicksort(_collection, left, _end);
	    }
	}
	
	public static void Main(string[] _args)
	{
	    if(_args.Length > 0)
	    {
		Console.WriteLine("This program does not accept any arguments!"
				  + Environment.NewLine);
	    }

	    Console.WriteLine("Merge sort example - Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);
	    
	    var random = new Random();

	    for(int i = 0; i < 4; i++)
	    {
		var collection = Enumerable.Range(0, random.Next(16))
		    .Select(r => random.Next(100))
		    .ToArray();

		Quicksort(collection, 0, collection.Length);
	    }
	}
    }
}
