using InitManage.Helpers.Interfaces;

namespace InitManage.Platforms.Windows.Helpers;

public class WindowsNotificationHelper : INotificationHelper
{
	public event EventHandler NotificationReceived;

	public void Initialize()
	{
	}

	public void ReceiveNotification(string title, string message)
	{
	}

	public void SendNotification(string title, string message, DateTime? notifyTime = null)
	{
	}
}
