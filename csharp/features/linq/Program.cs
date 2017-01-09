/*
  LINQ example
  Copyright 2017, Sjors van Gelderen

  Resources used:
  https://msdn.microsoft.com/en-us/library/bb397906.aspx - Introduction to LINQ queries
https://msdn.microsoft.com/en-us/library/system.linq.enumerable(v=vs.110).aspx - Enumerable class
*/

using System;
using System.Linq;

namespace Program
{
    class Play
    {
	public string Title { get; set; }
	public int Year { get; set; }

	public Play(string _title, int _year)
	{
	    Title = _title;
	    Year = _year;
	}
    }
    
    static class Program
    {
	static void Main()
	{
	    Console.WriteLine("LINQ example - "
			      + "Copyright 2017, Sjors van Gelderen"
			      + Environment.NewLine);

	    // Create some data sources
	    int[] int_sequence = {41, 43, 47, 53, 61};
	    
	    string[] string_sequence = {
		"Her",
		"breasts",
		"like",
		"ivory",
		"globes",
		"circled",
		"with",
		"blue"
	    };

	    Play[] plays = {
		new Play("Macbeth", 1599),
		new Play("Much Ado About Nothing", 1598),
		new Play("As You Like It", 1599)
	    };

	    // Query for odd numbers
	    var numbers_smaller_than_50_query =
		from number in int_sequence
		where number < 50
		select number;
	    
	    Console.Write("Odd numbers: ");
	    foreach(int number in numbers_smaller_than_50_query)
	    {
		Console.Write("{0,3}", number.ToString());
	    }
	    Console.Write(Environment.NewLine);

	    // Query for words with a 'b' in them
	    var b_query = string_sequence
		.Where(word => word.Contains("b") || word.Contains("B"));
	    
	    Console.Write("Words with a 'b' in them: ");
	    foreach(string word in b_query)
	    {
		Console.Write(word + ", ");
	    }
	    Console.Write(Environment.NewLine);

	    // Query for plays with an 'm' in the title from the year 1599
	    var m_1599_query = plays
		.Where(play => (play.Title.Contains("m") || play.Title.Contains("M")) &&
		       play.Year == 1599);
	    
	    Console.Write("Plays with an 'm' in the title from the year 1599: ");
	    foreach(Play play in m_1599_query)
	    {
		Console.Write("{0} - {1}, ", play.Title, play.Year);
	    }
	    Console.Write(Environment.NewLine);

	    // Query for some numbers from the integer sequence
	    var some_numbers_query = int_sequence
		.Skip(2)
		.Take(2);

	    Console.Write("Picked numbers: ");
	    foreach(int number in some_numbers_query)
	    {
		Console.Write("{0,3}", number);
	    }
	    Console.Write(Environment.NewLine);

	    // Query that sorts words according to their lengths
	    var sort_words_query = string_sequence
		.OrderBy(word => word.Length);

	    Console.Write("Words sorted by length: ");
	    foreach(string word in sort_words_query)
	    {
		Console.Write("{0}, ", word);
	    }
	    Console.Write(Environment.NewLine);

	    // Query that sorts plays according to their years
	    var sort_plays_by_year_query = plays
		.OrderByDescending(play => play.Year);

	    Console.Write("Plays sorted by their years: ");
	    foreach(var play in sort_plays_by_year_query)
	    {
		Console.Write("{0} - {1}, ", play.Year, play.Title);
	    }
	    Console.Write(Environment.NewLine);
	}
    }
}
