using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace NecnatAbp.HierarchyManagement.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class HierarchyManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "HierarchyManagement";
}
