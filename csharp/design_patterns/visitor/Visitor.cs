/*
  Copyright 2016, Sjors van Gelderen
  
  The visitor design pattern prevents
  null reference exceptions at compile time
*/

using System;

namespace VisitorExample
{  
/*
  Unit exists because anonymous functions must return a value
  It is essentially an empty singleton
*/
    public sealed class Unit
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
    
/*
  The Option interface is used to create variables that
  contain Some or None as opposed to a value or null
*/
    public interface Option<T>
    {
	U Visit<U>(Func<T, U> _onSome, Func<U> _onNone);
    }
    
/*
  Some and None both implement Option
  Only Some holds an actual value
*/
    public class Some<T> : Option<T>
    {
	T value;
	
	public Some(T _value)
	    {
		this.value = _value;
	    }
	
	public U Visit<U>(Func<T, U> _onSome, Func<U> _onNone)
	    {
		return _onSome(value);
	    }
    }
    
    public class None<T> : Option<T>
    {
	public U Visit<U>(Func<T, U> _onSome, Func<U> _onNone)
	    {
		return _onNone();
	    }
    }
}
