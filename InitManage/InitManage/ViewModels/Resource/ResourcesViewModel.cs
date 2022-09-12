using System;
using ReactiveUI;
using InitManage.Models.Entities;
using DynamicData;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using InitManage.Services.Interfaces;
using System.Reactive;

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

        SearchCommand = ReactiveCommand.CreateFromTask(OnSearchCommand);
    }

    #region Life cycle

    protected override async Task OnNavigatedToAsync(INavigationParameters parameters)
    {
        await base.OnNavigatedToAsync(parameters);

        var resources = await _resourceService.GetResources();
        _resourcesCache.AddOrUpdate(resources.Select(x => new ResourceEntity(x)));

        Capacities = resources.Select(r => r.Capacity).OrderBy(x => x).Distinct().ToList();
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

    #region Capacities

    private IEnumerable<int> _capacities;
    public IEnumerable<int> Capacities
    {
        get => _capacities;
        set => this.RaiseAndSetIfChanged(ref _capacities, value);
    }

    #endregion

    #endregion

    #region Methods & Commands


    #region OnSearchCommand

    public ReactiveCommand<Unit, Unit> SearchCommand { get; private set; }
    private async Task OnSearchCommand()
    {
        
    }

    #endregion

    #endregion
}

