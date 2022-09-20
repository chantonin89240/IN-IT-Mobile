using CommunityToolkit.Maui;
using CsharpTools.Services;
using CsharpTools.Services.Interfaces;
using InitManage.Helpers.Interfaces;
using InitManage.Services;
using InitManage.Services.Interfaces;
using InitManage.ViewModels.Login;
using InitManage.ViewModels.Resource;
using InitManage.ViewModels.Setting;
using InitManage.Views.Pages;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Shared;
using Plugin.Firebase.Auth;

#if IOS
using InitManage.Platforms.iOS.Helpers;
using Plugin.Firebase.iOS;
#elif ANDROID
using InitManage.Platforms.Android.Helpers;
using Plugin.Firebase.Android;
#elif MACCATALYST
using InitManage.Platforms.MacCatalyst.Helpers;
#endif

namespace InitManage;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UsePrism(prismAppBuilder => prismAppBuilder
                .RegisterTypes(containerRegistry =>
                {
                    containerRegistry.RegisterServices();
                    containerRegistry.RegisterNavigation();
                    containerRegistry.RegisterHelpers();
                })
                .OnAppStart(navigationService => navigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(LoginPage)}"))
                )
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit()
            .RegisterFirebaseServices();

        return builder.Build();
    }

    private static void RegisterHelpers(this IContainerRegistry containerRegistry)
    {
		#if ANDROID
		containerRegistry.RegisterSingleton<INotificationHelper, AndroidNotificationHelper>();
		#elif IOS
		containerRegistry.RegisterSingleton<INotificationHelper, iOSNotificationHelper>();
		#endif
	}

	private static void RegisterServices(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IAlertDialogService, CommunityToolKitAlertDialogService>();
        containerRegistry.RegisterSingleton<IHttpService, HttpService>();
        containerRegistry.RegisterSingleton<IResourceService, ResourceService>();
    }

    private static void RegisterNavigation(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
        containerRegistry.RegisterForNavigation<ResourcesPage, ResourcesViewModel>();
        containerRegistry.RegisterForNavigation<MyResourcesPage, MyResourcesViewModel>();
        containerRegistry.RegisterForNavigation<ResourcePage, ResourceViewModel>();
        containerRegistry.RegisterForNavigation<SettingsPage, SettingsViewModel>();
        containerRegistry.RegisterForNavigation<CreateResourcePage, CreateResourceViewModel>();

        containerRegistry.RegisterForNavigation<MainTabbedPage>();
        containerRegistry.RegisterForNavigation<NavigationPage>();
    }

    private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events => {
			#if IOS
            events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) => {
                CrossFirebase.Initialize(app, launchOptions, CreateCrossFirebaseSettings());
                return false;
            }));
			#elif ANDROID
            events.AddAndroid(android => android.OnCreate((activity, state) =>
                CrossFirebase.Initialize(activity, state, CreateCrossFirebaseSettings())));
			#endif
        });

        builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
        return builder;
    }

    private static CrossFirebaseSettings CreateCrossFirebaseSettings()
    {
        return new CrossFirebaseSettings(isAuthEnabled: true);
    }
}

