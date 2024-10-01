using System;
using ReactiveUI;
using Sharpnado.Tasks;

namespace InitManage.ViewModels;

public abstract class BaseViewModel : ReactiveObject, INavigatedAware, IInitializeAsync, IPageLifecycleAware
{
    public BaseViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }

    #region Properties
    protected INavigationService NavigationService { get; }

    #region LoadingMessage

    private string _loadingMessage;
    public string LoadingMessage
    {
        get => _loadingMessage;
        set => this.RaiseAndSetIfChanged(ref _loadingMessage, value);
    }

    #endregion

    #endregion

    #region LifeCycle

    public Task InitializeAsync(INavigationParameters parameters)
    {
        return Task.FromResult(0);
    }

    public void OnNavigatedTo(INavigationParameters parameters)
    {
        TaskMonitor.Create(OnNavigatedToAsync(parameters),
                           whenFaulted: t => {
                               t.Exception.Handle(ex => {
                                   Console.WriteLine($"OnNavigatedTo error : {ex.Message}");
                                   return true;
                               });
                           });
    }

    protected virtual Task OnNavigatedToAsync(INavigationParameters parameters)
    {
        return Task.FromResult(0);
    }


    public void OnNavigatedFrom(INavigationParameters parameters)
    {
        TaskMonitor.Create(OnNavigatedFromAsync(parameters),
                           whenFaulted: t => {
                               t.Exception.Handle(ex => {
                                   Console.WriteLine($"OnNavigatedFrom error : {ex.Message}");
                                   return true;
                               });
                           });
    }
    protected virtual Task OnNavigatedFromAsync(INavigationParameters parameters)
    {
        return Task.FromResult(0);
    }

    protected virtual Task OnAppearingAsync()
    {
        return Task.FromResult(0);
    }

    public void OnAppearing()
    {
        TaskMonitor.Create(OnAppearingAsync(),
                           whenFaulted: t => {
                               t.Exception.Handle(ex => {
                                   Console.WriteLine($"OnAppearing error : {ex.Message}");
                                   return true;
                               });
                           });
    }

    public void OnDisappearing()
    {
    }

    #endregion
}

