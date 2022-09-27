using System;
using InitManage.Models.Interfaces;

namespace InitManage.Services.Interfaces;

public interface IOptionService
{
    Task<IEnumerable<IOptionEntity>> GetOptionsAsync();
}

