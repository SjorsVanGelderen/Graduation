/*
  Insertion sort algorithm
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{    
    class Program
    {
	//Array in which to search
	static int[] collection = {3, 5, 1, 6, 2, 2, 8, 6};
	
        static void Main(string[] _args)
	{
	    if(_args.Length > 0)
	    {
		Console.WriteLine("This program does not accept any arguments!");
	    }

	    Console.WriteLine("Insertion sort example - Copyright 2016, Sjors van Gelderen");

	    InsertionSort(collection);
	}
	
	/*
	  Insertion sort algorithm
	  Complexity: O(n)
	*/
	static void InsertionSort(int[] _collection)
	{
	    Console.WriteLine("Performing insertion sort on " + IntArrayToString(_collection) + "!");
	    
	    for(int i = 1; i < _collection.Length; i++)
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

	    Console.WriteLine("Result: " + IntArrayToString(_collection) + "!\n");
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
