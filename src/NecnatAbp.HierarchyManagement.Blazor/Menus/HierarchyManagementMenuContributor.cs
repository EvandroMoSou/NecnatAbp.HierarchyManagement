using NecnatAbp.HierarchyManagement.Localization;
using NecnatAbp.HierarchyManagement.Permissions;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace NecnatAbp.HierarchyManagement.Blazor.Menus;

public class HierarchyManagementMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        //context.Menu.AddItem(new ApplicationMenuItem(HierarchyManagementMenus.Prefix, displayName: "HierarchyManagement", "/HierarchyManagement", icon: "fa fa-globe"));

        var l = context.GetLocalizer<HierarchyManagementResource>();

        var menu = new ApplicationMenuItem(
            HierarchyManagementMenus.Prefix,
            l["Menu:HierarchyManagement"],
            icon: "fas fa-sitemap"
        );

        if (await context.IsGrantedAsync(HierarchyManagementPermissions.Hierarchies.Default))
        {
            menu.AddItem(new ApplicationMenuItem(
                HierarchyManagementMenus.Hierarchy,
                l["Menu:HierarchyManagement:Hierarchy"],
                url: "/HierarchyManagement/Hierarchy/Listing",
                order: 1
            ));
        }

        if (await context.IsGrantedAsync(HierarchyManagementPermissions.HierarchyComponentGroups.Default))
        {
            menu.AddItem(new ApplicationMenuItem(
                HierarchyManagementMenus.HierarchyComponentGroup,
                l["Menu:HierarchyManagement:HierarchyComponentGroup"],
                url: "/HierarchyManagement/HierarchyComponentGroup/Listing",
                order: 1
            ));
        }

        if (await context.IsGrantedAsync(HierarchyManagementPermissions.HierarchicalStructures.Default))
        {
            menu.AddItem(new ApplicationMenuItem(
                HierarchyManagementMenus.HierarchicalStructure,
                l["Menu:HierarchyManagement:HierarchicalStructure"],
                url: "/HierarchyManagement/HierarchicalStructure/Maintain",
                order: 1
            ));
        }

        if (await context.IsGrantedAsync(HierarchyManagementPermissions.UserRoleHierarchicalStructures.Default))
        {
            menu.AddItem(new ApplicationMenuItem(
                HierarchyManagementMenus.UserRoleHierarchicalStructure,
                l["Menu:HierarchyManagement:UserRoleHierarchicalStructure"],
                url: "/HierarchyManagement/UserRoleHierarchicalStructure/Listing",
                order: 1
            ));
        }

        context.Menu.AddItem(menu);
    }
}
