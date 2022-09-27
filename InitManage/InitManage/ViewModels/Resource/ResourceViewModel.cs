using System;
using System.Collections.ObjectModel;
using System.Reactive;
using DynamicData;
using InitManage.Commons;
using InitManage.Models.Interfaces;
using InitManage.Models.Wrappers;
using InitManage.Services.Interfaces;
using InitManage.Views.Pages;
using ReactiveUI;
using System.Linq;
using System.Reactive.Linq;

namespace InitManage.ViewModels.Resource;

public class ResourceViewModel : BaseViewModel
{
    private readonly IResourceService _resourceService;

    public ResourceViewModel(INavigationService navigationService, IResourceService resourceService) : base(navigationService)
    {
        _resourceService = resourceService;

        BookCommand = ReactiveCommand.CreateFromTask(OnBookCommand);

        _bookingsCache
            .Connect()
            .Bind(out _bookings)
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe();
    }


    #region Life cycle
    protected override async Task OnNavigatedToAsync(INavigationParameters parameters)
    {
        await base.OnNavigatedToAsync(parameters);

        if (parameters.TryGetValue(Constants.ResourceIdNavigationParameter, out long resourceId))
        {
            Resource = await _resourceService.GetResourceAsync(resourceId);
            var bookings = await _resourceService.GetResourceBookingsWrappersAsync(Resource.Id);

            _bookingsCache.AddOrUpdate(bookings);
        }
        else
            await NavigationService.GoBackAsync();
    }
    #endregion

    #region Properties

    #region Resource

    private IResourceEntity _resource;
    public IResourceEntity Resource
    {
        get => _resource;
        set => this.RaiseAndSetIfChanged(ref _resource, value);
    }

    #endregion

    #region Dynamic list Bookings
    private SourceCache<BookingWrapper, long> _bookingsCache = new SourceCache<BookingWrapper, long>(b => b.Id);
    private readonly ReadOnlyObservableCollection<BookingWrapper> _bookings;
    public ReadOnlyObservableCollection<BookingWrapper> Bookings => _bookings;
    #endregion

    #endregion

    #region Methods & Commands

    #region BookCommand

    public ReactiveCommand<Unit, Unit> BookCommand { get; private set; }
    private async Task OnBookCommand()
    {
        await NavigationService.GoBackAsync();
    }

    #endregion


    #endregion
}

