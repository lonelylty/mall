namespace Heals.CSX.Mall.Permissions
{
    public static class MallPermissions
    {
        public const string GroupName = "Mall";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class AppUser
        {
            public const string Default = GroupName + ".AppUser";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Product
        {
            public const string Default = GroupName + ".Product";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class ProductItemOrdered
        {
            public const string Default = GroupName + ".ProductItemOrdered";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class OrderItem
        {
            public const string Default = GroupName + ".OrderItem";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Address
        {
            public const string Default = GroupName + ".Address";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Order
        {
            public const string Default = GroupName + ".Order";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class CartItem
        {
            public const string Default = GroupName + ".CartItem";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Cart
        {
            public const string Default = GroupName + ".Cart";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
