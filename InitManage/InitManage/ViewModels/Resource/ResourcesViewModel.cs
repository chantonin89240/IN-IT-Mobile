using System;
using ReactiveUI;

namespace InitManage.ViewModels.Resource;

public class ResourcesViewModel : BaseViewModel
{
    public ResourcesViewModel(INavigationService navigationService) : base(navigationService)
    {
    }

    #region Life cycle
    protected override Task OnNavigatedFromAsync(INavigationParameters parameters)
    {
        return base.OnNavigatedFromAsync(parameters);
    }
    #endregion

    #region Properties

    #region SearchBarText
    private string _searchBarText;
    public string SearchBarText
    {
        get => _searchBarText;
        set => this.RaiseAndSetIfChanged(ref _searchBarText, value);
    }
    #endregion

    #region Places

    private IEnumerable<int> _places;
    public IEnumerable<int> Places
    {
        get => _places;
        set => this.RaiseAndSetIfChanged(ref _places, value);
    }

    #endregion

    #region Adress

    private string _adress;
    public string Adress
    {
        get => _adress;
        set => this.RaiseAndSetIfChanged(ref _adress, value);
    }

    #endregion

    #endregion

    #region Methods & Commands

    #endregion
}

