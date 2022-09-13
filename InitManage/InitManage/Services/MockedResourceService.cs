using System;
using InitManage.Commons.Enums;
using InitManage.Models.Entities;
using InitManage.Models.Interfaces;
using InitManage.Services.Interfaces;

namespace InitManage.Services;

public class MockedResourceService : IResourceService
{
    public async Task<IResource> GetResourceAsync(long id)
    {
        var resource = new ResourceEntity
        {
            Id = 1,
            Capacity = 18,
            Description = "Cette salle de réunion est une salle très spacieuse et lumineuse. Elle se situe au 3ème étage d’un batiment neuf.",
            Image = "https://blog.1001salles.com/wp-content/uploads/2015/04/preparer-sa-salle.jpg",
            Name = "Salle de réunion " + id,
            Type = ResourceType.MeetingRoom
        };

        return resource;
    }

    public async Task<IEnumerable<IResource>> GetResourcesAsync()
    {
        var resources = new List<ResourceEntity>();

        for (int i = 1; i <= 50; i++)
        {
            var resource = new ResourceEntity
            {
                Id = i,
                Name = $"Salle de réunion {i}",
                Description = $"Description de la salle de réunion n°{i}",
                Image = "https://blog.1001salles.com/wp-content/uploads/2015/04/preparer-sa-salle.jpg",
                Type = ResourceType.MeetingRoom,
                Capacity = new Random().Next(2, 10)
            };
            resources.Add(resource);
        }
        return resources;
    }
}

