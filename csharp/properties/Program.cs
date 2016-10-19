/*
  Properties example
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Properties
{
    class Phone
    {
	//Automatic property declarations
	public string Model   { get; set; }
	public string Brand   { get; set; }
	public string OS      { get; set; }
	public int    Version { get; set; } = 0; //Example of a default value for this property
	
	//Constructor with default values
	public Phone()
	{
	    Model = default(string);
	    Brand = default(string);
	    OS    = default(string);
	}

	//Constructor with parameter values
	public Phone(string _model, string _brand, string _os, int _version)
	{
	    Model   = _model;
	    Brand   = _brand;
	    OS      = _os;
	    Version = _version;
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

	    Console.WriteLine("Properties example - Copyright 2016, Sjors van Gelderen");
	    
	    Phone phone_0 = new Phone();
	    phone_0.Model   = "iPhone";
	    phone_0.Brand   = "Apple";
	    phone_0.OS      = "iOS";
	    phone_0.Version = 9;

	    Console.WriteLine("Phone 0 - Model: {0}, Brand: {1}, OS: {2}, Version: {3}",
			      phone_0.Model,
			      phone_0.Brand,
			      phone_0.OS,
			      phone_0.Version);

	    Phone phone_1 = new Phone("Moto G4", "Lenovo", "Android", 6);
	    
	    Console.WriteLine("Phone 1 - Model: {0}, Brand: {1}, OS: {2}, Version: {3}",
			      phone_1.Model,
			      phone_1.Brand,
			      phone_1.OS,
			      phone_1.Version);
	}
    }
}
