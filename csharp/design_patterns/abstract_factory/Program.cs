/*
  Abstract factory design pattern example
  Copyright 2016, Sjors van Gelderen
*/

using System;

namespace Program
{
    // Abstract description of a motor factory
    abstract class MotorFactory
    {
	public abstract Motorcycle CreateMotorcycle();
	public abstract Driver CreateDriver();
    }

    // Abstract description of a motorcycle
    abstract class Motorcycle
    {
	public string ProductID { get; set; }
    }

    // Abstract description of a driver
    abstract class Driver
    {
	public abstract void Drive(Motorcycle _motorcycle);
    }

    // Concrete description of a motorcycle
    class FatBoy : Motorcycle
    {
	public FatBoy()
	{
	    ProductID = "FatBoy";
	}
    }

    // Concrete description of a motorcycle
    class XSR900 : Motorcycle
    {
	public XSR900()
	{
	    ProductID = "XSR900";
	}
    }

    // Concrete description of a human driver
    class HumanDriver : Driver
    {
	public string Name { get; set; }

	public HumanDriver(string _name)
	{
	    Name = _name;
	}
	
	public override void Drive(Motorcycle _motorcycle)
	{
	    Console.WriteLine("{0} is driving the {1}",
			      Name,
			      _motorcycle.ProductID);
	}
    }

    // Concrete description of a robot driver
    class RobotDriver : Driver
    {
	public string ID { get; set; }

	public RobotDriver(string _id)
	{
	    ID = _id;
	}
	
	public override void Drive(Motorcycle _motorcycle)
	{
	    Console.WriteLine("{0} is driving the {1}",
			      ID,
			      _motorcycle.ProductID);
	}
    }

    // Concrete motorcycle factory
    class Yamaha : MotorFactory
    {
	public override Motorcycle CreateMotorcycle()
	{
	    return new XSR900();
	}

	public override Driver CreateDriver()
	{
	    return new HumanDriver("Arnold Schwarzenegger");
	}
    }

    // Another concrete motorcycle factory
    class HarleyDavidson : MotorFactory
    {
	public override Motorcycle CreateMotorcycle()
	{
	    return new FatBoy();
	}
	
	public override Driver CreateDriver()
	{
	    return new RobotDriver("T-800");
	}
    }

    // Client creates and interacts with products according to the supplied factory
    class Client
    {
        private Motorcycle motorcycle;
	private Driver driver;
	
	public Client(MotorFactory _factory)
	{
	    motorcycle = _factory.CreateMotorcycle();
	    driver = _factory.CreateDriver();
	}
	
	public void Run()
	{
	    driver.Drive(motorcycle);
	}
    }
    
    static class Program
    {
	static void Main()
	{
	    Console.WriteLine("Abstract factory design pattern example - "
			      + "Copyright 2016, Sjors van Gelderen"
			      + Environment.NewLine);
	    
	    // Create and run Harley Davidson client
	    var harley_davidson_client = new Client(new HarleyDavidson());
	    harley_davidson_client.Run();

	    // Create and run Yamaha client
	    var yamaha_client = new Client(new Yamaha());
	    yamaha_client.Run();

	    // Both are motorcycle factories, but they produce different products
	}
    }
}
