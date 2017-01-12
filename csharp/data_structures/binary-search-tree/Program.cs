/*
  Binary search tree data structure example
  Copyright 2017, Sjors van Gelderen
*/

using System;
using System.Collections.Generic;

namespace Program
{
    class BST<T> where T : IComparable
    {
	public T Value { get; set; }
	public BST<T> Left { get; set; }
	public BST<T> Right { get; set; }
	
	public BST(T _value)
	{
	    Value = _value;
	}

	/*
	  Key insertion operation
	  Complexity: O(n)
	*/
	public static BST<T> Insert(BST<T> _tree, T _value)
	{
	    // Check if left or right child should be used
	    var comparison = _value.CompareTo(_tree.Value);
	    if(comparison < 0)
	    {
		if(_tree.Left == null)
		{
		    Console.WriteLine("Inserting {0} left of {1}",
				      _value, _tree.Value);
		    _tree.Left = new BST<T>(_value);
		}
		else
		{
		    Console.WriteLine("Moving left of {0}",
				      _tree.Value);
		    _tree.Left = Insert(_tree.Left, _value);
		}
	    }
	    else
	    {
		if(_tree.Right == null)
		{
		    Console.WriteLine("Inserting {0} right of {1}",
				      _value, _tree.Value);
		    _tree.Right = new BST<T>(_value);
		}
		else
		{
		    Console.WriteLine("Moving right of {0}",
				      _tree.Value);
		    _tree.Right = Insert(_tree.Right, _value);
		}
	    }

	    return _tree;
	}
	
	/*
	  Delete operation
	  Complexity: O(n^2) because of the added cost of the successor-locating traversal
	*/
	public static BST<T> Delete(BST<T> _tree, T _value, BST<T> _root)
	{
	    if(_tree == null)
	    {
		Console.WriteLine("Value not found in tree");
	    }
	    else
	    {
		var comparison = _value.CompareTo(_tree.Value);
		if(comparison == 0)
		{
		    if(_tree.Left == null && _tree.Right == null)
		    {
			Console.WriteLine("Removing leaf {0}", _tree.Value);
			_tree = null;
		    }
		    else if(_tree.Left != null && _tree.Right != null)
		    {
			// Locate successor, copy and recursively delete
			var traversal = TraverseInOrder(_root);
			for(int i = 0; i < traversal.Count; i++)
			{
			    if(_tree.Value.CompareTo(traversal[i].Value) == 0)
			    {
				var successor = traversal[i + 1];
				Console.WriteLine("Replacing {0} with successor {1}",
						  _tree.Value, successor.Value);
				_tree.Value = successor.Value;
				Console.WriteLine("Recursively calling delete on {0}",
						  _tree.Right.Value);
				_tree.Right = Delete(_tree.Right, successor.Value, _root);
				break;
			    }
			}
		    }
		    else if(_tree.Left != null)
		    {
			Console.WriteLine("Replacing {0} with right subtree {1}",
					  _tree.Value, _tree.Left.Value);
			_tree = _tree.Left;
		    }
		    else
		    {
			Console.WriteLine("Replacing {0} with right subtree {1}",
					  _tree.Value, _tree.Right.Value);
			_tree = _tree.Right;
		    }
		}
		else if(comparison < 0)
		{
		    Console.WriteLine("Moving left from {0}", _tree.Value);
		    _tree.Left = Delete(_tree.Left, _value, _root);
		}
		else
		{
		    Console.WriteLine("Moving right from {0}", _tree.Value);
		    _tree.Right = Delete(_tree.Right, _value, _root);
		}
	    }

	    return _tree;
	}

	/*
	  Search operation
	  Complexity: O(n)
	*/
	public static bool Search(BST<T> _tree, T _value)
	{
	    if(_tree == null)
	    {
		Console.WriteLine("Value not found in tree");
		return false;
	    }
	    else
	    {
		var comparison = _value.CompareTo(_tree.Value);
		if(comparison == 0)
		{
		    Console.WriteLine("Value {0} found in tree!", _value);
		    return true;
		}
		else if(comparison < 0)
		{
		    Console.WriteLine("Moving left from {0}", _value);
		    return Search(_tree.Left, _value);
		}
		else
		{
		    Console.WriteLine("Moving right from {0}", _value);
		    return Search(_tree.Right, _value);
		}
	    }
	}
	
