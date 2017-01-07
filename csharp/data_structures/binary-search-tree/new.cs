/*
  Binary search tree data structure example
  Copyright 2017, Sjors van Gelderen
*/

using System;

namespace Program
{
    class BST<T> where T : IComparable
    {
	private T Value { get; set; }
	private BST<T> Left { get; set; }
	private BST<T> Right { get; set; }

	public BST<T>(T _value)
	{
	    Value = _value;
	}
	
	public static void Insert(BST<T> _tree, T _value)
	{
	    if(_tree == null)
	    {
		_tree = new BST<T>(_value);
	    }
	    else
	    {
		var subtree = _value.CompareTo(_tree.Value) < 0 ? _tree.Left : _tree.Right;
		if(subtree == null)
		{
		    subtree = new BST<T>(_value);
		}
		else
		{
		    subtree.Insert(_value);
		}
		
		/*
		var comparison = _value.CompareTo(Value);
		if(comparison < 0)
		{
		    if(Left == null)
		    {
			Left = new BST<T>();
			Left.Value = _value;
		    }
		    else
		    {
			Left.Insert(_value);
		    }
		}
		else
		{
		    if(Right == null)
		    {
			Right = new BST<T>();
			Right.Value = _value;
		    }
		    else
		    {
			Right.Insert(_value);
		    }
		}
		*/
	    }
	}
	
	/*
	  Complete tree traversals in various orders
	  Complexity: O(n)
	*/
	public static void TraversePreOrder<T>(BST<T> _tree)
	{
	    if(_tree != null)
	    {
		Console.Write("{0}, ", _tree.Value);
		TraversePreOrder(_tree.Left);
		TraversePreOrder(_tree.Right);
	    }
	}

	/*
	public static void TraverseInOrder(BST<T> _tree)
	{
	    if(_tree != null)
	    {
		TraverseInOrder(_tree.left);
		Console.Write("{0}, ", _tree.value);
		TraverseInOrder(_tree.right);
	    }
	}
	
	public static void TraversePostOrder(BST<T> _tree)
	{
	    if(_tree != null)
	    {
		TraversePostOrder(_tree.left);
		TraversePostOrder(_tree.right);
		Console.Write("{0}, ", _tree.value);
	    }
	}
	*/
    }
    
    static class Program
    {
	static void Main()
	{
	    Console.WriteLine("Binary search tree data structure example - "
			      + "Copyright 2017, Sjors van Gelderen"
			      + Environment.NewLine);

	    var tree = new BST<int>(10);
	    BST.Insert(tree, 20);
	    BST.Insert(tree, 30);
	    
	    TraversePreOrder(tree);
	}
    }
}
