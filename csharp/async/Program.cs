/*
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace AsyncExample
{
    class Program
    {
        static void Main(string[] _args)
	    {
		if(_args.Length > 0)
		{
		    Console.WriteLine("This program does not accept any arguments!");
		}

		Console.WriteLine("Async example - Copyright 2016, Sjors van Gelderen");
	    }
    }
}
