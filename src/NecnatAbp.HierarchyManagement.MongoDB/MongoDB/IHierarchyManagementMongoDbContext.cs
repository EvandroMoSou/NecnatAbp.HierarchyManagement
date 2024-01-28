using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace NecnatAbp.HierarchyManagement.MongoDB;

[ConnectionStringName(HierarchyManagementDbProperties.ConnectionStringName)]
public interface IHierarchyManagementMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
