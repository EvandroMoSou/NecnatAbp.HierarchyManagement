using NecnatAbp.HierarchyManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace NecnatAbp.HierarchyManagement.Permissions;

public class HierarchyManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HierarchyManagementPermissions.GroupName, L("Permission:HierarchyManagement"));

        var pgHierarchy = myGroup.AddPermission(HierarchyManagementPermissions.Hierarchy.Default, L("Permission:Hierarchy:Default"));
        pgHierarchy.AddChild(HierarchyManagementPermissions.Hierarchy.Create, L("Permission:Hierarchy:Create"));
        pgHierarchy.AddChild(HierarchyManagementPermissions.Hierarchy.Update, L("Permission:Hierarchy:Edit"));
        pgHierarchy.AddChild(HierarchyManagementPermissions.Hierarchy.Delete, L("Permission:Hierarchy:Delete"));

        var pgHierarchyComponentGroup = myGroup.AddPermission(HierarchyManagementPermissions.HierarchyComponentGroup.Default, L("Permission:HierarchyComponentGroup:Default"));
        pgHierarchyComponentGroup.AddChild(HierarchyManagementPermissions.HierarchyComponentGroup.Create, L("Permission:HierarchyComponentGroup:Create"));
        pgHierarchyComponentGroup.AddChild(HierarchyManagementPermissions.HierarchyComponentGroup.Update, L("Permission:HierarchyComponentGroup:Edit"));
        pgHierarchyComponentGroup.AddChild(HierarchyManagementPermissions.HierarchyComponentGroup.Delete, L("Permission:HierarchyComponentGroup:Delete"));

        var pgHierarchicalStructure = myGroup.AddPermission(HierarchyManagementPermissions.HierarchicalStructure.Default, L("Permission:HierarchicalStructure:Default"));
        pgHierarchicalStructure.AddChild(HierarchyManagementPermissions.HierarchicalStructure.Create, L("Permission:HierarchicalStructure:Create"));
        pgHierarchicalStructure.AddChild(HierarchyManagementPermissions.HierarchicalStructure.Delete, L("Permission:HierarchicalStructure:Delete"));

        var pgUserRoleHierarchicalStructure = myGroup.AddPermission(HierarchyManagementPermissions.UserRoleHierarchicalStructure.Default, L("Permission:UserRoleHierarchicalStructure:Default"));
        pgUserRoleHierarchicalStructure.AddChild(HierarchyManagementPermissions.UserRoleHierarchicalStructure.Create, L("Permission:UserRoleHierarchicalStructure:Create"));
        pgUserRoleHierarchicalStructure.AddChild(HierarchyManagementPermissions.UserRoleHierarchicalStructure.Update, L("Permission:UserRoleHierarchicalStructure:Edit"));
        pgUserRoleHierarchicalStructure.AddChild(HierarchyManagementPermissions.UserRoleHierarchicalStructure.Delete, L("Permission:UserRoleHierarchicalStructure:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HierarchyManagementResource>(name);
    }
}
