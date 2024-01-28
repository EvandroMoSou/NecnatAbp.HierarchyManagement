using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace NecnatAbp.HierarchyManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(HierarchyManagementDomainSharedModule)
)]
public class HierarchyManagementDomainModule : AbpModule
{

}
