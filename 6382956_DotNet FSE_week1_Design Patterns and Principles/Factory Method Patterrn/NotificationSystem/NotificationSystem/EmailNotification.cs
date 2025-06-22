public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Sending Email Notification: " + message);
    }
}