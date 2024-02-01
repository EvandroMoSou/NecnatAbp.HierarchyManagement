using Volo.Abp.Reflection;

namespace NecnatAbp.HierarchyManagement.Permissions;

public class HierarchyManagementPermissions
{
    public const string GroupName = "HierarchyManagement";

    public static class Hierarchies
    {
        public const string Default = GroupName + ".Hierarchies";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class HierarchyComponentGroups
    {
        public const string Default = GroupName + ".HierarchyComponentGroups";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class HierarchicalStructures
    {
        public const string Default = GroupName + ".HierarchicalStructures";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class UserRoleHierarchicalStructures
    {
        public const string Default = GroupName + ".UserRoleHierarchicalStructures";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(HierarchyManagementPermissions));
    }
}
