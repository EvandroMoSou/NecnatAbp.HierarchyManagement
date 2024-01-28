using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace NecnatAbp.HierarchyManagement.Blazor.WebAssembly;

[DependsOn(
    typeof(HierarchyManagementBlazorModule),
    typeof(HierarchyManagementHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class HierarchyManagementBlazorWebAssemblyModule : AbpModule
{

}
