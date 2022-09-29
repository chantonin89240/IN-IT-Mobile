using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using DynamicData;
using InitManage.Models.Wrappers;
using InitManage.Services.Interfaces;
using ReactiveUI;
using Sharpnado.TaskLoaderView;

namespace InitManage.ViewModels.Resource;

public class MyResourcesViewModel : BaseViewModel
{
    private readonly IResourceService _resourceService;

    public MyResourcesViewModel(
        INavigationService navigationService,
        IResourceService resourceService)
        : base(navigationService)
    {
        _resourceService = resourceService;

        Loader = new TaskLoaderNotifier();

        _resourcesCache
            .Connect()
            .Bind(out _resources)
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe();
    }

    #region Life cycle


    protected override async Task OnAppearingAsync()
    {
        if (!_resourcesCache.Items.Any())
        {
            Loader.Load(async _ =>
            {
                LoadingMessage = "Récupération des réservations";
                var resource = await _resourceService.GetResourcesAsync();
                await Task.Delay(5000);

                _resourcesCache.AddOrUpdate(resource.Select(r => new ResourceWrapper(r)));
            });
        }
    }

    #endregion

    #region Properties

    public TaskLoaderNotifier Loader { get; }

    #region Dynamic list Resources
    private SourceCache<ResourceWrapper, long> _resourcesCache = new SourceCache<ResourceWrapper, long>(r => r.Id);
    private readonly ReadOnlyObservableCollection<ResourceWrapper> _resources;
    public ReadOnlyObservableCollection<ResourceWrapper> Resources => _resources;
    #endregion



    #endregion

    #region Methods & Commands

    #endregion
}

