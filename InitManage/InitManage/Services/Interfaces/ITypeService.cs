using InitManage.Models.Interfaces;

namespace InitManage.Services.Interfaces;

public interface ITypeService
{
	Task<IEnumerable<ITypeEntity>> GetTypesAsync();
}
