using System;
using System.Reactive;
using InitManage.Helpers.Interfaces;
using InitManage.Services.Interfaces;
using InitManage.Views.Pages;
using Plugin.Firebase.CloudMessaging;
using ReactiveUI;

namespace InitManage.ViewModels.Login;

public class LoginViewModel : BaseViewModel
{
    private readonly IAlertDialogService _alertDialogService;
    private readonly INotificationHelper _notificationHelper;
    private readonly IPreferenceHelper _preferenceHelper;
    private readonly IUserService _userService;

    public LoginViewModel(
        INavigationService navigationService,
        IAlertDialogService alertDialogService,
        INotificationHelper notificationHelper,
        IPreferenceHelper preferenceHelper,
        IUserService userService)
        : base(navigationService)
    {
        _alertDialogService = alertDialogService;
        _notificationHelper = notificationHelper;
        _preferenceHelper = preferenceHelper;
        _userService = userService;

        LoginCommand = ReactiveCommand.CreateFromTask(OnLoginCommand);
    }

    #region Life cycle

    protected override async Task OnNavigatedToAsync(INavigationParameters parameters)
    {
        await base.OnNavigatedToAsync(parameters);
        _notificationHelper.Initialize();
    }

    #endregion

    #region Properties

    #region Mail
    private string _mail;
    public string Mail
    {
        get => _mail;
        set => this.RaiseAndSetIfChanged(ref _mail, value);
    }
    #endregion

    #region Password
    private string _password;
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }
    #endregion

    #endregion

    #region Methods & Commands

    #region OnLoginCommand

    public ReactiveCommand<Unit, Unit> LoginCommand { get; }
    private async Task OnLoginCommand()
    {
        var isLoginSuccess = await _userService.LoginAsync(Mail, Password);

        if (isLoginSuccess)
        {
            await NavigationService.NavigateAsync($"{nameof(MainTabbedPage)}");
        }
    }
    #endregion


    #endregion
}

