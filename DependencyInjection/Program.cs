// Interface representing the dependency
public interface IMessageService
{
    void SendMessage(string message);
}

// Concrete implementation of the dependency
public class EmailService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

// Concrete implementation of the dependency
public class SlackService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending Slack: {message}");
    }
}

// Concrete implementation of the dependency
public class TeamsService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending Teams: {message}");
    }
}



// Class that depends on the IMessageService
public class NotificationService
{
    private readonly IMessageService _messageService;

    // Constructor injection
    public NotificationService(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void SendNotification(string message)
    {
        _messageService.SendMessage(message);
    }
}


// Usage example
public class Program
{
    public static void Main()
    {
        // Create an instance of the dependency
        IMessageService emailService = new EmailService();

        // Create an instance of the class with the dependency injected
        NotificationService notificationService = new NotificationService(emailService);
        notificationService.SendNotification("Hello World!");
    }
}