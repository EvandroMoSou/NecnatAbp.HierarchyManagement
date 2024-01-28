using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace NecnatAbp.HierarchyManagement.Web.Menus;

public class HierarchyManagementMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(HierarchyManagementMenus.Prefix, displayName: "HierarchyManagement", "~/HierarchyManagement", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
