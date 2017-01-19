/*
  Delegates and anonymous methods example
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{    
    class Program
    {
	//Base prototype for a delegate
	delegate int Delegate(int _x, int _y);
	
        static void Main()
	{
	    Console.WriteLine("Delegates and anonymous method(lambda) example - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);

	    //Array containing results of executing HandleDelegate with an inline delegate
	    int[] results = {
		HandleDelegate(delegate(int _x, int _y){ return _x + _y; }, 10, 5),
		HandleDelegate(delegate(int _x, int _y){ return _x - _y; }, 10, 5),
		HandleDelegate(delegate(int _x, int _y){ return _x * _y; }, 10, 5),
		HandleDelegate(delegate(int _x, int _y){ return _x / _y; }, 10, 5)
	    };

	    //Print the result of each handled delegate
	    foreach(int i in results)
	    {
		Console.WriteLine(i.ToString());
	    }

	    //Example of a Func delegate with an anonymous method(lambda)
	    Func<int, string> int_to_string = _d => _d.ToString();
	    Console.WriteLine(int_to_string(64));

	    //Example of an Action delegate with an anonymous method(lambda)
	    Action<float, float> output_two_floats =
		(_a, _b) => Console.WriteLine("{0} and {1}", _a, _b);

	    output_two_floats(0.5f, 13.63f);
	}

	//Executes a delegate
	static int HandleDelegate(Delegate _delegate, int _x, int _y)
	{
	    return _delegate(_x, _y);
	}
    }
}
