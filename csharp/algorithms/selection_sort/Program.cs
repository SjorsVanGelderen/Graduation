/*
  Selection sort algorithm example
  Copyright 2017, Sjors van Gelderen
*/

using System;

namespace Program
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
	  Selection sort algorithm
	  Complexity: O(n^2)
	*/
	static void SelectionSort<T>(ref T[] _collection) where T : IComparable
	{
	    Console.WriteLine("Selection sort on {0}",
			      StringFromCollection(ref _collection));

	    // Setup initial state
	    int l = _collection.Length;
	    int t = 0; // Target index
	    
	    while(l > 0)
	    {
		for(int i = 0; i < l; i++)
		{
		    var comparison = _collection[i].CompareTo(_collection[t]);
		    if(comparison > 0)
		    {
			t = i;
		    }
		}

		// Swap
		T temp = _collection[l - 1];
		_collection[l - 1] = _collection[t];
		_collection[t] = temp;

		// Continue
		l--;
		t = 0;

		// Output intermediate result
		Console.WriteLine(StringFromCollection<T>(ref _collection));
	    }

	    // Output final result
	    Console.WriteLine("Selection sort result: {0}",
			      StringFromCollection<T>(ref _collection));
	}
	
	static void Main()
	{
	    Console.WriteLine("Selection sort algorithm example - "
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
		SelectionSort<int>(ref collection);
	    }
	}
    }
}
