using InitManage.Models.Interfaces;
using System;

namespace InitManage.Services.Interfaces;

public interface IResourceService
{
    Task<IEnumerable<IResource>> GetResources();
}

