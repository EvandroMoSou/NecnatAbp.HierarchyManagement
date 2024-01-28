using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace NecnatAbp.HierarchyManagement.MongoDB;

[DependsOn(
    typeof(HierarchyManagementDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class HierarchyManagementMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<HierarchyManagementMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
