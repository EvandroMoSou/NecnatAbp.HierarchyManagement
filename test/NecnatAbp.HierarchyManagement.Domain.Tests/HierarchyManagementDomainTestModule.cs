using Volo.Abp.Modularity;

namespace NecnatAbp.HierarchyManagement;

[DependsOn(
    typeof(HierarchyManagementDomainModule),
    typeof(HierarchyManagementTestBaseModule)
)]
public class HierarchyManagementDomainTestModule : AbpModule
{

}
