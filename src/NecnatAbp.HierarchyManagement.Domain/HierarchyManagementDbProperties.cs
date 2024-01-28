namespace NecnatAbp.HierarchyManagement;

public static class HierarchyManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = "HierarchyManagement";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "HierarchyManagement";
}
