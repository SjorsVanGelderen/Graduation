/*
  Indexers and enum example
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace IndexersAndEnum
{
    //All available playing cards
    enum Card
    {
	Jack,
	Queen,
	King,
	Ace
    };

    //Simple class for a single hand
    class Hand
    {
	private Card[] cards = {
	    Card.Jack,
	    Card.Queen,
	    Card.King,
	    Card.Ace
	};

	public int Length
	{
	    get
	    {
		return cards.Length;
	    }
	}
	
	public Card this[int _i]
	{
	    get
	    {
		return cards[_i];
	    }
	    set
	    {
		cards[_i] = value;
	    }
	}
    }
    
    class Program
    {
        static void Main(string[] _args)
	{
	    if(_args.Length > 0)
	    {
		Console.WriteLine("This program does not accept any arguments!");
	    }

	    Console.WriteLine("Indexers and enum example - Copyright 2016, Sjors van Gelderen");

	    Hand hand = new Hand();
	    string buffer = "The following cards are in the hand: ";
	    for(int i = 0; i < hand.Length; i++)
	    {
	        switch(hand[i])
		{
		    case Card.Jack:
			buffer += "Jack";
			break;

		    case Card.Queen:
			buffer += "Queen";
			break;

		    case Card.King:
			buffer += "King";
			break;

		    case Card.Ace:
			buffer += "Ace";
			break;

		    default:
			break;
		}

		if(i < hand.Length - 1)
		{
		    buffer += ", ";
		}
	    }

	    Console.WriteLine(buffer);
	}
    }
}
