using System;
using ReactiveUI;
using InitManage.Models.Entities;
using DynamicData;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using InitManage.Services.Interfaces;

namespace InitManage.ViewModels.Resource;

public class ResourcesViewModel : BaseViewModel
{
    private readonly IResourceService _resourceService;

    public ResourcesViewModel(INavigationService navigationService, IResourceService resourceService) : base(navigationService)
    {
        _resourceService = resourceService;

        _resourcesCache
            .Connect()
            .Bind(out _resources)
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe();
    }

    #region Life cycle

    protected override async Task OnNavigatedToAsync(INavigationParameters parameters)
    {
        await base.OnNavigatedToAsync(parameters);

        var resources = await _resourceService.GetResources();
        _resourcesCache.AddOrUpdate(resources.Select(x => new ResourceEntity(x)));
    }

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

    #region Dynamic list Resources
    private SourceCache<ResourceEntity, long> _resourcesCache = new SourceCache<ResourceEntity, long>(r => r.Id);
    private readonly ReadOnlyObservableCollection<ResourceEntity> _resources;
    public ReadOnlyObservableCollection<ResourceEntity> Resources => _resources;
    #endregion

    #endregion

    #region Methods & Commands

    #endregion
}

