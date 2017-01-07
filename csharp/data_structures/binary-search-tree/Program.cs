/*
  Binary search tree data structure example
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{
    //Binary search tree data structure and functionality
    class BST<T> where T : IComparable
    {
	T value;
	BST<T> left;
	BST<T> right;

	// Empty BST
	public BST()
	{
	    
	}

	// Populate BST with values from the get-go
	public BST(T[] _collection)
	{
	    foreach(var element in _collection)
	    {
		Insert(this, element);
	    }
	}

	/*
	  Insertion operation
	  Complexity: O(n)
	*/
	static void Insert(BST<T> _tree, T _value)
	{
	    if(_tree == null)
	    {
		//Insert the value
		_tree = new BST<T>();
		_tree.value = _value;
	    }
	    else
	    {
		//Keep looking for a place to put the value
		var comparison = _value.CompareTo(_tree.value);
		if(comparison < 0)
		{
		    Insert(_tree.left, _value);
		}
		else
		{
		    Insert(_tree.right, _value);
		}
	    }
	}

	/*
	  Deletion operation
	  Complexity: O(n)
	*/
	static void Delete(BST<T> _tree, T _value)
	{
	    if(_tree == null)
	    {
		Console.WriteLine("Could not find value {0} in tree!", _value);
	    }
	    else 
	    {
		var comparison = _value.CompareTo(_tree.value);
		if(comparison == 0)
		{
		    if(_tree.left == null && _tree.right == null)
		    {
			// Delete the leaf
			_tree = null;
		    }
		    else
		    {
			if(_tree.left != null)
			{
			    // Replace with left subtree
			    _tree = _tree.left;
			}
			else if(_tree.right != null)
			{
			    // Replace with right subtree
			    _tree = _tree.right;
			}
			else
			{
			    // Replace with in-order successor
			    Console.WriteLine("To-do: Implement delete with in-order successor");
			}
		    }
		}
		else if(comparison < 0)
		{
		    Delete(_tree.left, _value);
		}
		else
		{
		    Delete(_tree.right, _value);
		}
	    }
     	}

	/*
	  Searching operation
	  Complexity: O(n)
	*/
	static bool Search(BST<T> _tree, T _value)
	{
	    if(_tree == null)
	    {
		Console.WriteLine("Could not find value {0} in tree!", _value);
		return false;
	    }
	    else
	    {
		var comparison = _value.CompareTo(_tree.value);
		if(comparison == 0)
		{
		    Console.WriteLine("Found value {0} in tree!", _value);
		    return true;
		}
		else if(comparison < 0)
		{
		    return Search(_tree.left, _value);
		}
		else
		{
		    return Search(_tree.right, _value);
		}
	    }
	}

	/*
	  Complete tree traversals in various orders
	  Complexity: O(n)
	*/
	static void TraversePreOrder(BST<T> _tree)
	{
	    if(_tree != null)
	    {
		Console.Write("{0}, ", _tree.value);
		TraversePreOrder(_tree.left);
		TraversePreOrder(_tree.right);
	    }
	}
	
	static void TraverseInOrder(BST<T> _tree)
	{
	    if(_tree != null)
	    {
		TraverseInOrder(_tree.left);
		Console.Write("{0}, ", _tree.value);
		TraverseInOrder(_tree.right);
	    }
	}
	
	static void TraversePostOrder(BST<T> _tree)
	{
	    if(_tree != null)
	    {
		TraversePostOrder(_tree.left);
		TraversePostOrder(_tree.right);
		Console.Write("{0}, ", _tree.value);
	    }
	}
    }
    
    static class Program
    {
	static void Main()
	{
	    Console.WriteLine("Binary tree data structure example - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);
	    
	    var random = new Random();

	    for(int i = 0; i < 3; i++)
	    {
		var collection = new int[random.Next(16)];
		for(int o = 0; o < 16; i++)
		{
		    collection[o] = random.Next(100);
		}
		
		var tree = new BST<int>(collection);
	    }
	}
    }
}
