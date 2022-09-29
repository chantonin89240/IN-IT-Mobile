using ReactiveUI;
using DynamicData;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using InitManage.Services.Interfaces;
using System.Reactive;
using InitManage.Models.Wrappers;
using DynamicData.PLinq;
using InitManage.Models.Interfaces;
using InitManage.Views.Pages;
using InitManage.Commons;
using Sharpnado.TaskLoaderView;
using InitManage.Resources.Translations;

namespace InitManage.ViewModels.Resource;

public class ResourcesViewModel : BaseViewModel
{
    private readonly IResourceService _resourceService;
    private readonly IOptionService _optionService;
	private readonly ITypeService _typeService;

    public ResourcesViewModel(
        INavigationService navigationService,
        IResourceService resourceService,
        IOptionService optionService,
		ITypeService typeService) : base(navigationService)
    {
        _resourceService = resourceService;
        _optionService = optionService;
		_typeService = typeService;

        ResourceTappedCommand = ReactiveCommand.Create<IResourceEntity, Task>(OnResourceTappedCommand);
        OptionEntryTappedCommand = ReactiveCommand.CreateFromTask(OnOptionEntryTappedCommand);

        var searchFilter = this.WhenAnyValue(vm => vm.SearchBarText)
            .Select(query =>
            {
                if (!string.IsNullOrEmpty(query))
                    return new Func<ResourceWrapper, bool>(resource => resource.IsCorrespondingToSearch(SearchBarText));
                else
                    return new Func<ResourceWrapper, bool>(resource => true);
            });

        var capacityFilter = this.WhenAnyValue(vm => vm.SelectedCapacity)
            .Select(query => new Func<ResourceWrapper, bool>(resource => resource.Capacity >= query));

        var addressFilter = this.WhenAnyValue(vm => vm.Address)
            .Select(query =>
            {
                if (!string.IsNullOrEmpty(query))
                    return new Func<ResourceWrapper, bool>(resource => resource.Address?.Contains(Address) ?? false);
                return new Func<ResourceWrapper, bool>(resource => true);
            });

        _resourcesCache
            .Connect()
            .Filter(searchFilter)
            .Filter(capacityFilter)
            .Filter(addressFilter)
            .Bind(out _resources)
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe();

        StartDate = DateTime.Now;
        EndDate = DateTime.Now.AddDays(1);
        Loader = new TaskLoaderNotifier();
    }

    #region Life cycle

    protected override async Task OnNavigatedToAsync(INavigationParameters parameters)
    {
        await base.OnNavigatedToAsync(parameters);

        if (!_resourcesCache.Items.Any())
        {
            Loader.Load(async _ =>
            {
                LoadingMessage = AppResources.LoadingResources;
                var resources = await _resourceService.GetResourcesAsync();
                _resourcesCache.AddOrUpdate(resources.Select(r => new ResourceWrapper(r)));

                ResourcesCapacities = resources.Select(r => r.Capacity).OrderBy(x => x).Distinct().ToList();

				LoadingMessage = AppResources.LoadingTypes;
                Types = await _typeService.GetTypesAsync();

                LoadingMessage = AppResources.LoadingOptions;
                Options = (await _optionService.GetOptionsAsync()).Select(option => new OptionWrapper(option));

            });
        }
    }

    #endregion

    #region Properties

    public TaskLoaderNotifier Loader { get; }

    #region IsOptionsVisible

    private bool _isOptionsVisible;
    public bool IsOptionsVisible
    {
        get => _isOptionsVisible;
        set => this.RaiseAndSetIfChanged(ref _isOptionsVisible, value);
    }

    #endregion

    #region SearchBarText
    private string _searchBarText;
    public string SearchBarText
    {
        get => _searchBarText;
        set => this.RaiseAndSetIfChanged(ref _searchBarText, value);
    }
    #endregion

    #region Address

    private string _address;
    public string Address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
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

    #region Options

    private IEnumerable<OptionWrapper> _options;
    public IEnumerable<OptionWrapper> Options
    {
        get => _options;
        set => this.RaiseAndSetIfChanged(ref _options, value);
    }

    #endregion
    
    #region Types

    private IEnumerable<ITypeEntity> _types;
    public IEnumerable<ITypeEntity> Types
    {
        get => _types;
        set => this.RaiseAndSetIfChanged(ref _types, value);
    }

    #endregion

    #region SelectedType

    private string _selectedType;
    public string SelectedType
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

    #region StartDate

    private DateTime _startDate;
    public DateTime StartDate
    {
        get => _startDate;
        set => this.RaiseAndSetIfChanged(ref _startDate, value);
    }

    #endregion

    #region EndDate

    private DateTime _endDate;
    public DateTime EndDate
    {
        get => _endDate;
        set => this.RaiseAndSetIfChanged(ref _endDate, value);
    }

    #endregion

    #endregion

    #region Methods & Commands

    public ReactiveCommand<IResourceEntity, Task> ResourceTappedCommand { get; private set; }
    private async Task OnResourceTappedCommand(IResourceEntity resource)
    {
        var parameters = new NavigationParameters { { Constants.ResourceIdNavigationParameter, resource?.Id } };
        await NavigationService.NavigateAsync(nameof(ResourcePage), parameters);
    }

    #region OnOptionEntryTappedCommand

    public ReactiveCommand<Unit, Unit> OptionEntryTappedCommand { get; private set; }
    private async Task OnOptionEntryTappedCommand()
    {
        IsOptionsVisible = !IsOptionsVisible;
    }

    #endregion


    #endregion
}

