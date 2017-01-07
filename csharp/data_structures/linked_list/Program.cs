/*
  Linked list data structure example
  Copyright 2017, Sjors van Gelderen
*/

using System;
using System.Collections.Generic;

namespace Program
{
    // Linked list data structure and associated functionality
    class LinkedList<T> where T : IEquatable<T>
    {
	public T Value { get; set; }
	public LinkedList<T> Next { get; set; }
	
	// No default elements
	public LinkedList()
	{
	    
	}
	
	// Populate with elements from the get-go
	public LinkedList(T[] _elements)
	{
	    foreach(var element in _elements)
	    {
		Insert(element);
	    }
	}

	/*
	  Insert element into list
	  Complexity: O(1)
	*/
	public void Insert(T _value)
	{
	    var temp_next = Next;
	    Next = new LinkedList<T>();
	    Next.Value = _value;
	    Next.Next = temp_next;
	}
	
	/*
	  Find and delete element in list
	  Complexity: O(n)
	*/
	public void Delete(T _value)
	{
	    if(Next == null)
	    {
		Console.WriteLine("Error, element not in collection!");
	    }
	    else if(EqualityComparer<T>.Default.Equals(Next.Value, _value))
	    {
		Next = Next.Next;
	    }
	    else
	    {
		Next.Delete(_value);
	    }
	}

	/*
	  Find index of value in list
	  Complexity: O(n)
	*/
	public int Search(T _value, int _iteration = 0)
	{
	    if(Next == null)
	    {
		return -1;
	    }
	    else if(EqualityComparer<T>.Default.Equals(Next.Value, _value))
	    {
		return _iteration;
	    }
	    else
	    {
		return Next.Search(_value, _iteration + 1);
	    }
	}

	public void Print()
	{
	    if(Next == null)
	    {
		Console.Write(Environment.NewLine);
	    }
	    else
	    {
		Console.Write("{0}, ", Next.Value.ToString());
		Next.Print();
	    }
	}
    }
    
    static class Program
    {
	// Generate string from elements in a collection
	static string StringFromCollection<T>(ref T[] _collection)
	{
	    string buffer = "[";
	    foreach(var element in _collection)
	    {
		buffer += element.ToString();
		buffer += ", ";
	    }
	    buffer += "]";
	    return buffer;
	}
    
	static void Main()
	{
	    Console.WriteLine("Linked list data structure example - "
			      + "Copyright 2017, Sjors van Gelderen"
			      + Environment.NewLine);

	    var random = new Random();

	    // Generate list of integers
	    var int_collection = new int[16];
	    for(int i = 0; i < int_collection.Length; i++)
	    {
		int_collection[i] = random.Next(100);
	    }
	    var int_list = new LinkedList<int>(int_collection);
	    int_list.Print();
	    
	    // Find number 10 in list
	    Console.WriteLine("Searching for element 10 in list");
	    var search_result = int_list.Search(10);
	    if(search_result >= 0)
	    {
		Console.WriteLine("10 found at index {0}", search_result);
	    }
	    else
	    {
		Console.WriteLine("10 not in the list!");
	    }

	    // Delete root of list
	    int_list.Print();
	    Console.WriteLine("Deleting first value in list");
	    int_list.Delete(int_list.Next.Value);
	    int_list.Print();
	    
	    // Generate list of strings
	    var string_collection = new string[]{ "aardvark", "bishop", "cadbury's" };
	    var string_list = new LinkedList<string>(string_collection);

	    // Insert an element
	    string_list.Print();
	    Console.WriteLine("Inserting element in list");
	    string_list.Insert("duke");
	    string_list.Print();
	}
    }
}
