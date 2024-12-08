public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Console Logger: {message}");
    }
}

public class FileLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"File Logger: {message}");
    }
}

public class DatabaseLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Database Logger: {message}");
    }
}

public abstract class LoggerFactory
{
    public abstract ILogger CreateLogger();
}


public class ConsoleLoggerFactory : LoggerFactory
{
    public override ILogger CreateLogger()
    {
        return new ConsoleLogger();
    }
}

public class FileLoggerFactory : LoggerFactory
{
    public override ILogger CreateLogger()
    {
        return new FileLogger();
    }
}

public class DatabaseLoggerFactory : LoggerFactory
{
    public override ILogger CreateLogger()
    {
        return new DatabaseLogger();
    }
}

class Program
{
    static void Main(string[] args)
    {
        LoggerFactory consoleFactory = new ConsoleLoggerFactory();
        ILogger consoleLogger = consoleFactory.CreateLogger();
        consoleLogger.Log("Hello World!");
        
        LoggerFactory fileFactory = new FileLoggerFactory();
        ILogger fileLogger = fileFactory.CreateLogger();
        fileLogger.Log("Hello World!");
        
        LoggerFactory databaseFactory = new DatabaseLoggerFactory();
        ILogger databaseLogger = databaseFactory.CreateLogger();
        databaseLogger.Log("Hello World!");
    }
}