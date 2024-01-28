using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace NecnatAbp.HierarchyManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HierarchyManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class HierarchyManagementConsoleApiClientModule : AbpModule
{

}
