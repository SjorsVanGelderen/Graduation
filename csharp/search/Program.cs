/*
  Linear and binary search algorithms
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{
    /*
      Binary search tree
      Currently only implemented for integers
    */
    class BST
    {
	public BST Left { get; set; } = null;
	public BST Right { get; set; } = null;
	public BST Parent { get; set; } = null;
	public int Key { get; set; }

	public BST(BST _parent, int _key)
	{
	    Key = _key;
	}

	/*
	  Insert a new node
	  Complexity: O(h) where h = BST height
	*/
	public void Insert(int _value)
	{
	    if(Parent == null)
	    {
		Console.WriteLine("Starting insertion of {0}", _value);
	    }

	    if(_value < Key)
	    {
		if(Left == null)
		{
		    Console.WriteLine("Inserting node with value {0} left of {1}", _value, Key);
		    Left = new BST(this, _value);
		}
		else
		{
		    Console.WriteLine("Moving left from {0}", Key);
		    Left.Insert(_value);
		}
	    }
	    else if(_value > Key)
	    {
		if(Right == null)
		{
		    Console.WriteLine("Inserting node with value {0} left of {1}", _value, Key);
		    Right = new BST(this, _value);
		}
		else
		{
		    Console.WriteLine("Moving right from {0}", Key);
		    Right.Insert(_value);
		}
	    }
	    else
	    {
		Console.WriteLine("Duplicate entry, ignoring insert!");
	    }
	}

	/*
	  Find a value in the tree
	  Complexity: O(h) where h = BST height
	*/
	public void Find(int _value)
	{
	    if(Parent == null)
	    {
		Console.WriteLine("Looking for {0}", _value);

		if(_value < Key)
		{
		    if(Left == null)
		    {
			Console.WriteLine("Could not find value!");
		    }
		    else
		    {
			Console.WriteLine("Moving left from {0}", Key);
			Left.Find(_value);
		    }
		}
		else if(_value > Key)
		{
		    if(Right == null)
		    {
			Console.WriteLine("Could not find value!");
		    }
		    else
		    {
			Console.WriteLine("Moving right from {0}", Key);
			Right.Find(_value);
		    }
		}
		else
		{
		    Console.WriteLine("Found value!");
		}
	    }
	}
    }
    
    class Program
    {
	//Array in which to search
	static readonly int[] collection = {3, 5, 1, 6, 2, 2, 8, 6};
	
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
	
        static void Main(string[] _args)
	{
	    if(_args.Length > 0)
	    {
		Console.WriteLine("This program does not accept any arguments!" + Environment.NewLine);
	    }

	    Console.WriteLine("Search algorithms example - Copyright 2016, Sjors van Gelderen" + Environment.NewLine);

	    LinearSearch(8, collection);
	    LinearSearch(9, collection);
	    LinearSearch(2, collection);

	    BinarySearch(8, collection);
	    BinarySearch(9, collection);
	    BinarySearch(2, collection);

	    var tree = new BST(null, 49);
	    tree.Insert(52);
	    tree.Insert(3);
	    tree.Insert(999);
	    tree.Insert(33);

	    tree.Find(23);
	    tree.Find(55);
	    tree.Find(3);
	    tree.Find(999);
	}
    }
}
