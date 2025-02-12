using System.Threading.Tasks;
using IndependentTablespace.Samples.Localization;
using IndependentTablespace.Samples.MultiTenancy;
using IndependentTablespace.Samples.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace IndependentTablespace.Samples.Web.Menus;

public class SamplesMenuContributor : IMenuContributor
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
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<SamplesResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                SamplesMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        context.Menu.AddItem(
            new ApplicationMenuItem(
                "BooksStore",
                l["Menu:Samples"],
                icon: "fa fa-book"
            ).AddItem(
                new ApplicationMenuItem(
                    "BooksStore.Books",
                    l["Menu:Books"],
                    url: "/Books"
                ).RequirePermissions(SamplesPermissions.Books.Default)
            ).AddItem( // ADDED THE NEW "AUTHORS" MENU ITEM UNDER THE "BOOK STORE" MENU
                new ApplicationMenuItem(
                    "BooksStore.Authors",
                    l["Menu:Authors"],
                    url: "/Authors"
                ).RequirePermissions(SamplesPermissions.Authors.Default)
            )
        );

        return Task.CompletedTask;
    }
}
