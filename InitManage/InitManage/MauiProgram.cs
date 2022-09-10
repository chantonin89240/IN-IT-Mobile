using CommunityToolkit.Maui;
using InitManage.Services;
using InitManage.Services.Interfaces;
using InitManage.ViewModels.Login;
using InitManage.Views.Pages;

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

    private static void RegisterServices(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IAlertDialogService, CommunityToolKitAlertDialogService>();
    }

    private static void RegisterNavigation(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
    }
}

