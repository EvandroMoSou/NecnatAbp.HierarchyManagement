using Volo.Abp.Reflection;

namespace NecnatAbp.HierarchyManagement.Permissions;

public class HierarchyManagementPermissions
{
    public const string GroupName = "HierarchyManagement";

    public static class Hierarchy
    {
        public const string Default = GroupName + ".Hierarchy";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class HierarchyComponentGroup
    {
        public const string Default = GroupName + ".HierarchyComponentGroup";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class HierarchicalStructure
    {
        public const string Default = GroupName + ".HierarchicalStructure";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class UserRoleHierarchicalStructure
    {
        public const string Default = GroupName + ".UserRoleHierarchicalStructure";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(HierarchyManagementPermissions));
    }
}
