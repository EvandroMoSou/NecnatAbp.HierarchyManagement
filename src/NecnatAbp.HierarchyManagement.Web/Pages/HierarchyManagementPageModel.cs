using NecnatAbp.HierarchyManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace NecnatAbp.HierarchyManagement.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class HierarchyManagementPageModel : AbpPageModel
{
    protected HierarchyManagementPageModel()
    {
        LocalizationResourceType = typeof(HierarchyManagementResource);
        ObjectMapperContext = typeof(HierarchyManagementWebModule);
    }
}
