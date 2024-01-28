using NecnatAbp.HierarchyManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace NecnatAbp.HierarchyManagement;

public abstract class HierarchyManagementController : AbpControllerBase
{
    protected HierarchyManagementController()
    {
        LocalizationResource = typeof(HierarchyManagementResource);
    }
}
