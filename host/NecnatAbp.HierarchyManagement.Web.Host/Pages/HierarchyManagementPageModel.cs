using NecnatAbp.HierarchyManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace NecnatAbp.HierarchyManagement.Pages;

public abstract class HierarchyManagementPageModel : AbpPageModel
{
    protected HierarchyManagementPageModel()
    {
        LocalizationResourceType = typeof(HierarchyManagementResource);
    }
}
