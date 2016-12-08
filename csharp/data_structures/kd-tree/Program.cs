/*
  K-dimensional tree data structure example
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{
    class Vector2<T>
    {
	public T X { get; set; }
	public T Y { get; set; }
	
	public Vector2<T>(T _x, T _y)
	{
	    X = _x;
	    Y = _y;
	}
    }
    
    class 2DTree<T>
    {
	public Vector2<T> Value { get; set; }
	public 2DTree     Left  { get; set; } = new 2DTree<T>();
	public 2DTree     Right { get; set; } = new 2DTree<T>();
	
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

	public bool Search(Vector2<T> _value, bool _vertical = true)
	{
	    if(Value == null)
	    {
		//Value was not found
		return false;
	    }
	    else if(Value == _value)
	    {
		//Value was found
		return true;
	    }
	    else
	    {
		bool left = _vertical ? _value.X < Value.X : _value.Y < Value.Y;
		var target = left ? Left : Right;
		return target.Search(_value, !_vertical);
	    }
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

	    Console.WriteLine(@"K-dimensional tree data structure example - 
                                Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);

	    
	}
    }
}
