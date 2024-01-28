using Volo.Abp.Bundling;

namespace NecnatAbp.HierarchyManagement.Blazor.Host;

public class HierarchyManagementBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
