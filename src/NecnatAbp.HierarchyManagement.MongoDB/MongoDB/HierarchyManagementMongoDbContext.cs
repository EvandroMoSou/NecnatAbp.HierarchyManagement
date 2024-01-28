using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace NecnatAbp.HierarchyManagement.MongoDB;

[ConnectionStringName(HierarchyManagementDbProperties.ConnectionStringName)]
public class HierarchyManagementMongoDbContext : AbpMongoDbContext, IHierarchyManagementMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureHierarchyManagement();
    }
}
