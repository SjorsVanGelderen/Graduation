/*
  Iterators / state machines example
  Copyright 2016, Sjors van Gelderen
*/

using System;
using System.Collections;

namespace Program
{
    //Class holding a state machine
    public class Truck
    {
	private Random random = null;
	
	public Truck(Random _random)
	{
	    random = _random;
	}

	//The actual enumerator
	public IEnumerator GetEnumerator()
	{	    
	    yield return "Loading cargo";
	    yield return "Moving cargo";
	    
	    if(random.Next(3) == 0)
	    {
		yield return "Truck is out of order";
		yield return "Awaiting mechanic";
		yield return "Getting repaired";
		yield return "Continuing moving of cargo";
	    }
	    
	    yield return "Unloading cargo";
	    yield return "Returning";
	}
    }

    //Class holding an IEnumerable that operates on a string array
    class Characters
    {
	string[] characters = {
	    "Mario",
	    "Luigi",
	    "Peach",
	    "Bowser",
	    "Toad"
	};
	
	public IEnumerable CharacterIterator(int _start, int _end, int _step = 1)
	{
	    for(int i = _start; i < _end; i += _step)
	    {
	        int index = i % characters.Length;
		if(index < 0)
		{
		    index += characters.Length;
		}
		
		yield return characters[index];
	    }
	}
    }
    
    class Program
    {
	static Random random = new Random();
	
        static void Main()
	{
	    Console.WriteLine("Iterators / state machines example - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);

	    //Process a number of trucks
	    for(int i = 0; i < 5; i++)
	    {
		Console.WriteLine("Dispatching truck {0}!", i);
		
		foreach(var state in new Truck(random))
		{
		    Console.WriteLine(state);
		}
		
		Console.WriteLine(Environment.NewLine);
	    }

	    //Process some characters
	    foreach(string character in (new Characters()).CharacterIterator(-16, 16, 3))
	    {
		Console.WriteLine(character);
	    }
	}
    }
}
