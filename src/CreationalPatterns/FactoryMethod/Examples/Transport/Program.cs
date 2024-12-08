public interface ITransport
{
    void Deliver();
    int CargaMaxima { get; }
}

public class Truck : ITransport
{
    public void Deliver()
    {
        Console.WriteLine($"Truck is delivering - Carga máxima:- {CargaMaxima} Kg");
    }

    public int CargaMaxima => 1500;
}

public class Bike : ITransport
{
    public void Deliver()
    {
        Console.WriteLine($"Bike is delivering - Carga máxima:- {CargaMaxima} Kg");
    }

    public int CargaMaxima => 30;
}

public abstract class TransportFactory
{
    public abstract ITransport CreateTransport();
}

public class TruckFactory : TransportFactory
{
    public override ITransport CreateTransport()
    {
        return new Truck();
    }
}

public class BikeFactory : TransportFactory
{
    public override ITransport CreateTransport()
    {
        return new Bike();
    }
}

class Program
{
    static void Main(string[] args)
    {
        TransportFactory truckFactory = new TruckFactory();
        ITransport truck = truckFactory.CreateTransport();
        truck.Deliver();
        
        TransportFactory bikeFactory = new BikeFactory();
        ITransport bike = bikeFactory.CreateTransport();
        bike.Deliver();
    }
}