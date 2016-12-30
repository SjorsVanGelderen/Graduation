/*
  Abstract factory design pattern example
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{
    abstract class AbstractFactory
    {
	public abstract AbstractProductA CreateProductA();
	public abstract AbstractProductB CreateProductB();
    }

    class ConcreteFactoryA : AbstractFactory
    {
	public override AbstractProductA CreateProductA()
	{
	    return new ProductA();
	}

	public override AbstractProductB CreateProductB()
	{
	    return new ProductB();
	}
    }
    
    static class Program
    {
	static void Main()
	{
	    Console.WriteLine("Abstract factory design pattern example - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine
			      + Environment.NewLine);
	    
	}
    }
}
