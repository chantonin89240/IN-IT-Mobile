using InitManage.Models.DTOs;
using InitManage.Models.Interfaces;
using System;
using System.Net;

namespace InitManage.Services.Interfaces;

public interface IResourceService
{
    Task<IEnumerable<IResource>> GetResources();
    Task<HttpStatusCode> CreateResources(ResourceDTOCreate DTO);
}

