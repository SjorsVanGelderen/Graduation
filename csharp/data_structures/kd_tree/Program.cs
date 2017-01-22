/*
  K-dimensional tree data structure example
  Copyright 2016, Sjors van Gelderen

  Resources used:
  https://www.youtube.com/watch?v=uf1ky464340 - K-dimensional tree
*/

using System;
using System.Collections.Generic;

namespace Program
{
    // Describes a location
    class Vector2<T> where T : IComparable
    {
	public T X { get; set; }
	public T Y { get; set; }
	
	public Vector2(T _x, T _y)
	{
	    X = _x;
	    Y = _y;
	}

	public override string ToString()
	{
	    return String.Format("Vector2({0}, {1})", X, Y);
	}
    }
    
    // Describes a rectangular area
    class Rectangle<T> where T : IComparable
    {
	public Vector2<T> TopLeft     { get; set; }
	public Vector2<T> BottomRight { get; set; }

	public Rectangle(Vector2<T> _top_left, Vector2<T> _bottom_right)
	{
	    TopLeft = _top_left;
	    BottomRight = _bottom_right;
	}

	// Check if a given point is inside of this rectangle
	public bool Contains(Vector2<T> _point)
	{
	    var contains =
		_point.X.CompareTo(TopLeft.X)     >= 0 &&
		_point.X.CompareTo(BottomRight.X) <= 0 &&
		_point.Y.CompareTo(TopLeft.Y)     >= 0 &&
		_point.Y.CompareTo(BottomRight.Y) <= 0;

	    if(contains)
	    {
		Console.WriteLine("{0} is inside of {1}",
				  _point, this);
	    }
	    else
	    {
		Console.WriteLine("{0} is outside of {1}",
				  _point, this);
	    }
	    
	    return contains;
	}

	public override string ToString()
	{
	    return String.Format("Rectangle({0}, {1})", TopLeft, BottomRight);
	}
    }
    
    // Describes a 2D implementation of a K-dimensional tree
    class Tree<T> where T : IComparable
    {
	public Vector2<T> Value { get; set; }
	public Tree<T> Left  { get; set; }
	public Tree<T> Right { get; set; }

	public Tree(Vector2<T> _value)
	{
	    Value = _value;
	}
	
	/*
	  Insert operation
	  Complexity: O(n)
	*/
	public static Tree<T> Insert(Tree<T> _tree, Vector2<T> _value, bool _vertical = true)
	{
	    if(_tree == null)
	    {
		// Insert value here
		Console.WriteLine("Inserting {0}", _value);
		_tree = new Tree<T>(_value);
	    }
	    else
	    {
		// Recursively call insert operation on left or right child
		if(_vertical ? _value.X.CompareTo(_tree.Value.X) < 0 : _value.Y.CompareTo(_tree.Value.Y) < 0)
		{
		    Console.WriteLine("Moving left of {0}", _tree.Value);
		    _tree.Left = Insert(_tree.Left, _value, !_vertical);
		}
		else
		{
		    Console.WriteLine("Moving right of {0}", _tree.Value);
		    _tree.Right = Insert(_tree.Right, _value, !_vertical);
		}
	    }
	    
	    return _tree;
	}

	/*
	  Search operation
	  Complexity: O(n)
	*/
	public static bool Search(Tree<T> _tree, Vector2<T> _value, bool _vertical = true)
	{
	    if(_tree == null)
	    {
		//Value was not found
		Console.WriteLine("Value {0} was not found in the tree...", _value);
		return false;
	    }
	    else if(_tree.Value == _value)
	    {
		//Value was found
		Console.WriteLine("Found value {0} in the tree!", _value);
		return true;
	    }
	    else
	    {
		// Recursively call search operation on left or right child depending on orientation
		bool left = _vertical ? _value.X.CompareTo(_tree.Value.X) < 0 : _value.Y.CompareTo(_tree.Value.Y) < 0;
		var target = left ? _tree.Left : _tree.Right;

		if(left)
		{
		    Console.WriteLine("Moving left");
		}
		else
		{
		    Console.WriteLine("Moving right");
		}
		
		return Search(target, _value, !_vertical);
	    }
	}
	
