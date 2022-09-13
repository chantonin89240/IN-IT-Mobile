using System;
namespace InitManage.Models.Wrappers;

public class NotificationEventArgs : EventArgs
{
    public string Title { get; set; }
    public string Message { get; set; }
}

