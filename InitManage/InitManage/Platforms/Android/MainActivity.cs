using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using InitManage.Helpers.Interfaces;
using InitManage.Platforms.Android.Helpers;

namespace InitManage;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density, LaunchMode = LaunchMode.SingleTop)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        CreateNotificationFromIntent(Intent);
    }

    protected override void OnNewIntent(Intent intent)
    {
        CreateNotificationFromIntent(intent);
    }

    void CreateNotificationFromIntent(Intent intent)
    {
        if (intent?.Extras != null)
        {
            string title = intent.GetStringExtra(NotificationHelper.TitleKey);
            string message = intent.GetStringExtra(NotificationHelper.MessageKey);
            DependencyService.Get<INotificationHelper>().ReceiveNotification(title, message);
        }
    }

}

