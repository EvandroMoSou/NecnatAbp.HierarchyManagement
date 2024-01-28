using Volo.Abp.Modularity;

namespace NecnatAbp.HierarchyManagement;

[DependsOn(
    typeof(HierarchyManagementApplicationModule),
    typeof(HierarchyManagementDomainTestModule)
    )]
public class HierarchyManagementApplicationTestModule : AbpModule
{

}
