/*
  Async & await example
  Copyright 2016, Sjors van Gelderen
*/

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
	// An asynchronous task that will collect data from an online resource
	static async Task<string> CollectDataAsync()
	{
	    Console.WriteLine("Collecting data from Google UK...");
		
	    // Create the HTTP client
	    var client = new HttpClient();
		
	    // Asynchronously collect data from Google UK
	    Task<string> get_string_task = client.GetStringAsync("http://google.co.uk");

	    // Meanwhile, print a message
	    Console.WriteLine("Doing something really important while waiting for data...");
	    
	    // Block until the data arrives, then return it
	    return await get_string_task;
	}
	
        static void Main()
	{
	    Console.WriteLine("Async & await example - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);

	    // Run an asynchronous task
	    string data = CollectDataAsync().Result;
	    Console.WriteLine("Received data: {0}", data);

	    // If no additional tasks are to be performed, this is also possible:
	    // string data = await client.GetStringAsync("http://google.co.uk");
	}
    }
}
