using Heals.CSX.Mall.Carts;
using Heals.CSX.Mall.Addresses;
using Heals.CSX.Mall.AppUsers;
using Heals.CSX.Mall.Orders;
using Heals.CSX.Mall.Products;
using Heals.CSX.Mall.Users;
using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users.EntityFrameworkCore;

namespace Heals.CSX.Mall.EntityFrameworkCore
{
    public static class MallDbContextModelCreatingExtensions
    {
        public static void ConfigureMall(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(MallConsts.DbTablePrefix + "YourEntities", MallConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
            //var options = new MallModelBuilderConfigurationOptions();
            //optionsAction?.Invoke(options);

            //ConfigureAppUser(builder);
            ConfigureProduct(builder);
            ConfigureProductItemOrdered(builder);
            ConfigureOrderItem(builder);
            ConfigureAddress(builder);
            ConfigureOrder(builder);



            //builder.Entity<Product>(b =>
            //{
            //    b.ToTable(MallConsts.DbTablePrefix + "Products", MallConsts.DbSchema);
            //    b.ConfigureByConvention(); 


            //    /* Configure more properties here */
            //});


            //builder.Entity<ProductItemOrdered>(b =>
            //{
            //    b.ToTable(MallConsts.DbTablePrefix + "ProductItemOrdereds", MallConsts.DbSchema);
            //    b.ConfigureByConvention(); 
                

            //    /* Configure more properties here */
            //});


            //builder.Entity<OrderItem>(b =>
            //{
            //    b.ToTable(MallConsts.DbTablePrefix + "OrderItems", MallConsts.DbSchema);
            //    b.ConfigureByConvention(); 
                

            //    /* Configure more properties here */
            //});


            //builder.Entity<Address>(b =>
            //{
            //    b.ToTable(MallConsts.DbTablePrefix + "Addresses", MallConsts.DbSchema);
            //    b.ConfigureByConvention(); 
                

            //    /* Configure more properties here */
            //});


            //builder.Entity<Order>(b =>
            //{
            //    b.ToTable(MallConsts.DbTablePrefix + "Orders", MallConsts.DbSchema);
            //    b.ConfigureByConvention(); 
                

            //    /* Configure more properties here */
            //});


            builder.Entity<CartItem>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "CartItems", MallConsts.DbSchema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });


            builder.Entity<Cart>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "Carts", MallConsts.DbSchema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });
        }

        private static void ConfigureAppUser(ModelBuilder builder)
        {
            builder.Entity<AppUser>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "Users", MallConsts.DbSchema);
                b.ConfigureByConvention();
                //b.ConfigureAbpUser();

                b.Property(x => x.ClinicCode).IsRequired().HasMaxLength(AppUserConsts.MaxClinicCodeLength);
                b.Property(x => x.DoctorCode).IsRequired().HasMaxLength(AppUserConsts.MaxDoctorCodeLength);
                b.Property(x => x.PasswordText).IsRequired(false).HasMaxLength(AppUserConsts.MaxPasswordTextLength);
            });
        }

        private static void ConfigureProduct(ModelBuilder builder)
        {
            builder.Entity<Product>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "Products", MallConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.ClinicCode).IsRequired().HasMaxLength(ProductConsts.MaxClinicCodeLength);
                b.Property(x => x.Name).IsRequired().HasMaxLength(ProductConsts.MaxNameLength);
                b.Property(x => x.ProductID).IsRequired().HasMaxLength(ProductConsts.MaxProductIDLength);
                b.Property(x => x.SerialNumber).IsRequired().HasMaxLength(ProductConsts.MaxSerialNumberLength);
                b.Property(x => x.Description).IsRequired().HasMaxLength(ProductConsts.MaxDescriptionLength);
                b.Property(x => x.PictureUri).IsRequired().HasMaxLength(ProductConsts.MaxPictureUriLength);
                b.Property(x => x.Specification).IsRequired().HasMaxLength(ProductConsts.MaxSpecificationLength);
                b.Property(x => x.SupplierName).IsRequired().HasMaxLength(ProductConsts.MaxSupplierNameLength);
                b.Property(x => x.Color).IsRequired().HasMaxLength(ProductConsts.MaxColorLength);
                b.Property(x => x.CatalogBrand).IsRequired().HasMaxLength(ProductConsts.MaxCatalogBrandLength);
            });
        }

        private static void ConfigureProductItemOrdered(ModelBuilder builder)
        {
            builder.Entity<ProductItemOrdered>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "ProductItemOrdereds", MallConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.ProductSeqId).IsRequired().HasMaxLength(ProductConsts.MaxProductIDLength);
                b.Property(x => x.ProductName).IsRequired().HasMaxLength(ProductConsts.MaxNameLength);
                b.Property(x => x.PictureUri).IsRequired(false).HasMaxLength(ProductConsts.MaxPictureUriLength);
            });
        }

        private static void ConfigureOrderItem(ModelBuilder builder)
        {
            builder.Entity<OrderItem>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "OrderItems", MallConsts.DbSchema);
                b.ConfigureByConvention();
            });
        }

        private static void ConfigureAddress(ModelBuilder builder)
        {
            builder.Entity<Address>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "Addresses", MallConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.ClinicCode).IsRequired().HasMaxLength(AddressConsts.MaxClinicCodeLength);
                b.Property(x => x.ClinicName).IsRequired().HasMaxLength(AddressConsts.MaxClinicNameLength);
                b.Property(x => x.Contacts).IsRequired().HasMaxLength(AddressConsts.MaxContactsLength);
                b.Property(x => x.Phone).IsRequired().HasMaxLength(AddressConsts.MaxPhoneLength);
                b.Property(x => x.CustomerName).IsRequired().HasMaxLength(AddressConsts.MaxCustomerNameLength);
                b.Property(x => x.CustomerAccount).IsRequired().HasMaxLength(AddressConsts.MaxCustomerAccountLength);
                b.Property(x => x.Remarks).IsRequired().HasMaxLength(AddressConsts.MaxRemarksLength);
                b.Property(x => x.HealsRemarks).IsRequired().HasMaxLength(AddressConsts.MaxHealsRemarksLength);
                b.Property(x => x.Street).IsRequired().HasMaxLength(AddressConsts.MaxStreetLength);
                b.Property(x => x.City).IsRequired().HasMaxLength(AddressConsts.MaxCityLength);
                b.Property(x => x.State).IsRequired().HasMaxLength(AddressConsts.MaxStateLength);
                b.Property(x => x.Country).IsRequired().HasMaxLength(AddressConsts.MaxCountryLength);
                b.Property(x => x.ZipCode).IsRequired().HasMaxLength(AddressConsts.MaxZipCodeLength);
            });
        }

        private static void ConfigureOrder(ModelBuilder builder)
        {
            builder.Entity<Order>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "Orders", MallConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.OrderNo).IsRequired().HasMaxLength(OrderConsts.MaxOrderNoLength);
            });
        }
    }
}
