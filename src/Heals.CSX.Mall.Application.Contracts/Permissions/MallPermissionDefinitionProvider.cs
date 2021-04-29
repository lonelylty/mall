using Heals.CSX.Mall.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Heals.CSX.Mall.Permissions
{
    public class MallPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MallPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(MallPermissions.MyPermission1, L("Permission:MyPermission1"));

            var appUserPermission = myGroup.AddPermission(MallPermissions.AppUser.Default, L("Permission:AppUser"));
            appUserPermission.AddChild(MallPermissions.AppUser.Create, L("Permission:Create"));
            appUserPermission.AddChild(MallPermissions.AppUser.Update, L("Permission:Update"));
            appUserPermission.AddChild(MallPermissions.AppUser.Delete, L("Permission:Delete"));

            var productPermission = myGroup.AddPermission(MallPermissions.Product.Default, L("Permission:Product"));
            productPermission.AddChild(MallPermissions.Product.Create, L("Permission:Create"));
            productPermission.AddChild(MallPermissions.Product.Update, L("Permission:Update"));
            productPermission.AddChild(MallPermissions.Product.Delete, L("Permission:Delete"));

            var productItemOrderedPermission = myGroup.AddPermission(MallPermissions.ProductItemOrdered.Default, L("Permission:ProductItemOrdered"));
            productItemOrderedPermission.AddChild(MallPermissions.ProductItemOrdered.Create, L("Permission:Create"));
            productItemOrderedPermission.AddChild(MallPermissions.ProductItemOrdered.Update, L("Permission:Update"));
            productItemOrderedPermission.AddChild(MallPermissions.ProductItemOrdered.Delete, L("Permission:Delete"));

            var orderItemPermission = myGroup.AddPermission(MallPermissions.OrderItem.Default, L("Permission:OrderItem"));
            orderItemPermission.AddChild(MallPermissions.OrderItem.Create, L("Permission:Create"));
            orderItemPermission.AddChild(MallPermissions.OrderItem.Update, L("Permission:Update"));
            orderItemPermission.AddChild(MallPermissions.OrderItem.Delete, L("Permission:Delete"));

            var addressPermission = myGroup.AddPermission(MallPermissions.Address.Default, L("Permission:Address"));
            addressPermission.AddChild(MallPermissions.Address.Create, L("Permission:Create"));
            addressPermission.AddChild(MallPermissions.Address.Update, L("Permission:Update"));
            addressPermission.AddChild(MallPermissions.Address.Delete, L("Permission:Delete"));

            var orderPermission = myGroup.AddPermission(MallPermissions.Order.Default, L("Permission:Order"));
            orderPermission.AddChild(MallPermissions.Order.Create, L("Permission:Create"));
            orderPermission.AddChild(MallPermissions.Order.Update, L("Permission:Update"));
            orderPermission.AddChild(MallPermissions.Order.Delete, L("Permission:Delete"));


            var cartItemPermission = myGroup.AddPermission(MallPermissions.CartItem.Default, L("Permission:CartItem"));
            cartItemPermission.AddChild(MallPermissions.CartItem.Create, L("Permission:Create"));
            cartItemPermission.AddChild(MallPermissions.CartItem.Update, L("Permission:Update"));
            cartItemPermission.AddChild(MallPermissions.CartItem.Delete, L("Permission:Delete"));

            var cartPermission = myGroup.AddPermission(MallPermissions.Cart.Default, L("Permission:Cart"));
            cartPermission.AddChild(MallPermissions.Cart.Create, L("Permission:Create"));
            cartPermission.AddChild(MallPermissions.Cart.Update, L("Permission:Update"));
            cartPermission.AddChild(MallPermissions.Cart.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MallResource>(name);
        }
    }
}
