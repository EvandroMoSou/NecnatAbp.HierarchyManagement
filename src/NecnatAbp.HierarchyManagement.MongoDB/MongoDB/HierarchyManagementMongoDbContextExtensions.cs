using Volo.Abp;
using Volo.Abp.MongoDB;

namespace NecnatAbp.HierarchyManagement.MongoDB;

public static class HierarchyManagementMongoDbContextExtensions
{
    public static void ConfigureHierarchyManagement(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
