using System;
using System.Reactive;
using InitManage.Views.Pages;
using ReactiveUI;

namespace InitManage.ViewModels.Login;

public class LoginViewModel : BaseViewModel
{
    public LoginViewModel(INavigationService navigationService) : base(navigationService)
    {
        LoginCommand = ReactiveCommand.CreateFromTask(OnLoginCommand);
    }

    #region Life cycle

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
        Application.Current.MainPage = new MainTabbedPage();
    }
    #endregion

    #endregion
}