	// Range-based search on the K-dimensional tree
	public static List<Vector2<T>> RangeSearch(Tree<T> _tree, Rectangle<T> _area, bool _vertical = true)
	{
	    var list = new List<Vector2<T>>();
	    
	    if(_tree == null)
	    {
		Console.WriteLine("Reached a leaf");
	    }
	    else
	    {
		if(_area.Contains(_tree.Value))
		{
		    //Value in range, add it to the list
		    Console.WriteLine("{0} is in {1}", _tree.Value, _area);
		    list.Add(_tree.Value);
		}
		
		if(_vertical)
		{
		    if(_area.TopLeft.X.CompareTo(_tree.Value.X) < 0)
		    {
			// Range extends to left subtree, so recursively search on that
			Console.WriteLine("Moving left of {0}", _tree.Value);
			list.AddRange(RangeSearch(_tree.Left, _area, !_vertical));
		    }

		    if(_area.BottomRight.X.CompareTo(_tree.Value.X) > 0)
		    {
			// Range extends to right subtree, so recursively search on that
			Console.WriteLine("Moving right of {0}", _tree.Value);
			list.AddRange(RangeSearch(_tree.Right, _area, !_vertical));
		    }
		}
		else
		{
		    if(_area.TopLeft.Y.CompareTo(_tree.Value.Y) < 0)
		    {
			// Range extends to left subtree, so recursively search on that
			Console.WriteLine("Moving left of {0}", _tree.Value);
			list.AddRange(RangeSearch(_tree.Left, _area, !_vertical));
		    }

		    if(_area.BottomRight.Y.CompareTo(_tree.Value.Y) > 0)
		    {
			// Range extends to right subtree, so recursively search on that
			Console.WriteLine("Moving right of {0}", _tree.Value);
			list.AddRange(RangeSearch(_tree.Right, _area, !_vertical));
		    }
		}
	    }
	    
	    return list;
	}
    }
    
    static class Program
    {
	static Tree<T> Insert<T>(Tree<T> _tree, Vector2<T> _value) where T : IComparable
	{
	    Console.WriteLine("Insertion operation for {0}", _value);
	    _tree = Tree<T>.Insert(_tree, _value);
	    Console.Write(Environment.NewLine);
	    return _tree;
	}

	static void Search<T>(Tree<T> _tree, Vector2<T> _value) where T : IComparable
	{
	    Console.WriteLine("Search operation for {0}", _value);
	    if(Tree<T>.Search(_tree, _value))
	    {
		Console.WriteLine("Search operation succesful!");
	    }
	    else
	    {
		Console.WriteLine("Search operation failed...");
	    }
	    Console.Write(Environment.NewLine);
	}

	static List<Vector2<T>> RangeSearch<T>(Tree<T> _tree, Rectangle<T> _range) where T : IComparable
	{
	    Console.WriteLine("Range search operation with range {0}", _range);
	    var points_in_range = Tree<T>.RangeSearch(_tree, _range);
	    Console.Write(Environment.NewLine);
	    return points_in_range;
	}
	
        static void Main(string[] _args)
	{
	    if(_args.Length > 0)
	    {
		Console.WriteLine("This program does not accept any arguments!"
				  + Environment.NewLine);
	    }
	    
	    Console.WriteLine("K-dimensional tree data structure example - "
                              + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);
	    
	    var random = new Random();
	    
	    // Generate random points
	    var points = new List<Vector2<float>>();
	    for(int i = 0; i < 10; i++)
	    {
		points.Add(new Vector2<float>((float)(random.NextDouble() * 10),
					      (float)(random.NextDouble() * 10)));
	    }
	    
	    // Build a 2D tree containing these points
	    Tree<float> tree = null;
	    foreach(var point in points)
	    {
		tree = Insert<float>(tree, point);
	    }
	    
	    // Search the tree for points
	    for(int i = 0; i < 3; i++)
	    {
		//Select a random point from the collection
		var random_point = points[random.Next(points.Count)];
		Search<float>(tree, random_point);
	    }
	    
	    // Determine which points are in a given rectangle range
	    
	    
	    //Deliberate failing search
	    Search<float>(tree, new Vector2<float>(-1.0f, -1.0f));
	    
	    //Range search on tree
	    var area = new Rectangle<float>(new Vector2<float>(2.5f, 2.5f),
					    new Vector2<float>(7.5f, 7.5f));
	    var points_in_range = RangeSearch<float>(tree, area);

	    Console.WriteLine("Points in range: ");
	    foreach(var point in points_in_range)
	    {
		Console.WriteLine(point.ToString() + ", ");
	    }
	    Console.Write(Environment.NewLine);
	}
    }
}
