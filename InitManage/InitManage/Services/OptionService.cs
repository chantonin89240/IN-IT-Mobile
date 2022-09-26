using System;
using InitManage.Models.DTOs;
using InitManage.Models.Interfaces;
using InitManage.Services.Interfaces;
using Simple.Http;
using InitManage.Commons;

namespace InitManage.Services;

public class OptionService : IOptionService
{
    private readonly IHttpService _httpService;

    public OptionService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<IEnumerable<IOption>> GetOptionsAsync()
    {
        var response = await _httpService.SendHttpRequest<IEnumerable<OptionDTO>>($"{Constants.ApiBaseAdress}{Constants.OptionEndPoint}", HttpMethod.Get);
        return response?.Result;
    }
}

