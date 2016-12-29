/*
  Binary search tree data structure example
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{
    //Binary search tree data structure and functionality
    class BST<T>
    {
	T value;
	BST<T> left;
	BST<T> right;
	
	public BST<T>(T _value)
	{
	    value = _value;
	}
	
	static void Insert(BST<T> _tree, T _value)
	{
	    if(_tree == null)
	    {
		//Insert the value
		_tree = new BST<T>(_value);
	    }
	    else
	    {
		//Keep looking for a place to put the value
		if(_value <= _tree.value)
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
	static bool Delete(BinaryTree<T> _tree, T _value)
	{
	    if(_tree == null)
	    {
		Console.WriteLine("Could not find value {0} in tree!", _value);
		return false;
	    }
	    else //if(_tree.value == _value)
	    {
		return _tree.left == null && _tree.right == null;
	    }
     	}
	*/
	
	static bool Search(BinaryTree<T> _tree, T _value)
	{
	    if(_tree == null)
	    {
		Console.WriteLine("Could not find value {0} in tree!", _value);
		return false;
	    }
	    else if(_tree.value == _value)
	    {
		Console.WriteLine("Found value {0} in tree!", _value);
		return true;
	    }
	    else
	    {
		if(_value <= _tree.value)
		{
		    return Search(_tree.left, _value);
		}
		else
		{
		    return Search(_tree.right, _value);
		}
	    }
	}

	static void TraversePreOrder(BinaryTree<T> _tree)
	{
	    if(_tree != null)
	    {
		Console.Write("{0}, ", _tree.value);
		TraversePreOrder(_tree.left);
		TraversePreOrder(_tree.right);
	    }
	}
	
	static void TraverseInOrder(BinaryTree<T> _tree)
	{
	    if(_tree != null)
	    {
		TraverseInOrder(_tree.left);
		Console.Write("{0}, ", _tree.value);
		TraverseInOrder(_tree.right);
	    }
	}
	
	static void TraversePostOrder(BinaryTree<T> _tree)
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
	public static void Main(string _args)
	{
	    Console.WriteLine("""Binary tree data structure example - 
                                 Copyright 2016, Sjors van Gelderen"""
			      + Environment.NewLine);

	    
	}
    }
}
