using System;
using System.Net;
using System.Threading.Tasks.Sources;
using InitManage.Commons.Enums;
using InitManage.Models.DTOs;
using InitManage.Models.Entities;
using InitManage.Models.Interfaces;
using InitManage.Services.Interfaces;

namespace InitManage.Services;

public class MockedResourceService : IResourceService
{

    public async Task<IEnumerable<IResource>> GetResources()
    {
        var resources = new List<ResourceEntity>();

        for (int i = 1; i <= 5; i++)
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

    public async Task<HttpStatusCode> CreateResources(ResourceDTOCreate DTO)
    {
        var resources = new List<ResourceEntity>();

        for (int i = 1; i <= 5; i++)
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

        var truc = new ResourceEntity
        {
            Id = resources.Count + 1,
            Name = DTO.Name,
            Description = DTO.Description,
            Image = DTO.Picture,
            Type = DTO.Type,
            Capacity = DTO.Capacity
        };
        resources.Add(truc);

        return HttpStatusCode.Created;
    }
}

