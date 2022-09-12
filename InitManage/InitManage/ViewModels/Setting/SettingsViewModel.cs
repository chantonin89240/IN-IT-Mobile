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

    #endregion

    #region Methods & Commands
    #region OnLogoutCommand

    public ReactiveCommand<Unit, Unit> LogoutCommand { get; private set; }
    private async Task OnLogoutCommand()
    {
        await NavigationService.GoBackToRootAsync();
    }

    #endregion

    #endregion
}

