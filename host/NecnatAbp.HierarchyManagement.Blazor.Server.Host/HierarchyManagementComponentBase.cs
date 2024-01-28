using NecnatAbp.HierarchyManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace NecnatAbp.HierarchyManagement.Blazor.Server.Host;

public abstract class HierarchyManagementComponentBase : AbpComponentBase
{
    protected HierarchyManagementComponentBase()
    {
        LocalizationResource = typeof(HierarchyManagementResource);
    }
}
