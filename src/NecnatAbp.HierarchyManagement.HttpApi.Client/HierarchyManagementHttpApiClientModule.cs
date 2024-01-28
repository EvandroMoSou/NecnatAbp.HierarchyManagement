using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace NecnatAbp.HierarchyManagement;

[DependsOn(
    typeof(HierarchyManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class HierarchyManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(HierarchyManagementApplicationContractsModule).Assembly,
            HierarchyManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<HierarchyManagementHttpApiClientModule>();
        });

    }
}
