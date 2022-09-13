using System;
using System.Reactive;
using InitManage.Commons;
using InitManage.Models.Interfaces;
using InitManage.Services.Interfaces;
using ReactiveUI;

namespace InitManage.ViewModels.Resource;

public class ResourceViewModel : BaseViewModel
{
    private readonly IResourceService _resourceService;

    public ResourceViewModel(INavigationService navigationService, IResourceService resourceService) : base(navigationService)
    {
        _resourceService = resourceService;
    }


    #region Life cycle
    protected override async Task OnNavigatedToAsync(INavigationParameters parameters)
    {
        await base.OnNavigatedToAsync(parameters);

        if (parameters.TryGetValue(Constants.ResourceIdNavigationParameter, out long resourceId))
        {
            Resource = await _resourceService.GetResourceAsync(resourceId);
        }
        else
            await NavigationService.GoBackAsync();
    }
    #endregion

    #region Properties

    #region Resource

    private IResource _resource;
    public IResource Resource
    {
        get => _resource;
        set => this.RaiseAndSetIfChanged(ref _resource, value);
    }

    #endregion

    #endregion

    #region Methods & Commands

    #region OnResourceTappedCommand



    #endregion

    #endregion
}

