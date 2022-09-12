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

#if IOS
using InitManage.Platforms.iOS.Helpers;
#elif ANDROID
using InitManage.Platforms.Android.Helpers;
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
            }).UseMauiCommunityToolkit();

        return builder.Build();
    }

    private static void RegisterHelpers(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<INotificationHelper, NotificationHelper>();
    }

    private static void RegisterServices(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IAlertDialogService, CommunityToolKitAlertDialogService>();
        containerRegistry.RegisterSingleton<IHttpService, HttpService>();
        containerRegistry.RegisterSingleton<IResourceService, MockedResourceService>();
    }

    private static void RegisterNavigation(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
        containerRegistry.RegisterForNavigation<ResourcesPage, ResourcesViewModel>();
        containerRegistry.RegisterForNavigation<MyResourcesPage, MyResourcesViewModel>();
        containerRegistry.RegisterForNavigation<ResourcePage, ResourceViewModel>();
        containerRegistry.RegisterForNavigation<SettingsPage, SettingsViewModel>();

        containerRegistry.RegisterForNavigation<MainTabbedPage>();
        containerRegistry.RegisterForNavigation<NavigationPage>();
    }
}

