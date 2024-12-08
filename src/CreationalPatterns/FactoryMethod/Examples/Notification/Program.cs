public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Email Notification: {message}");
    }
}

public class SmsNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS Notification: {message}");
    }
}

public abstract class NotificationFactory
{
    public abstract INotification CreateNotification();
}

public class EmailNotificationFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new EmailNotification();
    }
}

public class SmsNotificationFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new SmsNotification();
    }
}

class Program
{
    static void Main(string[] args)
    {
        NotificationFactory emailFactory = new EmailNotificationFactory();
        INotification emailNotification = emailFactory.CreateNotification();
        emailNotification.Send("Hello World!");
        
        
        NotificationFactory smsFactory = new SmsNotificationFactory();
        INotification smsNotification = smsFactory.CreateNotification();
        smsNotification.Send("Hello World!");

    }
}