public class Employee
{
    public Guid Id { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public int Salary { get; set; }

    public Employee(string name, string role, int salary)
    {
        Id = Guid.NewGuid();
        Name = name;
        Role = role;
        Salary = salary;
        StartDate = DateTime.UtcNow.AddDays(-365);
        EndDate = DateTime.MaxValue;
    }

    public Employee Clone(DateTime startDate)
    {
        Employee clone = (Employee) this.MemberwiseClone();
        clone.Id = Guid.NewGuid();
        clone.StartDate = startDate;
        clone.EndDate = DateTime.MaxValue;
        
        this.EndDate = startDate.AddMilliseconds(-1);

        return clone;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee employee = new Employee("John", "Developer", 1000);
        Employee employeeClone = employee.Clone(DateTime.UtcNow);

        Console.WriteLine("original");
        DisplayValue(employee);
        
        Console.WriteLine("clone");
        DisplayValue(employeeClone);
    }

    private static void DisplayValue(Employee employee)
    {
        Console.WriteLine($"Id: {employee.Id}");
        Console.WriteLine($"Name: {employee.Name}");
        Console.WriteLine($"Role: {employee.Role}");
        Console.WriteLine($"Salary: {employee.Salary}");
        Console.WriteLine($"Start Date: {employee.StartDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
        Console.WriteLine($"End Date: {employee.EndDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
    }
}