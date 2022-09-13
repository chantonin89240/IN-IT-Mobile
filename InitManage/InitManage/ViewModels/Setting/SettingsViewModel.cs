using System;
using System.Reactive;
using ReactiveUI;

namespace InitManage.ViewModels.Setting;

public class SettingsViewModel : BaseViewModel
{
    public SettingsViewModel(INavigationService navigationService) : base(navigationService)
    {
        LogoutCommand = ReactiveCommand.CreateFromTask(OnLogoutCommand);
    }


    #region Life cycle

    #endregion

    #region Properties

    #region DarkModeEnabled

    private bool _darkModeEnabled;
    public bool DarkModeEnabled
    {
        get => _darkModeEnabled;
        set
        {
            SetDarkMode(value);
            this.RaiseAndSetIfChanged(ref _darkModeEnabled, value);
        }
    }

    #endregion

    #endregion

    #region Methods & Commands

    #region OnLogoutCommand

    public ReactiveCommand<Unit, Unit> LogoutCommand { get; private set; }
    private async Task OnLogoutCommand()
    {
        await NavigationService.GoBackToRootAsync();
    }

    #endregion

    #region SetDarkMode

    private void SetDarkMode(bool darkModeEnabled)
    {
        if (darkModeEnabled)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else
            Application.Current.UserAppTheme = AppTheme.Light;
    }

    #endregion


    #endregion
}

