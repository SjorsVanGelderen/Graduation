/*
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Test
{
    class OtherClass
    {
	public void Frobnicate()
	    {
		Console.WriteLine("Frobnicating...");
	    }
    }
    
    class Program
    {
        static void Main(string[] _args)
	    {
		if(_args.Length > 0)
		{
		    Console.WriteLine("This program does not accept any arguments!");
		}

		Console.WriteLine("Test code - Copyright 2016, Sjors van Gelderen");
		
		var other_class = new OtherClass();
		other_class.Frobnicate();
	    }
    }
}
