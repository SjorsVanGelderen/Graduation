/*
  Option and design patterns
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{
    // The option interface requires handling both the Some and None cases
    interface Option<T>
    {
	U Visit<U>(Func<T, U> _on_some, Func<U> _on_none);
    }

    /*
      The Unit singleton is used when an operation has an empty return value
      Note that Unit and Void are not mathematically equivalent,
      as Void implies the absence of data, wheras Unit implies empty data
    */
    sealed class Unit
    {
	private static readonly Unit instance = new Unit();

	private Unit()
	{

	}

	public static Unit Instance
	{
	    get
	    {
		return instance;
	    }
	}
    }

    // The Some object contains actual data
    class Some<T> : Option<T>
    {
	T value; // The data

	// Constructor forces the programmer to supply data as an argument
	public Some(T _value)
	{
	    this.value = _value;
	}

	// Visit on a Some object will trigger the _on_some lambda on the data
	public U Visit<U>(Func<T, U> _on_some, Func<U> _on_none)
	{
	    return _on_some(value);
	}
    }

    // The None object does not contain data
    class None<T> : Option<T>
    {
	// Visit on a None object will trigger the _on_none lambda
	public U Visit<U>(Func<T, U> _on_some, Func<U> _on_none)
	{
	    return _on_none();
	}
    }

    // 
    class 
    
    static class Program
    {
	static void Main(string[] _args)
	{
	    Console.WriteLine("Option and visitor pattern example - "
                              + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine
			      + Environment.NewLine);

	    // Although the integer variable is empty, no null reference exception will occur
	    Option<int> integer = new None<int>();
	    integer.Visit<Unit>(
	        x  => { Console.WriteLine(x.ToString());
			return Unit.Instance; },
		() => { Console.WriteLine("No data!");
			return Unit.Instance; });
	    
	    // The data is now available and may be used by the on_some lambda
	    integer = new Some<int>(5);
	    integer.Visit<Unit>(
	        x  => { Console.WriteLine(x.ToString());
			return Unit.Instance; },
		() => { Console.WriteLine("No data!");
			return Unit.Instance; });
	}
    }
}
