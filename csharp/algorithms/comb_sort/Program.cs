
/*
  Comb sort algorithm example
  Copyright 2017, Sjors van Gelderen
*/

using System;

namespace Program
{
    static class Program
    {
	// Generate string from elements in a collection
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
	  Comb sort algorithm
	  Complexity: O(n^2)
	*/
	static void CombSort<T>(ref T[] _collection) where T : IComparable
	{
	    Console.WriteLine("Comb sort on {0}",
			      StringFromCollection<T>(ref _collection));

	    int gap = _collection.Length; // Initial gap size
	    float shrink = 1.3f; // Shrink factor

	    while(true)
	    {
		gap = (int)((float)gap / shrink);
		Console.WriteLine("Gap shrunk to {0}", gap);
		if(gap <= 1)
		{
		    // Algorithm is finished
		    break;
		}

		int i = 0;
		while(i + gap < _collection.Length)
		{
		    var comparison = _collection[i].CompareTo(_collection[i + gap]);
		    if(comparison > 0)
		    {
			// Swap operation
			Console.WriteLine("{0} <-> {1}",
					  _collection[i],
					  _collection[i + gap]);

			var temp = _collection[i];
			_collection[i] = _collection[i + gap];
			_collection[i + gap] = temp;
		    }

		    i++;
		}
	    }

	    Console.WriteLine("Comb sort result: {0}",
			      StringFromCollection<T>(ref _collection));
	}
	
	static void Main()
	{
	    Console.WriteLine("Comb sort algorithm example - "
			      + "Copyright 2017, Sjors van Gelderen"
			      + Environment.NewLine);

	    var random = new Random();
	    
	    for(int i = 0; i < 3; i++)
	    {
		var collection = new int[16];
		for(int o = 0; o < 16; o++)
		{
		    collection[o] = random.Next(100);
		}
		CombSort<int>(ref collection);
	    }
	}
    }
}
