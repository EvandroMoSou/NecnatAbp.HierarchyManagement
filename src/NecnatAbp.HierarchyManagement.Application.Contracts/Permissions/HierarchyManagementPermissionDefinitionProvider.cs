using NecnatAbp.HierarchyManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace NecnatAbp.HierarchyManagement.Permissions;

public class HierarchyManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HierarchyManagementPermissions.GroupName, L("Permission:HierarchyManagement"));

        var pgHierarchy = myGroup.AddPermission(HierarchyManagementPermissions.Hierarchies.Default, L("Permission:Hierarchies:Default"));
        pgHierarchy.AddChild(HierarchyManagementPermissions.Hierarchies.Create, L("Permission:Hierarchies:Create"));
        pgHierarchy.AddChild(HierarchyManagementPermissions.Hierarchies.Update, L("Permission:Hierarchies:Edit"));
        pgHierarchy.AddChild(HierarchyManagementPermissions.Hierarchies.Delete, L("Permission:Hierarchies:Delete"));

        var pgHierarchyComponentGroup = myGroup.AddPermission(HierarchyManagementPermissions.HierarchyComponentGroups.Default, L("Permission:HierarchyComponentGroups:Default"));
        pgHierarchyComponentGroup.AddChild(HierarchyManagementPermissions.HierarchyComponentGroups.Create, L("Permission:HierarchyComponentGroups:Create"));
        pgHierarchyComponentGroup.AddChild(HierarchyManagementPermissions.HierarchyComponentGroups.Update, L("Permission:HierarchyComponentGroups:Edit"));
        pgHierarchyComponentGroup.AddChild(HierarchyManagementPermissions.HierarchyComponentGroups.Delete, L("Permission:HierarchyComponentGroups:Delete"));

        var pgHierarchicalStructure = myGroup.AddPermission(HierarchyManagementPermissions.HierarchicalStructures.Default, L("Permission:HierarchicalStructures:Default"));
        pgHierarchicalStructure.AddChild(HierarchyManagementPermissions.HierarchicalStructures.Create, L("Permission:HierarchicalStructures:Create"));
        pgHierarchicalStructure.AddChild(HierarchyManagementPermissions.HierarchicalStructures.Delete, L("Permission:HierarchicalStructures:Delete"));

        var pgUserRoleHierarchicalStructure = myGroup.AddPermission(HierarchyManagementPermissions.UserRoleHierarchicalStructures.Default, L("Permission:UserRoleHierarchicalStructures:Default"));
        pgUserRoleHierarchicalStructure.AddChild(HierarchyManagementPermissions.UserRoleHierarchicalStructures.Create, L("Permission:UserRoleHierarchicalStructures:Create"));
        pgUserRoleHierarchicalStructure.AddChild(HierarchyManagementPermissions.UserRoleHierarchicalStructures.Update, L("Permission:UserRoleHierarchicalStructures:Edit"));
        pgUserRoleHierarchicalStructure.AddChild(HierarchyManagementPermissions.UserRoleHierarchicalStructures.Delete, L("Permission:UserRoleHierarchicalStructures:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HierarchyManagementResource>(name);
    }
}
