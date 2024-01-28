using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace NecnatAbp.HierarchyManagement;

[Dependency(ReplaceServices = true)]
public class HierarchyManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "HierarchyManagement";
}
