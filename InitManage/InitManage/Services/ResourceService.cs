using System;
using System.Net;
using InitManage.Commons;
using InitManage.Models.DTOs;
using InitManage.Models.Interfaces;
using InitManage.Models.Wrappers;
using InitManage.Services.Interfaces;
using Simple.Http;

namespace InitManage.Services;

public class ResourceService : IResourceService
{
    private readonly IHttpService _httpService;

    public ResourceService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<IResource> GetResourceAsync(long id)
    {
        var response = await _httpService.SendHttpRequest<ResourceDTODown>($"{Constants.ApiBaseAdress}{Constants.ResourceEndPoint}/{id}", HttpMethod.Get);
        return response.Result;
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
        await Task.Delay(3000);
        var response = await _httpService.SendHttpRequest<IEnumerable<ResourceDTODown>>($"{Constants.ApiBaseAdress}{Constants.ResourceEndPoint}", HttpMethod.Get);
        return response.Result;
    }

    public async Task<bool> CreateResource(IResource resource)
    {
        var dto = new ResourceDTODown(resource);
        var result = await _httpService.SendHttpRequest<ResourceDTODown>($"{Constants.ApiBaseAdress}{Constants.ResourceEndPoint}", HttpMethod.Post, dto);
        return result.HttpStatusCode == HttpStatusCode.OK;
    }
}

