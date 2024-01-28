using NecnatAbp.Data;

namespace NecnatAbp.HierarchyManagement
{
    public static class AbpHierarchyManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = NecnatAbpCommonDbProperties.DbTablePrefix;

        public static string? DbSchema { get; set; } = NecnatAbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "AbpHierarchyManagement";
    }
}
