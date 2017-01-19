/*
  Stack data structure example
  Copyright 2016, Sjors van Gelderen
*/

using System;
using System.Collections.Generic;

namespace Program
{
    // Describes a stack and associated functionality
    class Stack<T>
    {
	private bool fixed_size = false; // Whether to keep track of capacity
	private uint size = 0; // Capacity of the stack
	private List<T> contents = new List<T>(); // The actual elements stored in the stack
	
	// Dynamic size stack
	public Stack()
	{
	    
	}

	// Fixed size stack
	public Stack(uint _size)
	{
	    fixed_size = true;
	    size = _size;
	}

	// Add element on top of the stack
	public void Push(T _value)
	{
	    if(fixed_size && contents.Count == size)
	    {
		// Stack overflow
		throw new StackOverflowException();
	    }

	    Console.WriteLine("Pushing value {0}", _value);
	    
	    contents.Add(_value);
	}

	// Remove element from top of the stack
	public void Pop()
	{
	    if(contents.Count == 0)
	    {
		//Stack underflow
		throw new InvalidOperationException();
	    }

	    Console.WriteLine("Popping value {0}", contents[contents.Count - 1]);
	    
	    contents.RemoveAt(contents.Count - 1);
	}

	// Access element on top of the stack
	public T Peek()
	{
	    if(contents.Count == 0)
	    {
		throw new InvalidOperationException();
	    }

	    Console.WriteLine("Peeking value {0}", contents[contents.Count - 1]);

	    return contents[contents.Count - 1];
	}

	// Check whether the stack is empty
	public bool IsEmpty()
	{
	    return contents.Count == 0;
	}
    }
    
    static class Program
    {
	static void Main()
	{
	    Console.WriteLine("Stack data structure example - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine
			      + Environment.NewLine);

	    var random = new Random();

	    // Dynamic size stack example
	    var dynamic_stack = new Stack<int>();
	    for(int i = 0; i < 16; i++)
	    {
		dynamic_stack.Push(random.Next(100));
	    }

	    for(int i = 0; i < 4; i++)
	    {
		try
		{
		    dynamic_stack.Pop();
		}
		catch(InvalidOperationException _e)
		{
		    Console.WriteLine("Stack underflow exception occurred! Message: {0}", _e.Message);
		}
	    }

	    // Fixed size stack example
	    var fixed_stack = new Stack<int>(9);
	    for(int i = 0; i < 10; i++)
	    {
		try
		{
		    fixed_stack.Push(random.Next(100));
		}
		catch(StackOverflowException _e)
		{
		    Console.WriteLine("Stack overflow occurred! Message: {0}", _e.Message);
		}
	    }
	    
	    // String stack example
	    var string_stack = new Stack<string>();
	    string_stack.Push("Read book");
	    string_stack.Push("Eat vegetables");
	    string_stack.Push("Do homework");
	    string_stack.Pop();
	    string_stack.Peek();
	    string_stack.Push("Answer phone");

	    while(!string_stack.IsEmpty())
	    {
		try
		{
		    string_stack.Pop();
		}
		catch (InvalidOperationException _e)
		{
		    Console.WriteLine("Invalid operation occurred! Message: {0}", _e.Message);
		}
	    }
	}
    }
}
