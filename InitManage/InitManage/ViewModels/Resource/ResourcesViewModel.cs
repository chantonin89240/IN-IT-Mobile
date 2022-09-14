using System;
using ReactiveUI;
using InitManage.Models.Entities;
using DynamicData;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using InitManage.Services.Interfaces;
using System.Reactive;
using InitManage.Models.Wrappers;
using DynamicData.PLinq;
using InitManage.Commons.Enums;

namespace InitManage.ViewModels.Resource;

public class ResourcesViewModel : BaseViewModel
{
    private readonly IResourceService _resourceService;

    public ResourcesViewModel(INavigationService navigationService, IResourceService resourceService) : base(navigationService)
    {
        _resourceService = resourceService;

        var searchFilter = this.WhenAnyValue(vm => vm.SearchBarText)
        .Select(query =>
        {
            if (!string.IsNullOrEmpty(query))
                return new Func<ResourceWrapper, bool>(resource => resource.IsCorrespondingToSearch(SearchBarText));
            else
                return new Func<ResourceWrapper, bool>(resource => true);
        });

        var capacityFilter = this.WhenAnyValue(vm => vm.SelectedCapacity)
            .Select(query =>
            {
                return new Func<ResourceWrapper, bool>(resource => resource.Capacity >= query);
            });

        _resourcesCache
        .Connect()
        .Filter(searchFilter)
        .Filter(capacityFilter)
        .Bind(out _resources)
        .ObserveOn(RxApp.MainThreadScheduler)
        .Subscribe();
    }

    #region Life cycle

    protected override async Task OnNavigatedToAsync(INavigationParameters parameters)
    {
        await base.OnNavigatedToAsync(parameters);

        var resources = await _resourceService.GetResources();
        _resourcesCache.AddOrUpdate(resources.Select(x => new ResourceWrapper(x)));

        ResourcesCapacities = resources.Select(r => r.Capacity).OrderBy(x => x).Distinct().ToList();

        ResourcesTypes = resources.Select(r => r.Type).OrderBy(x => x).Distinct().ToList();
        ResourcesTypes.Add(ResourceType.All);
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
    private SourceCache<ResourceWrapper, long> _resourcesCache = new SourceCache<ResourceWrapper, long>(r => r.Id);
    private readonly ReadOnlyObservableCollection<ResourceWrapper> _resources;
    public ReadOnlyObservableCollection<ResourceWrapper> Resources => _resources;
    #endregion

    #region ResourcesCapacities

    private List<int> _resourcesCapacities;
    public List<int> ResourcesCapacities
    {
        get => _resourcesCapacities;
        set => this.RaiseAndSetIfChanged(ref _resourcesCapacities, value);
    }

    #endregion

    #region ResourcesTypes

    private List<ResourceType> _resourcesTypes;
    public List<ResourceType> ResourcesTypes
    {
        get => _resourcesTypes;
        set => this.RaiseAndSetIfChanged(ref _resourcesTypes, value);
    }

    #endregion

    #region SelectedType

    private ResourceType _selectedType;
    public ResourceType SelectedType
    {
        get => _selectedType;
        set => this.RaiseAndSetIfChanged(ref _selectedType, value);
    }

    #endregion

    #region SelectedCapacity

    private int _selectedCapacity;
    public int SelectedCapacity
    {
        get => _selectedCapacity;
        set => this.RaiseAndSetIfChanged(ref _selectedCapacity, value);
    }

    #endregion

    #endregion

    #region Methods & Commands

    #endregion
}

