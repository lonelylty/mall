using System.Threading.Tasks;
using Heals.CSX.Mall.Permissions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Heals.CSX.Mall.Localization;
using Heals.CSX.Mall.MultiTenancy;
//using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Heals.CSX.Mall.Web.Menus
{
    public class MallMenuContributor : IMenuContributor
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
            if (!MultiTenancyConsts.IsEnabled)
            {
                var administration = context.Menu.GetAdministration();
                //administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            var l = context.GetLocalizer<MallResource>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem(MallMenus.Home, l["Menu:Home"], "~/"));
            //if (await context.IsGrantedAsync(MallPermissions.AppUser.Default))
            //{
            //    context.Menu.AddItem(
            //        new ApplicationMenuItem(MallMenus.AppUser, l["Menu:AppUser"], "/Users/AppUser")
            //    );
            //}
            if (await context.IsGrantedAsync(MallPermissions.Product.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(MallMenus.Product, l["Menu:Product"], "/Products/Product")
                );
            }
            if (await context.IsGrantedAsync(MallPermissions.ProductItemOrdered.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(MallMenus.ProductItemOrdered, l["Menu:ProductItemOrdered"], "/Orders/ProductItemOrdered")
                );
            }
            if (await context.IsGrantedAsync(MallPermissions.OrderItem.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(MallMenus.OrderItem, l["Menu:OrderItem"], "/Orders/OrderItem")
                );
            }
            if (await context.IsGrantedAsync(MallPermissions.Address.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(MallMenus.Address, l["Menu:Address"], "/Addresses/Address")
                );
            }
            if (await context.IsGrantedAsync(MallPermissions.Order.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(MallMenus.Order, l["Menu:Order"], "/Orders/Order")
                );
            }
            if (await context.IsGrantedAsync(MallPermissions.CartItem.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(MallMenus.CartItem, l["Menu:CartItem"], "/Carts/CartItem")
                );
            }
            if (await context.IsGrantedAsync(MallPermissions.Cart.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(MallMenus.Cart, l["Menu:Cart"], "/Carts/Cart")
                );
            }
        }
    }
}
