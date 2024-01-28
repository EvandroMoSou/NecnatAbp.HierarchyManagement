using Microsoft.EntityFrameworkCore;
using NecnatAbp.HierarchyManagement;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace NecnatAbp.HierarchyManagement.EntityFrameworkCore;

[ConnectionStringName(HierarchyManagementDbProperties.ConnectionStringName)]
public class HierarchyManagementDbContext : AbpDbContext<HierarchyManagementDbContext>, IHierarchyManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    #region Entities from the modules

    //Permission
    public DbSet<PermissionGrant> PermissionGrant { get; set; }
    public DbSet<PermissionGroupDefinitionRecord> PermissionGroupDefinitionRecord { get; set; }
    public DbSet<PermissionDefinitionRecord> PermissionDefinitionRecord { get; set; }

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    #endregion

    public DbSet<HierarchicalStructure> HierarchicalStructures { get; set; }
    public DbSet<Hierarchy> Hierarchies { get; set; }
    public DbSet<HierarchyComponentGroup> HierarchyComponentGroups { get; set; }
    public DbSet<UserRoleHierarchicalStructure> UserRoleHierarchicalStructures { get; set; }

    public HierarchyManagementDbContext(DbContextOptions<HierarchyManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigurePermissionManagement();
        builder.ConfigureIdentity();
        builder.ConfigureHierarchyManagement();
    }
}
