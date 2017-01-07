/*
  Anonymous type example
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace AnonymousType
{
    class Program
    {
        static void Main(string[] _args)
	{
	    if(_args.Length > 0)
	    {
		Console.WriteLine("This program does not accept any arguments!" + Environment.NewLine);
	    }

	    Console.WriteLine("Anonymous type example - Copyright 2016, Sjors van Gelderen" + Environment.NewLine);

	    //Create the object with an anonymous type
	    var object_of_anonymous_type = new {
		Name     = "Marty McFly",
		Car      = "DeLorean",
		Friend   = "Emmett",
		Timezone = "Past"
	    };

	    //Print its properties
	    Console.WriteLine("Name: {0}, Car: {1}, Friend: {2}, Timezone: {3}",
			      object_of_anonymous_type.Name,
			      object_of_anonymous_type.Car,
			      object_of_anonymous_type.Friend,
			      object_of_anonymous_type.Timezone);
	}
    }
}
