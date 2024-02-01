using NecnatAbp.HierarchyManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace NecnatAbp.HierarchyManagement.Permissions;

public class HierarchyManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HierarchyManagementPermissions.GroupName, L("Permission:HierarchyManagement"));

        var pgHierarchy = myGroup.AddPermission(HierarchyManagementPermissions.Hierarchies.Default, L("Permission:Hierarchy:Default"));
        pgHierarchy.AddChild(HierarchyManagementPermissions.Hierarchies.Create, L("Permission:Hierarchy:Create"));
        pgHierarchy.AddChild(HierarchyManagementPermissions.Hierarchies.Update, L("Permission:Hierarchy:Edit"));
        pgHierarchy.AddChild(HierarchyManagementPermissions.Hierarchies.Delete, L("Permission:Hierarchy:Delete"));

        var pgHierarchyComponentGroup = myGroup.AddPermission(HierarchyManagementPermissions.HierarchyComponentGroups.Default, L("Permission:HierarchyComponentGroup:Default"));
        pgHierarchyComponentGroup.AddChild(HierarchyManagementPermissions.HierarchyComponentGroups.Create, L("Permission:HierarchyComponentGroup:Create"));
        pgHierarchyComponentGroup.AddChild(HierarchyManagementPermissions.HierarchyComponentGroups.Update, L("Permission:HierarchyComponentGroup:Edit"));
        pgHierarchyComponentGroup.AddChild(HierarchyManagementPermissions.HierarchyComponentGroups.Delete, L("Permission:HierarchyComponentGroup:Delete"));

        var pgHierarchicalStructure = myGroup.AddPermission(HierarchyManagementPermissions.HierarchicalStructures.Default, L("Permission:HierarchicalStructure:Default"));
        pgHierarchicalStructure.AddChild(HierarchyManagementPermissions.HierarchicalStructures.Create, L("Permission:HierarchicalStructure:Create"));
        pgHierarchicalStructure.AddChild(HierarchyManagementPermissions.HierarchicalStructures.Delete, L("Permission:HierarchicalStructure:Delete"));

        var pgUserRoleHierarchicalStructure = myGroup.AddPermission(HierarchyManagementPermissions.UserRoleHierarchicalStructures.Default, L("Permission:UserRoleHierarchicalStructure:Default"));
        pgUserRoleHierarchicalStructure.AddChild(HierarchyManagementPermissions.UserRoleHierarchicalStructures.Create, L("Permission:UserRoleHierarchicalStructure:Create"));
        pgUserRoleHierarchicalStructure.AddChild(HierarchyManagementPermissions.UserRoleHierarchicalStructures.Update, L("Permission:UserRoleHierarchicalStructure:Edit"));
        pgUserRoleHierarchicalStructure.AddChild(HierarchyManagementPermissions.UserRoleHierarchicalStructures.Delete, L("Permission:UserRoleHierarchicalStructure:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HierarchyManagementResource>(name);
    }
}
