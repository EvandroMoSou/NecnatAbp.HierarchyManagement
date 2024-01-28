using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace NecnatAbp.HierarchyManagement.EntityFrameworkCore;

[DependsOn(
    typeof(HierarchyManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class HierarchyManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<HierarchyManagementDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddDefaultRepositories(includeAllEntities: true);
        });
    }
}
