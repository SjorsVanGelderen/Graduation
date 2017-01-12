/*
  K-dimensional tree data structure example
  Copyright 2016, Sjors van Gelderen
*/

using System;
using System.Collections.Generic;

namespace Program
{
    /*
      Describes a location or displacement
    */
    class Vector2<T>
    {
	public T X { get; set; }
	public T Y { get; set; }
	
	public Vector2(T _x, T _y)
	{
	    X = _x;
	    Y = _y;
	}
    }

    /*
      Describes a rectangular area
    */
    class Rectangle<T>
    {
	public Vector2<T> TopLeft     { get; set; }
	public Vector2<T> BottomRight { get; set; }

	public Rectangle(Vector2<T> _top_left, Vector2<T> _bottom_right)
	{
	    TopLeft = _top_left;
	    BottomRight = _bottom_right;
	}

	public bool Contains(Vector2<T> _point)
	{
	    return _point.X >= TopLeft.X &&
		_point.X <= BottomRight.X &&
		_point.Y >= TopLeft.Y &&
		_point.Y <= BottomRight.Y;
	}
    }

    /*
      Describes a 2D implementation of a K-dimensional tree
    */
    class TwoDimensionalTree<T>
    {
	public Vector2<T> Value { get; set; }
	public TwoDimensionalTree<T> Left  { get; set; } = new TwoDimensionalTree<T>();
	public TwoDimensionalTree<T> Right { get; set; } = new TwoDimensionalTree<T>();
	
	public void Insert(Vector2<T> _value, bool _vertical = true)
	{
	    if(Value == null)
	    {
		Value = _value;
	    }
	    else
	    {
		bool left = _vertical ? _value.X < Value.X : _value.Y < Value.Y;
		var target = left ? Left : Right;
		target.Insert(_value, !_vertical);
	    }
	}
	
	public bool Delete(Vector2<T> _value, bool _vertical = true)
	{
	    if(Value == null)
	    {
		//Value was not found
		return false;
	    }
	    else if(Value == _value)
	    {
		//Value was found and deleted

		//Standard BST delete operation here but pay attention to orientation
		
		return true;
	    }
	    else
	    {
		bool left = _vertical ? _value.X < Value.X : _value.Y < Value.Y;
		var target = left ? Left : Right;
		return target.Delete(_value, !_vertical);
	    }
	}

	public void Search(Vector2<T> _value, bool _vertical = true)
	{
	    if(Value == null)
	    {
		//Value was not found
	    }
	    else if(Value == _value)
	    {
		//Value was found
		Console.WriteLine("Found value {0} in tree!", _value);
	    }
	    else
	    {
		bool left = _vertical ? _value.X < Value.X : _value.Y < Value.Y;
		var target = left ? Left : Right;

		if(left)
		{
		    Console.WriteLine("Moving left");
		}
		else
		{
		    Console.WriteLine("Moving right");
		}
		
		return target.Search(_value, !_vertical);
	    }
	}

	public List<Vector2<T>> Range(Rectangle<T> _area,
				      List<Vector2<T>> _accumulator,
				      bool _vertical = true)
	{
	    var list = new List<Vector2<T>>();
	    
	    if(Value == null)
	    {
		//End of tree, return an empty list
	        return list;
	    }
	    
	    if(_area.Contains(Value))
	    {
		//Value in range
		list.Add(Value);
	    }
	    
	    if(_vertical)
	    {
		if(_area.TopLeft.X < Value.X || _area.BottomRight.X < Value.X)
		{
		    foreach(var element in Left.Range(_area, !_vertical))
		    {
			list.Add(element);
		    }
		}
		else if(_area.TopLeft.X > Value.X || _area.BottomRight.X > Value.X)
		{
		    foreach(var element in Right.Range(_area, !_vertical))
		    {
			list.Add(element);
		    }
		}
	    }
	    else
	    {
		if(_area.TopLeft.Y < Value.Y || _area.BottomRight.Y < Value.Y)
		{
		    foreach(var element in Left.Range(_area, !_vertical))
		    {
			list.Add(element);
		    }
		}
		else if(_area.TopLeft.Y > Value.Y || _area.BottomRight.Y > Value.Y)
		{
		    foreach(var element in Right.Range(_area, !_vertical))
		    {
			list.Add(element);
		    }
		}
	    }

	    return list;
	}
    }
    
    static class Program
    {
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

	    /*
	    //Generate random points
	    var points = List<Vector2<float>>();
	    for(int i = 0; i < 10; i++)
	    {
		points.Add(new Vector2<float>(random.NextDouble() * 10,
					      random.NextDouble() * 10));
	    }
	    
	    //Build a tree containing these points
	    var tree = new TwoDimensionalTree<float>();
	    foreach(var point in points)
	    {
		tree.Insert(point);
	    }

	    //Search the tree for points
	    for(int i = 0; i < 3; i++)
	    {
		//Select a random point from the collection
		var random_point = points[random.NextInt(points.Count)];
		tree.Search(random_point);
	    }
	    */

	    //Delete points from the tree

	    //Reconduct search of points in tree

	    //Range search on tree
	}
    }
}
