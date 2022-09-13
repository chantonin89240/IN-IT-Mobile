using System;
using InitManage.Commons.Enums;
using InitManage.Models.Interfaces;

namespace InitManage.Models.Wrappers;

public class ResourceWrapper : IResource, ISearchable
{
    public ResourceWrapper()
    {
    }

    public ResourceWrapper(IResource resource)
    {
        Id = resource.Id;
        Name = resource.Name;
        Description = resource.Description;
        Image = resource.Image;
        Type = resource.Type;
        Capacity = resource.Capacity;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public ResourceType Type { get; set; }
    public int Capacity { get; set; }

    public bool IsCorrespondingToSearch(string searchedValue)
    {
        var nameIsMatching = Name?.ToLower()?.Contains(searchedValue?.ToLower()) ?? false;
        var descriptionIsMatching = Description?.ToLower()?.Contains(searchedValue?.ToLower()) ?? false;

        return nameIsMatching && descriptionIsMatching;
    }
}

