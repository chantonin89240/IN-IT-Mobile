using System;
using InitManage.Models.Entities;
using InitManage.Models.Interfaces;
using InitManage.Services.Interfaces;

namespace InitManage.Services;

public class MockedResourceService : IResourceService
{

    public async Task<IEnumerable<IResource>> GetResources()
    {
        var resources = new List<ResourceEntity>();

        for (int i = 0; i < 30; i++)
        {
            var resource = new ResourceEntity
            {
                Id = i,
                Name = $"Salle de réunion {i}",
                Description = $"Description de la salle de réunion n°{i}",
                Image = "https://blog.1001salles.com/wp-content/uploads/2015/04/preparer-sa-salle.jpg",
                Type = "Salle de réunion",
                Capacity = new Random().Next(2, 10)
            };
            resources.Add(resource);
        }
        return resources;
    }
}

