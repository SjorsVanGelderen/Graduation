/*
  Interfaces example
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{
    //Sample interfaces
    interface IToggleable<T>
    {
	void Toggle();
	void ToggleOn();
	void ToggleOff();
	bool IsOn();
    }

    interface IPullable<T>
    {
	void Pull(int _degrees);
	void Reset();
	int GetDegrees();
    }

    interface IFrobnicable<T>
    {
	int Frobnicate();
    }
    
    class Button : IToggleable<Button>
    {
	bool on = false;
	
	public void Toggle()
	{
	    if(on)
	    {
		ToggleOff();
	    }
	    else
	    {
		ToggleOn();
	    }
	}

	public void ToggleOn()
	{
	    Console.WriteLine("Toggling button on!");
	    on = true;
	}

	public void ToggleOff()
	{
	    Console.WriteLine("Toggling button off!");
	    on = false;
	}

	public bool IsOn()
	{
	    return on;
	}
    }

    class Lever : IPullable<Lever>
    {
	int degrees = 0;
	
	public void Pull(int _degrees)
	{
	    int old_degrees = degrees;
	    
	    degrees += _degrees;
	    if(degrees >= 360)
	    {
		degrees = 360;
	    }
	    else if(degrees <= 0)
	    {
		degrees = 0;
	    }

	    Console.WriteLine("Pulled lever {0} degrees!", degrees - old_degrees);
	}

	public void Reset()
	{
	    degrees = 0;
	    Console.WriteLine("Reset lever to 0 degrees!");
	}

	public int GetDegrees()
	{
	    return degrees;
	}
    }

    //Sample of a class implementing two interfaces
    class Fingerbox : IToggleable<Fingerbox>, IFrobnicable<Fingerbox>
    {
	bool on = false;
	
	public void Toggle()
	{
	    if(on)
	    {
		ToggleOff();
	    }
	    else
	    {
		ToggleOn();
	    }
	}

	public void ToggleOn()
	{
	    Console.WriteLine("Toggling fingerbox on!");
	    on = true;
	}

	public void ToggleOff()
	{
	    Console.WriteLine("Toggling fingerbox off!");
	    on = false;
	}

	public bool IsOn()
	{
	    return on;
	}

	public int Frobnicate()
	{
	    if(on)
	    {
		return 1100;
	    }
	    else
	    {
		return -1;
	    }
	}
    }
    
    class Program
    {
        static void Main()
	{
	    Console.WriteLine("Interfaces example - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);
		
	    var button = new Button();
	    button.ToggleOn();
	    button.Toggle();
	    
	    var lever = new Lever();
	    lever.Pull(66);
	    Console.WriteLine("Lever degrees: {0}", lever.GetDegrees());
	    lever.Pull(-23);
	    Console.WriteLine("Lever degrees: {0}", lever.GetDegrees());
	    lever.Reset();
	    Console.WriteLine("Lever degrees: {0}", lever.GetDegrees());

	    var fingerbox = new Fingerbox();
	    Console.WriteLine("Frobnication: {0}", fingerbox.Frobnicate());
	    fingerbox.Toggle();
	    Console.WriteLine("Frobnication: {0}", fingerbox.Frobnicate());
	    fingerbox.ToggleOff();
	    fingerbox.ToggleOn();
	    Console.WriteLine("Fingerbox on: {0}", fingerbox.IsOn());
	}
    }
}
