using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NecnatAbp.HierarchyManagement.EntityFrameworkCore;

public class HierarchyManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<HierarchyManagementHttpApiHostMigrationsDbContext>
{
    public HierarchyManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<HierarchyManagementHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("HierarchyManagement"));

        return new HierarchyManagementHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
