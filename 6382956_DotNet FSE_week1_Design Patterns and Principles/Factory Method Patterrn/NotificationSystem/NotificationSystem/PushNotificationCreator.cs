public class PushNotificationCreator : NotificationCreator
{
    public override INotification CreateNotification()
    {
        return new PushNotification();
    }
}