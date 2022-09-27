using InitManage.Commons;
using InitManage.Models.DTOs;
using InitManage.Models.Interfaces;
using InitManage.Services.Interfaces;
using Simple.Http;

namespace InitManage.Services;

public class TypeService : ITypeService
{
	private readonly IHttpService _httpService;
	public TypeService(IHttpService httpService)
	{
		_httpService = httpService;
	}

	public async Task<IEnumerable<IType>> GetTypesAsync()
	{
		var response = await _httpService.SendRequestAsync<IEnumerable<TypeDTO>>($"{Constants.ApiBaseAdress}{Constants.TypeEndPoint}", HttpMethod.Get);
		return response?.Result;
	}
}
