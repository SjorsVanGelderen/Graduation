/*
  Binary heap data structure example
  Copyright 2017, Sjors van Gelderen

  Resources used:
  https://en.wikipedia.org/wiki/Binary_heap - Binary heap data structure
  https://www.cs.cmu.edu/~adamchik/15-121/lectures/Binary%20Heaps/heaps.html - Array implementation of binary heap
*/

using System;
using System.Collections.Generic;

namespace Program
{
    static class Constants
    {
	// Heap properties
	public const bool MIN = false;
	public const bool MAX = true;
    }

    // Binary heap data structure
    class Heap<T> where T : IComparable
    {
	private List<T> keys = new List<T>();
	private bool property;

	public Heap(bool _property)
	{
	    property = _property;
	}

	/*
	  Swap operation
	  Complexity: O(1)
	*/
	void Swap(int _left, int _right)
	{
	    if(_left >= 0 && _right < keys.Count)
	    {
		string swap_message = (property == Constants.MIN) ? "{0,2} <-> {1,2}" : "{0,3} <-> {1,3}";
		Console.WriteLine(swap_message, keys[_left], keys[_right]);
		T temp = keys[_left];
		keys[_left] = keys[_right];
		keys[_right] = temp;
	    }
	    else
	    {
		Console.WriteLine("Left or right index is out of bounds!");
	    }
	}
	
	/*
	  Insert operation
	  Complexity: O(log n)
	*/
	public void Insert(T _value)
	{
	    Console.WriteLine("Inserting {0}", _value);
	    
	    // Add the key
	    keys.Add(_value);
	    int key_index = keys.Count - 1;
	    
	    // Swim through the heap to enforce property
	    while(true)
	    {
		if(key_index == 0)
		{
		    // This node cannot have parents
		    Console.WriteLine("Root node, no swimming to be done");
		    break;
		}

		// Query parent
		int parent_index = ((key_index + 1) / 2 - 1);
		T parent = keys[parent_index];
	        
		// Verify if property holds
		var comparison = _value.CompareTo(parent);
		bool holds = (property == Constants.MIN) ? (comparison <= 0) : (comparison >= 0);
		
		if(holds)
		{
		    Console.WriteLine("Before swap: {0}", this);
		    Swap(key_index, parent_index);
		    Console.WriteLine("After swap: {0}", this);
		    key_index = parent_index; // Continue swimming on the new position
		}
		else
		{
		    string message = (property == Constants.MIN) ? "{0} >= {1}" : "{0} <= {1}";
		    Console.WriteLine("Property holds: " + message, _value, parent);
		    // Done swimming, the property now holds
		    break;
		}
	    }
	    
	    Console.WriteLine("Finished adding {0}", _value);
	}

	/*
	  Extract operation
	  Complexity: O(log n)
	*/
	public void Extract()
	{
	    if(keys.Count == 1)
	    {
		Console.WriteLine("Extracting {0}", keys[0]);
		keys.Clear();
	    }
	    else if(keys.Count > 1)
	    {
		// Replace root with last key
		Console.WriteLine("Extracting {0}", keys[0]);
		keys[0] = keys[keys.Count - 1];
		keys.RemoveAt(keys.Count - 1);
		Console.WriteLine("New root: {0}", keys[0]);
		
		// Restore heap property
		Heapify();
	    }
	    else
	    {
		Console.WriteLine("Nothing to extract");
	    }
	}

	/*
	  Heapify operation tailored to work after extractionn
	  Complexity: O(log n)
	*/
	public void Heapify()
	{
	    Console.WriteLine("Restoring heap property");
	    int key_index = 0;
	    
	    while(true)
	    {
		int left_child_index = (key_index + 1) * 2 - 1;
		int right_child_index = (key_index + 1) * 2;
		int child_index = -1;
		
		if(left_child_index < keys.Count)
		{
		    child_index = left_child_index;
		    Console.WriteLine("Child index: {0}", child_index);
		    if(right_child_index < keys.Count)
		    {
			T left_child = keys[left_child_index];
			T right_child = keys[right_child_index];
			
			if(property == Constants.MIN)
			{
			    // Target child will be the smaller one
			    if(left_child.CompareTo(right_child) > 0)
			    {
				child_index = right_child_index;
				Console.WriteLine("Child index updated: {0}", child_index);
			    }
			}
			else
			{
			    // Target child will be the larger one
			    if(left_child.CompareTo(right_child) <= 0)
			    {
				child_index = right_child_index;
				Console.WriteLine("Child index updated: {0}", child_index);
			    }
			}
		    }
		    
		    T key = keys[key_index];
		    T child_key = keys[child_index];
		    
		    bool swap;
		    if(property == Constants.MIN)
		    {
			swap = key.CompareTo(child_key) > 0;
		    }
		    else
		    {
			swap = key.CompareTo(child_key) < 0;
		    }
		    
		    if(swap)
		    {
			// Swap elements to further restore the property
			Swap(key_index, child_index);
			
			// Set key index for next iteration
			key_index = child_index;
		    }
		    else
		    {
			// Property holds
			Console.WriteLine("Property holds, no swap necessary");
			break;
		    }
		}
		else
		{
		    Console.WriteLine("No further children");
		    break;
		}
	    }
	    
	    Console.WriteLine("Finished extraction!");
	}

	// Print heap keys
	public override string ToString()
	{
	    string buffer = property == Constants.MIN ? "Min-heap keys: " : "Max heap keys: ";
	    foreach(T key in keys)
	    {
		buffer += String.Format("{0}, ", key);
	    }
	    return buffer;
	}
    }
    
    static class Program
    {
	static void Main()
	{
	    Console.WriteLine("Binary heap data structure example - "
			      + "Copyright 2017, Sjors van Gelderen"
			      + Environment.NewLine);

	    var random = new Random();

	    Console.WriteLine("Building min-heap:");
	    var min_heap = new Heap<int>(Constants.MIN);
	    for(int i = 0; i < 8; i++)
	    {
		min_heap.Insert(random.Next(100));
	    }
	    Console.WriteLine(min_heap.ToString() + Environment.NewLine);

	    Console.WriteLine("Extracting values from min-heap:");
	    min_heap.Extract();
	    min_heap.Extract();
	    Console.WriteLine(Environment.NewLine + "Result: {0}", min_heap);

	    Console.WriteLine("Building max-heap:");
	    var max_heap = new Heap<int>(Constants.MAX);
	    for(int i = 0; i < 8; i++)
	    {
		max_heap.Insert(random.Next(100));
	    }
	    Console.WriteLine(max_heap.ToString() + Environment.NewLine);

	    Console.WriteLine("Extracting values from max-heap:");
	    max_heap.Extract();
	    max_heap.Extract();
	    Console.WriteLine(Environment.NewLine + "Result: {0}", max_heap);
	}
    }
}
