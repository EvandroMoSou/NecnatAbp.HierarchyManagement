using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NecnatAbp.HierarchyManagement.EntityFrameworkCore;

public class HierarchyManagementHttpApiHostMigrationsDbContext : AbpDbContext<HierarchyManagementHttpApiHostMigrationsDbContext>
{
    public HierarchyManagementHttpApiHostMigrationsDbContext(DbContextOptions<HierarchyManagementHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureHierarchyManagement();
    }
}
