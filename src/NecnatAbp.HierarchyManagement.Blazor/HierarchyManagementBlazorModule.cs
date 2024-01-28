using Microsoft.Extensions.DependencyInjection;
using NecnatAbp.HierarchyManagement.Blazor.Menus;
using NecnatAbp.HierarchyManagement;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace NecnatAbp.HierarchyManagement.Blazor;

[DependsOn(
    typeof(HierarchyManagementApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAutoMapperModule)
    )]
public class HierarchyManagementBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<HierarchyManagementBlazorModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<HierarchyManagementBlazorAutoMapperProfile>(validate: true);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new HierarchyManagementMenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(HierarchyManagementBlazorModule).Assembly);
        });

        context.Services.AddSingleton<IHierarchyAutorizationService, HierarchyAutorizationService>();

    }
}
