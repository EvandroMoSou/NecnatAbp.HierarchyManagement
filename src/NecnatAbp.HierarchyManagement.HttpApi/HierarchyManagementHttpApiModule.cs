using Localization.Resources.AbpUi;
using NecnatAbp.HierarchyManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace NecnatAbp.HierarchyManagement;

[DependsOn(
    typeof(HierarchyManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class HierarchyManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(HierarchyManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<HierarchyManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
