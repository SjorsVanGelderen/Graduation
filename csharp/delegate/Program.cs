/*
  Delegate example
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{    
    class Program
    {
	//Base prototype for the delegate
	delegate int Expression(int _x, int _y);
	
        static void Main(string[] _args)
	{
	    if(_args.Length > 0)
	    {
		Console.WriteLine("This program does not accept any arguments!");
	    }

	    Console.WriteLine("Delegate example - Copyright 2016, Sjors van Gelderen");

	    //Array containing results of executing HandleExpression with an inline delegate
	    int[] results = {
		HandleExpression(delegate(int _x, int _y){ return _x + _y; }, 10, 5),
		HandleExpression(delegate(int _x, int _y){ return _x - _y; }, 10, 5),
		HandleExpression(delegate(int _x, int _y){ return _x * _y; }, 10, 5),
		HandleExpression(delegate(int _x, int _y){ return _x / _y; }, 10, 5)
	    };
	    
	    foreach(int i in results)
	    {
		Console.WriteLine(i.ToString());
	    }
	}

	static int HandleExpression(Expression expression, int _x, int _y)
	{
	    return expression(_x, _y);
	}
    }
}
