/*
  Exception handling example
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{
    class Program
    {
        static void Main(string[] _args)
	{
	    if(_args.Length > 0)
	    {
		Console.WriteLine("This program does not accept any arguments!" + Environment.NewLine);
	    }

	    Console.WriteLine("Exception handling example - Copyright 2016, Sjors van Gelderen" + Environment.NewLine);

	    Console.WriteLine(Division(10, 3).ToString());
	    Console.WriteLine(Division(45, 7).ToString());
	    Console.WriteLine(Division(3, 0).ToString());
	}

	static float Division(int _a, int _b)
	{
	    try
	    {
		return _a / _b;
	    }
	    catch(Exception _exception)
	    {
		Console.WriteLine("Exception in Division function: " + _exception.StackTrace);
		return -1;
	    }
	}
    }
}
