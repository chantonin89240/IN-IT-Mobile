using System;
using System.Reactive;
using ReactiveUI;

namespace InitManage.ViewModels.Setting;

public class SettingsViewModel : BaseViewModel
{
    public SettingsViewModel(INavigationService navigationService) : base(navigationService)
    {
        LogoutCommand = ReactiveCommand.CreateFromTask(OnLogoutCommand);

        if (Application.Current.RequestedTheme == AppTheme.Dark) DarkModeEnabled = true;

        Application.Current.RequestedThemeChanged += OnThemeChanged;
    }



    #region Life cycle

    #endregion

    #region Properties

    #region DarkModeEnabled

    private bool _darkModeEnabled;
    public bool DarkModeEnabled
    {
        get => _darkModeEnabled;
        set => this.RaiseAndSetIfChanged(ref _darkModeEnabled, value);
    }

    #endregion

    #endregion

    #region Methods & Commands

    #region OnLogoutCommand
    public ReactiveCommand<Unit, Unit> LogoutCommand { get; private set; }
    private async Task OnLogoutCommand() =>  await NavigationService.GoBackToRootAsync();
    #endregion

    #region OnThemeChanged
    private void OnThemeChanged(object sender, AppThemeChangedEventArgs e) => DarkModeEnabled = e?.RequestedTheme == AppTheme.Dark;
    #endregion

    #endregion
}

