using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;

namespace NecnatAbp.HierarchyManagement.EntityFrameworkCore;

public static class HierarchyManagementDbContextModelCreatingExtensions
{
    public static void ConfigureHierarchyManagement(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(HierarchyManagementDbProperties.DbTablePrefix + "Questions", HierarchyManagementDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */

        builder.Entity<Hierarchy>(b =>
        {
            b.ToTable(AbpHierarchyManagementDbProperties.DbTablePrefix + "Hierarchy",
                AbpHierarchyManagementDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(HierarchyConsts.MaxNameLength);
            b.Property(x => x.IsActive).IsRequired();

            b.HasIndex(x => x.Name);
        });

        builder.Entity<HierarchyComponentGroup>(b =>
        {
            b.ToTable(AbpHierarchyManagementDbProperties.DbTablePrefix + "HierarchyComponentGroup",
                AbpHierarchyManagementDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(HierarchyComponentGroupConsts.MaxNameLength);
            b.Property(x => x.IsActive).IsRequired();

            b.HasIndex(x => x.Name);
        });

        builder.Entity<HierarchicalStructure>(b =>
        {
            b.ToTable(AbpHierarchyManagementDbProperties.DbTablePrefix + "HierarchicalStructure",
                AbpHierarchyManagementDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props

            b.HasOne(o => o.Parent).WithMany().HasForeignKey(x => x.ParentId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            b.HasOne(o => o.Hierarchy).WithMany().HasForeignKey(x => x.HierarchyId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        });

        builder.Entity<UserRoleHierarchicalStructure>(b =>
        {
            b.ToTable(AbpHierarchyManagementDbProperties.DbTablePrefix + "UserRoleHierarchicalStructure",
                AbpHierarchyManagementDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props

            b.HasOne<IdentityRole>().WithMany().HasForeignKey(ur => ur.RoleId).IsRequired();
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(ur => ur.UserId).IsRequired();
            b.HasOne<HierarchicalStructure>().WithMany().HasForeignKey(ur => ur.HierarchicalStructureId).IsRequired(false);

            b.HasIndex(ur => new { ur.UserId, ur.RoleId, ur.HierarchicalStructureId }).IsUnique();
        });
    }
}
