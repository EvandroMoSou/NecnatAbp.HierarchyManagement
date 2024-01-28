using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace NecnatAbp.HierarchyManagement;

[DependsOn(
    typeof(HierarchyManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class HierarchyManagementApplicationContractsModule : AbpModule
{

}
