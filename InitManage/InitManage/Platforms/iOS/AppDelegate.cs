using Foundation;
using InitManage.Platforms.iOS.Helpers;
using UserNotifications;

namespace InitManage;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();


    [Export("application:didFinishLaunchingWithOptions:")]
    public bool FinishedLaunching(UIKit.UIApplication application, NSDictionary launchOptions)
    {
        UNUserNotificationCenter.Current.Delegate = new iOSNotificationReceiver();
        return base.FinishedLaunching(application, launchOptions);
    }

}

