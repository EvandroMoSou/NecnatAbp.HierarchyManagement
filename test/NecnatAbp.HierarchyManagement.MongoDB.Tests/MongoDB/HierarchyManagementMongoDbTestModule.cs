using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace NecnatAbp.HierarchyManagement.MongoDB;

[DependsOn(
    typeof(HierarchyManagementApplicationTestModule),
    typeof(HierarchyManagementMongoDbModule)
)]
public class HierarchyManagementMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
        });
    }
}
