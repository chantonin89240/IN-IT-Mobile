using System;
using System.Net;
using CsharpTools.Services.Interfaces;
using InitManage.Commons;
using InitManage.Models.DTOs;
using InitManage.Models.Interfaces;
using InitManage.Models.Wrappers;
using InitManage.Services.Interfaces;

namespace InitManage.Services;

public class ResourceService : IResourceService
{
    private readonly IHttpService _httpService;
    public ResourceService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public Task<IResource> GetResourceAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<IBooking>> GetResourceBookingsAsync(long resourceId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookingWrapper>> GetResourceBookingsWrappersAsync(long resourceId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<IResource>> GetResourcesAsync()
    {
        var resutl = await _httpService.SendHttpRequest<IEnumerable<ResourceDTODown>>($"{Constants.ApiBaseAdress}{Constants.ResourceEndPoint}", HttpMethod.Get);
        return resutl.Content;
    }

    public async Task<bool> CreateResource(IResource resource)
    {
        var dto = new ResourceDTODown(resource);
        var result = await _httpService.SendHttpRequest<ResourceDTODown>($"{Constants.ApiBaseAdress}{Constants.ResourceEndPoint}", HttpMethod.Post, dto);
        return result.Status == HttpStatusCode.OK;
    }
}

