using System;
using InitManage.Models.Interfaces;

namespace InitManage.Models.Entities;

public class ResourceEntity : IResource
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Image { get; set; }

    public string Type { get; set; }

    public int Capacity { get; set; }

    public ResourceEntity()
    {
    }

    public ResourceEntity(IResource resource)
    {
        Id = resource.Id;
        Name = resource.Name;
        Description = resource.Description;
        Image = resource.Image;
        Type = resource.Type;
        Capacity = resource.Capacity;
    }
}

