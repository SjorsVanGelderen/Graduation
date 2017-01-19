/*
  Async & await example
  Copyright 2017, Sjors van Gelderen
*/

using System;
using System.Net.Http;
using System.Threading;
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
	    for(int i = 0; i < 4; i++)
	    {
		Console.WriteLine("Doing something really important while waiting for data...");
		Thread.Sleep(10);
	    }
	    
	    // Block until the data arrives, then return it
	    return await get_string_task;
	}
	
        static void Main()
	{
	    Console.WriteLine("Async & await example - "
			      + "Copyright 2017, Sjors van Gelderen"
			      + Environment.NewLine);

	    // Run an asynchronous task
	    string data = CollectDataAsync().Result;
	    Console.WriteLine("Received data: {0}", data);

	    // If no additional tasks are to be performed, this is also possible:
	    // string data = await client.GetStringAsync("http://google.co.uk");
	}
    }
}
