using Microsoft.EntityFrameworkCore;
using NecnatAbp.HierarchyManagement;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace NecnatAbp.HierarchyManagement.EntityFrameworkCore;

[ConnectionStringName(HierarchyManagementDbProperties.ConnectionStringName)]
public interface IHierarchyManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */

    DbSet<HierarchicalStructure> HierarchicalStructures { get; }
    DbSet<Hierarchy> Hierarchies { get; }
    DbSet<HierarchyComponentGroup> HierarchyComponentGroups { get; }
    DbSet<UserRoleHierarchicalStructure> UserRoleHierarchicalStructures { get; }

}
