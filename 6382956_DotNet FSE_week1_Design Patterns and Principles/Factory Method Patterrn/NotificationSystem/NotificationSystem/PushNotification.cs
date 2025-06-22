public class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Sending Push Notification: " + message);
    }
}