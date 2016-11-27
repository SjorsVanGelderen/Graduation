/*
  Bineary heap sort example
  Copyright 2016, Sjors van Gelderen
*/

using System;
using System.Collections.Generic;

namespace AnonymousType
{
    class Heap
    {
        private List<int> keys = new List<int>();
	
	public void Insert(int _key)
	{
	    keys.Add(_key);
	}

	public void Heapify(bool _max)
	{
	    for(int i = keys.Count; i > 0; i--)
	    {
		if(_max)
		{
		    if(keys.At(i) > keys.At(i - 1))
		    {
			
		    }
		}
	    }
	}

	public void Print()
	{
	    
	}
    }
    
    class Program
    {	
        static void Main(string[] _args)
	{
	    if(_args.Length > 0)
	    {
		Console.WriteLine("This program does not accept any arguments!" + Environment.NewLine);
	    }

	    Console.WriteLine("Binary heap sort example - Copyright 2016, Sjors van Gelderen" + Environment.NewLine);
	    
	    Console.WriteLine("Creating min heap");
	    var min_heap = new Heap();
	    min_heap.Insert(4);
	    min_heap.Insert(6);
	    min_heap.Insert(9);
	    min_heap.Insert(10);
	    min_heap.Insert(2);
	    min_heap.Insert(5);
	    min_heap.Insert(7);
	    min_heap.Sort();
	    min_heap.Print();
	    
	    Console.WriteLine("Creating max heap");
	    var max_heap = new Heap();
	    max_heap.Insert(4);
	    max_heap.Insert(6);
	    max_heap.Insert(9);
	    max_heap.Insert(10);
	    max_heap.Insert(2);
	    max_heap.Insert(5);
	    max_heap.Insert(7);
	    max_heap.Sort();
	    max_heap.Print();
	}
    }
}
