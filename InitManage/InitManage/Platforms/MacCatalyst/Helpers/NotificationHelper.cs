using System;
using InitManage.Helpers.Interfaces;

namespace InitManage.Platforms.MacCatalyst.Helpers;

public class NotificationHelper : INotificationHelper
{
    public NotificationHelper()
    {
    }

    public event EventHandler NotificationReceived;

    public void Initialize()
    {
        throw new NotImplementedException();
    }

    public void ReceiveNotification(string title, string message)
    {
        throw new NotImplementedException();
    }

    public void SendNotification(string title, string message, DateTime? notifyTime = null)
    {
        throw new NotImplementedException();
    }
}

