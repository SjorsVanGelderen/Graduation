/*
  Strategy design pattern example
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{
    // The main strategy interface
    interface Strategy
    {
        void Execute();
    }

    //Several descriptions of concrete strategies that might be used in a game situation
    class Cheese : Strategy
    {
	public void Execute()
	{
	    Console.WriteLine("Executing Steel Talons quick engineer cheese!");
	}
    }

    class Rush : Strategy
    {
	public void Execute()
	{
	    Console.WriteLine("Executing zerg rush!");
	}
    }

    class Steamroll : Strategy
    {
	public void Execute()
	{
	    Console.WriteLine("Executing Scorpion Tank steamroll!");
	}
    }

    class Turtle : Strategy
    {
	public void Execute()
	{
	    Console.WriteLine("Executing Tesla coil spam turtling!");
	}
    }

    // Description of a context in which to employ a strategy
    class Context
    {
	private Strategy strategy;

	public Context(Strategy _strategy)
	{
	    strategy = _strategy;
	}

	public void GoToBattle()
	{
	    strategy.Execute();
	}
    }
    
    static class Program
    {
	static void Main()
	{
	    Console.WriteLine("Strategy design pattern example - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);
	    
	    // Create several contexts and execute the relevant strategy
	    var horang2 = new Context(new Cheese());
	    horang2.GoToBattle();

	    var jaedong = new Context(new Rush());
	    jaedong.GoToBattle();

	    var flash = new Context(new Steamroll());
	    flash.GoToBattle();

	    var stork = new Context(new Turtle());
	    stork.GoToBattle();
	}
    }
}
