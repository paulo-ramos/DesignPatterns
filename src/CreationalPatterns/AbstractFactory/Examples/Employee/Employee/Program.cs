public interface IEmployeeFactory
{
    IManager CreateManager();
    IWorker CreateWorker();
}

public class EmployeeOfficeFactory : IEmployeeFactory
{
    public IManager CreateManager()
    {
        return new ManagerOffice();
    }

    public IWorker CreateWorker()
    {
        return new WorkerOffice();
    }
}

public class EmployeeSalesFactory : IEmployeeFactory
{
    public IManager CreateManager()
    {
        return new ManagerSales();
    }

    public IWorker CreateWorker()
    {
        return new WorkerSales();
    }
}

public interface IManager
{
    string Hiring();
    string Integration();
    string GrantingBenefits();
    string Dismissal();
}


public interface IWorker
{
    string Hiring();
    string Dismissal();
}

public class ManagerOffice : IManager
{
    public string Hiring()
    {
        return "ManagerOffice: Hiring a worker.";
    }

    public string Integration()
    {
        return "ManagerOffice: Integrating a worker.";
    }

    public string GrantingBenefits()
    {
        return "ManagerOffice: Granting benefits.";
    }

    public string Dismissal()
    {
        return "ManagerOffice: Dismissing a worker.";
    }
}

public class ManagerSales : IManager
{
    public string Hiring()
    {
        return "ManagerSales: Hiring a worker.";
    }

    public string Integration()
    {
        return "ManagerSales: Integrating a worker.";
    }

    public string GrantingBenefits()
    {
        return "ManagerSales: Granting benefits.";
    }

    public string Dismissal()
    {
        return "ManagerSales: Dismissing a worker.";
    }
}


public class WorkerOffice : IWorker
{
    public string Hiring()
    {
        return "WorkerOffice: Hiring.";
    }

    public string Dismissal()
    {
        return "WorkerOffice: Dismissal.";
    }
}



public class WorkerSales : IWorker
{
    public string Hiring()
    {
        return "WorkerSales: Hiring.";
    }

    public string Dismissal()
    {
        return "WorkerSales: Dismissal.";
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("App: Launched with the OfficeFactory.");
        ClientMethod(new EmployeeOfficeFactory());

        Console.WriteLine("");

        Console.WriteLine("App: Launched with the SalesFactory.");
        ClientMethod(new EmployeeSalesFactory());
    }

    public static void ClientMethod(IEmployeeFactory factory)
    {
        var manager = factory.CreateManager();
        var worker = factory.CreateWorker();

        Console.WriteLine(manager.Hiring());
        Console.WriteLine(manager.Integration());
        Console.WriteLine(manager.GrantingBenefits());
        Console.WriteLine(manager.Dismissal());

        Console.WriteLine(worker.Hiring());
        Console.WriteLine(worker.Dismissal());
    }
    
}