	/*
	  Complete tree traversals in various orders
	  Complexity: O(n)
	*/
	public static List<BST<T>> TraversePreOrder(BST<T> _tree)
	{
	    var subtrees = new List<BST<T>>();
	    if(_tree != null)
	    {
		subtrees.Add(_tree);
		subtrees.AddRange(TraversePreOrder(_tree.Left));
		subtrees.AddRange(TraversePreOrder(_tree.Right));
	    }
	    return subtrees;
	}
	
	public static List<BST<T>> TraverseInOrder(BST<T> _tree)
	{
	    var subtrees = new List<BST<T>>();
	    if(_tree != null)
	    {
		subtrees.AddRange(TraverseInOrder(_tree.Left));
		subtrees.Add(_tree);
		subtrees.AddRange(TraverseInOrder(_tree.Right));
	    }
	    return subtrees;
	}
	
	public static List<BST<T>> TraversePostOrder(BST<T> _tree)
	{
	    var subtrees = new List<BST<T>>();
	    if(_tree != null)
	    {
		subtrees.AddRange(TraversePostOrder(_tree.Left));
		subtrees.AddRange(TraversePostOrder(_tree.Right));
		subtrees.Add(_tree);
	    }
	    return subtrees;
	}
    }
    
    static class Program
    {
	static string StringFromList<T>(List<T> _collection)
	{
	    string buffer = "[";
	    foreach(var element in _collection)
	    {
		buffer += element.ToString() + ", ";
	    }
	    buffer += "]" + Environment.NewLine;
	    return buffer;
	}

	static string StringFromTree<T>(BST<T> _tree) where T : IComparable
	{
	    var traversals = new Dictionary<string, List<BST<T>>>();
	    traversals.Add("PreOrder", BST<T>.TraversePreOrder(_tree));
	    traversals.Add("InOrder", BST<T>.TraverseInOrder(_tree));
	    traversals.Add("PostOrder", BST<T>.TraversePostOrder(_tree));

	    string buffer = Environment.NewLine;
	    foreach(var traversal in traversals)
	    {
		buffer += traversal.Key + " ";
		foreach(var subtree in traversal.Value)
		{
		    buffer += String.Format("{0}, ", subtree.Value);
		}
		buffer += Environment.NewLine;
	    }
	    return buffer;
	}

	static void Insert<T>(BST<T> _tree, T _which) where T : IComparable
	{
	    Console.WriteLine("Inserting {0}", _which.ToString());
	    BST<T>.Insert(_tree, _which);
	    Console.Write(Environment.NewLine);
	}

	static bool Search<T>(BST<T> _tree, T _which) where T : IComparable
	{
	    Console.WriteLine("Searching for {0}", _which.ToString());
	    return BST<T>.Search(_tree, _which);
	}

	static void Delete<T>(BST<T> _tree, T _which) where T : IComparable
	{
	    Console.WriteLine("Deleting {0}", _which.ToString());
	    _tree = BST<T>.Delete(_tree, _which, _tree);
	    Console.WriteLine(StringFromTree<T>(_tree));
	}
	
	static void Main()
	{
	    Console.WriteLine("Binary search tree data structure example - "
			      + "Copyright 2017, Sjors van Gelderen"
			      + Environment.NewLine);
	    
	    var tree = new BST<int>(10);

	    Console.WriteLine("Insert operations");
	    Insert(tree, 20);
	    Insert(tree, 30);
	    Insert(tree, 5);

	    Console.WriteLine(Environment.NewLine + "Search operations:");
	    Search<int>(tree, 10);
	    Search<int>(tree, 55);
	    Search<int>(tree, 20);
	    
	    Console.WriteLine(Environment.NewLine + "Delete operations:");
	    Delete<int>(tree, 10);
	    Delete<int>(tree, 55);
	    Delete<int>(tree, 30);
	    Delete<int>(tree, 5);
	    Delete<int>(tree, 20);
	}
    }
}
