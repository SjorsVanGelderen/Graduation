/*
  Observer design pattern example
  Copyright 2016, Sjors van Gelderen
*/

using System;
using System.Collections.Generic;

namespace Program
{
    // Subjects to be observed derive from this class
    abstract class Subject
    {
	// All subscribed observers
	private List<Observer> observers = new List<Observer>();

	// Subscribe a new observer
	public void Attach(Observer _observer)
	{
	    if(!observers.Contains(_observer))
	    {
		observers.Add(_observer);
	    }
	}

	// Remove a subscription
	public void Detach(Observer _observer)
	{
	    if(observers.Contains(_observer))
	    {
		observers.Remove(_observer);
	    }
	}

	// Push changes to subscribed observers
	public void Notify()
	{
	    foreach(var observer in observers)
	    {
		observer.Update();
	    }
	}
    }

    // Observers of subjects derive from this class
    abstract class Observer
    {
	// Called by subject to push data to this observer
	public abstract void Update();
    }

    // Pushes data to clients
    class Server : Subject
    {
	public string Name { get; set; }
        public int PlayerAmount { get; set; } = 10;

	public Server(string _name)
	{
	    Name = _name;
	}
    }
    
    // Receives communications from a server and reports the new state
    class Client : Observer
    {
	public string Name { get; set; }
	public Server connectedServer { get; set; }

	public Client(string _name)
	{
	    Name = _name;
	}

	// Override default behaviour to specify what is to be done for the observer
	public override void Update()
	{
	    Console.WriteLine("Client {0} received data from server {1}. "
			      + "Player amount is now: {2}",
			      Name,
			      connectedServer.Name,
			      connectedServer.PlayerAmount);
	}
    }
    
    static class Program
    {
	// Subscribe observer to subject
	static void Connect(Client _client, Server _server)
	{
	    Console.WriteLine("Connecting client {0} to server {1}",
			      _client.Name,
			      _server.Name);
	    
	    _server.Attach(_client);
	    _client.connectedServer = _server;
	}

	// Unsubscribe client from server
	static void Disconnect(Client _client, Server _server)
	{
	    Console.WriteLine("Disconnected client {0} from server {1}",
			      _client.Name,
			      _server.Name);
	    
	    _server.Detach(_client);
	    _client.connectedServer = null;
	}
	
	static void Main()
	{
	    Console.WriteLine("Observer design pattern example - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);

	    // Create some subjects
	    var servers = new Server[]{
		new Server("Atreides"),
		new Server("Harkonnen"),
		new Server("Corrino")
	    };

	    // Create some observers
	    var clients = new Client[]{
		new Client("Paul"),
		new Client("Vladimir"),
		new Client("Shaddam")
	    };
	    
	    // Perform some demonstrational operations
	    Connect(clients[0], servers[0]);
	    Connect(clients[1], servers[0]);
	    servers[0].PlayerAmount = 15;
	    servers[0].Notify();
	    Disconnect(clients[0], servers[0]);
	    servers[0].PlayerAmount = 23;
	    servers[0].Notify();
	    
	    Connect(clients[2], servers[1]);
	    servers[1].PlayerAmount = 100;
	    servers[1].Notify();
	    
	    Connect(clients[1], servers[2]);
	    servers[2].PlayerAmount = 1;
	    servers[2].Notify();
	    Connect(clients[1], servers[2]);
	    Connect(clients[0], servers[2]);
	    servers[2].Notify();
	}
    }
}
