using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace NecnatAbp.HierarchyManagement;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class HierarchyManagementInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<HierarchyManagementInstallerModule>();
        });
    }
}
