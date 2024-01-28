using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace NecnatAbp.HierarchyManagement;

[DependsOn(
    typeof(HierarchyManagementDomainModule),
    typeof(HierarchyManagementApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class HierarchyManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //context.Services.AddAutoMapperObjectMapper<HierarchyManagementApplicationModule>();
        //Configure<AbpAutoMapperOptions>(options =>
        //{
        //    options.AddMaps<HierarchyManagementApplicationModule>(validate: true);
        //});
    }
}
