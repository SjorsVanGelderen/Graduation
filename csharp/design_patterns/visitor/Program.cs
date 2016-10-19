/*
  Copyright 2016, Sjors van Gelderen

  Demonstrates the visitor pattern with lambdas
*/

using System;

namespace VisitorExample
{
    class Program
    {
        static void Main(string[] _args)
	    {
		if(_args.Length > 0)
		{
		    Console.WriteLine("This program does not accept any arguments!");
		}

		Console.WriteLine("Visitor design pattern example - Copyright 2016, Sjors van Gelderen");

		Option<int> option_int = new None<int>();
		Option<string> option_string = new None<string>();
		
		option_int.Visit<Unit>(
		    x  => { x += 5;
			    Console.WriteLine("The first attempt worked: " + x.ToString());
			    return Unit.Instance; },
		    () => { Console.WriteLine("This option contains None!");
			    return Unit.Instance; });
		
		option_string.Visit<Unit>(
		    x  => { Console.WriteLine(x);
			    return Unit.Instance; },
		    () => { Console.WriteLine("This option contains None!");
			    return Unit.Instance; });
		
		option_int = new Some<int>(10);
		option_string = new Some<string>("Bagels are great");
		
		option_int.Visit<Unit>(
		    x  => { x += 5;
			    Console.WriteLine("The second attempt worked: " + x.ToString());
			    return Unit.Instance; },
		    () => { Console.WriteLine("This option contains None!");
			    return Unit.Instance; });

		option_string.Visit<Unit>(
		    x  => { Console.WriteLine(x);
			    return Unit.Instance; },
		    () => { Console.WriteLine("This option contains None!");
			    return Unit.Instance; });
	    }
    }
}
