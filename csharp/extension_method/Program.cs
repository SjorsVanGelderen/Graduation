/*
  Extension method example
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Test
{
    static class ExtensionMethods
    {
	//Extension method that returns all even characters in a string
	public static string GetEvenCharacters(this string _data)
	{
	    if(_data == null || _data == String.Empty)
	    {
		return string.Empty;
	    }

	    string buffer = String.Empty;
	    for(int i = 0; i < _data.Length; i += 2)
	    {
		buffer += _data[i];
	    }
	    
	    return buffer;
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

	    Console.WriteLine("Extension method example - Copyright 2016, Sjors van Gelderen");
		
	    string sentence = "The spice must flow.";
	    Console.WriteLine("{0}", sentence.GetEvenCharacters());
	}
    }
}
