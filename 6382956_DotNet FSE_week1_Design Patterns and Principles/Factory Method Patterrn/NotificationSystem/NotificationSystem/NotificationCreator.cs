public abstract class NotificationCreator
{
    public abstract INotification CreateNotification();

    public void Notify(string message)
    {
        INotification notification = CreateNotification();
        notification.Send(message);
    }
}