using NecnatAbp.HierarchyManagement.Localization;
using Volo.Abp.Application.Services;

namespace NecnatAbp.HierarchyManagement;

public abstract class HierarchyManagementAppService : ApplicationService
{
    protected HierarchyManagementAppService()
    {
        LocalizationResource = typeof(HierarchyManagementResource);
        ObjectMapperContext = typeof(HierarchyManagementApplicationModule);
    }
}
