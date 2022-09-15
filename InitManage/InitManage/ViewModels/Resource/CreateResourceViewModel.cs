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
using InitManage.Views.Pages;

namespace InitManage.ViewModels.Resource;

public class CreateResourceViewModel : BaseViewModel
{
    private readonly IResourceService _resourceService;

    public CreateResourceViewModel(INavigationService navigationService, IResourceService resourceService) : base(navigationService)
    {
        _resourceService = resourceService;
        CreateCommand = ReactiveCommand.CreateFromTask(OnCreateCommand);

        Types = new List<string>() { "Salle de réunion", "Salle de classe", "Voiture" };
        Picture = "https://image.jimcdn.com/app/cms/image/transf/dimension=940x10000:format=jpg/path/s398965e309713775/image/ia5d911c472440089/version/1478270869/image.jpg";
    }

    #region Life cycle


    #endregion

    #region Properties

    #region Picture

    private string _picture;
    public string Picture
    {
        get => _picture;
        set => this.RaiseAndSetIfChanged(ref _picture, value);
    }

    #endregion

    #region Name

    private string _name;
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    #endregion

    #region Description

    private string _description;
    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    #endregion

    #region Capacity

    private int _capacity;
    public int Capacity
    {
        get => _capacity;
        set => this.RaiseAndSetIfChanged(ref _capacity, value);
    }

    #endregion

    #region Type

    private string _type;
    public string Type
    {
        get => _type;
        set => this.RaiseAndSetIfChanged(ref _type, value);
    }

    #endregion

    #region Types

    private IEnumerable<string> _types;
    public IEnumerable<string> Types
    {
        get => _types;
        set => this.RaiseAndSetIfChanged(ref _types, value);
    }

    #endregion

    #endregion

    #region Methods & Commands

    #region OnCreateCommand

    public ReactiveCommand<Unit, Unit> CreateCommand { get; private set; }
    private async Task OnCreateCommand()
    {
        var resource = new ResourceEntity()
        {
            Id = 0,
            Name = _name,
            Capacity = _capacity,
            Description = _description,
            Image = _picture,
            Address = "",
            Type = ResourceType.All
        };

        var resourceCreated = await _resourceService.CreateResource(resource);

        if (resourceCreated)
            await NavigationService.NavigateAsync($"{nameof(MainTabbedPage)}?selectedTab={nameof(ResourcesPage)}");
    }

    #endregion


    #endregion
}