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

public class CreateResourceViewModel : BaseViewModel
{
    private readonly IResourceService _resourceService;

    public CreateResourceViewModel(INavigationService navigationService, IResourceService resourceService) : base(navigationService)
    {
        _resourceService = resourceService;

	}

    #region Life cycle


    #endregion

    #region Properties
    private async Task CreateResource()
    {
        //await _resourceService.CreateResources();
    }
    #endregion

    #region Methods & Commands

    #endregion
}