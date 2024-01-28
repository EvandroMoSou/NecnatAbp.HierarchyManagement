using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace NecnatAbp.HierarchyManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(HierarchyManagementBlazorModule)
    )]
public class HierarchyManagementBlazorServerModule : AbpModule
{

}
