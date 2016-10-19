/*
  Events example
  Note that the warnings are harmless in this edge case
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{
    //For objects that will contain information about the news event
    public class NewsEventArgs : EventArgs
    {
	private string title;
	private string detail;

	public NewsEventArgs(string _title, string _detail)
	{
	    title = _title;
	    detail = _detail;
	}

	public string Title
	{
	    get
	    {
		return title;
	    }
	}

	public string Detail
	{
	    get
	    {
		return detail;
	    }
	}
    }
    
    //Dispatches the events to subscribers
    class NewsManager
    {
	public event EventHandler<NewsEventArgs> developer_event_handler;
	public event EventHandler<NewsEventArgs> publisher_event_handler;
	public event EventHandler<NewsEventArgs> broadcaster_event_handler;

	public void PublishNews(string _source, string _title, string _detail)
	{
	    NewsEventArgs news = new NewsEventArgs(_title, _detail);

	    switch(_source)
	    {
		case "developer":
		    OnDeveloperNews(news);
		    break;

		case "publisher":
		    OnPublisherNews(news);
		    break;

		case "broadcaster":
		    OnBroadcasterNews(news);
		    break;

		default:
		    Console.WriteLine("Source {0} is not handled!", _source);
		    break;
	    }
	}
	
	protected virtual void OnDeveloperNews(NewsEventArgs _news)
	{
	    EventHandler<NewsEventArgs> handler = developer_event_handler;
	    if(handler != null)
	    {
		handler(this, _news);
	    }
	}
	
	protected virtual void OnPublisherNews(NewsEventArgs _news)
	{
	    EventHandler<NewsEventArgs> handler = publisher_event_handler;
	    if(handler != null)
	    {
		handler(this, _news);
	    }
	}
	
	protected virtual void OnBroadcasterNews(NewsEventArgs _news)
	{
	    EventHandler<NewsEventArgs> handler = broadcaster_event_handler;
	    if(handler != null)
	    {
		handler(this, _news);
	    }
	}
    }

    //Expects information from the developer
    class Publisher
    {
	NewsManager nm = null;
	
	public Publisher(NewsManager _nm)
	{
	    nm = _nm;
	    nm.developer_event_handler += InformBroadcasters;
	}

	private void InformBroadcasters(object _sender, NewsEventArgs _news)
	{
	    Console.WriteLine("Publisher is informing broadcasters about {0} for developer.\n" +
			      "The message is: {1}.",
			      _news.Title, _news.Detail);
	    nm.PublishNews("publisher", _news.Title, _news.Detail);
	}
    }

    //Expects information from the publisher
    class Broadcaster
    {
	NewsManager nm = null;
	
	public Broadcaster(NewsManager _nm)
	{
	    nm = _nm;
	    nm.publisher_event_handler += Broadcast;
	}

	private void Broadcast(object _sender, NewsEventArgs _news)
	{
	    Console.WriteLine("Broadcaster received message from publisher about {0} " +
			      "and will release article conveying: {1}",
			      _news.Title, _news.Detail);
	    nm.PublishNews("broadcaster", _news.Title, _news.Detail);
	}
    }

    //Expects information from the broadcaster
    class Fan
    {
	NewsManager nm = null;
	
	public Fan(NewsManager _nm)
	{
	    nm = _nm;
	    nm.broadcaster_event_handler += Rejoice;
	}

	private void Rejoice(object _sender, NewsEventArgs _news)
	{
	    Console.WriteLine("Fan read broadcaster's article about {0} and is rejoicing about: {1}!",
			      _news.Title, _news.Detail);
	}

	public void Subscribe()
	{
	    nm.broadcaster_event_handler += Rejoice;
	}
	
	public void Unsubscribe()
	{
	    nm.broadcaster_event_handler -= Rejoice;
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

	    Console.WriteLine("Events example - Copyright 2016, Sjors van Gelderen" + Environment.NewLine);
	    
	    NewsManager nm = new NewsManager();
	    Publisher publisher = new Publisher(nm);
	    Broadcaster[] broadcasters = { new Broadcaster(nm), new Broadcaster(nm) };
	    Fan[] fans = { new Fan(nm), new Fan(nm), new Fan(nm) };
	    
	    nm.PublishNews("developer", "Tetris", "In development");
	    nm.PublishNews("developer", "Tic-Tac-Toe", "In development");

	    fans[1].Unsubscribe();
	    fans[2].Unsubscribe();
	    
	    nm.PublishNews("developer", "Tetris", "Trailer released");
	    nm.PublishNews("developer", "Tic-Tac-Toe", "Game released");
	}
    }
}
