using System.Collections.Generic;
public class Manufacturer{
    public string Name { get; set; }
    public string Country { get; set; }

    public Manufacturer(string name, string country)
    {
        Name = name;
        Country = country;
    }
}
public class Car
{
    public string Model { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public int Year { get; set; }
    public string LicensePlate { get; set; }
    public string Color { get; set; }

    public Car(string model, Manufacturer manufacturer, int year, string licensePlate, string color)
    {
        Model = model;
        Manufacturer = manufacturer;
        Year = year;
        LicensePlate = licensePlate;
        Color = color;
    }

    public Car Clone()
    {
        Car clone = (Car) this.MemberwiseClone();
        clone.Manufacturer = new Manufacturer(Manufacturer.Name, Manufacturer.Country);
        return clone;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Manufacturer manufacturer = new Manufacturer("Ford", "USA");
        Car car = new Car("Mustang", manufacturer, 2020, "ABC1234", "Red");

        Car carClone = car.Clone();

        Console.WriteLine("Original car:");
        DisplayValues(car);
        Console.WriteLine("Cloned car:");
        DisplayValues(carClone);

        carClone.Manufacturer.Name = "Chevrolet";
        carClone.Color = "Blue";

        Console.WriteLine("Original car:");
        DisplayValues(car);
        Console.WriteLine("Cloned car:");
        DisplayValues(carClone);
    }

    private static void DisplayValues(Car car)
    {
        Console.WriteLine($"Model: {car.Model}");
        Console.WriteLine($"Color: {car.Color}");
        Console.WriteLine($"Year: {car.Year}");
        Console.WriteLine($"License plate: {car.LicensePlate}");
        Console.WriteLine($"Manufacturer: {car.Manufacturer.Name} - {car.Manufacturer.Country}");   
        
    }
}

