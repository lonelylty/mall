using Microsoft.EntityFrameworkCore;
using Heals.CSX.Mall.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;
using Heals.CSX.Mall.AppUsers;
using Heals.CSX.Mall.Products;
using Heals.CSX.Mall.Orders;
using Heals.CSX.Mall.Addresses;
using Heals.CSX.Mall.Carts;

namespace Heals.CSX.Mall.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See MallMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class MallDbContext : AbpDbContext<MallDbContext>
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside MallDbContextModelCreatingExtensions.ConfigureMall
         */
        //public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ProductItemOrdered> ProductItemOrdereds { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public MallDbContext(DbContextOptions<MallDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            //builder.Entity<AppUser>(b =>
            //{
            //    b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser
                
            //    b.ConfigureByConvention();
            //    //b.ConfigureAbpUser();

            //    /* Configure mappings for your additional properties
            //     * Also see the MallEfCoreEntityExtensionMappings class
            //     */
            //    builder.Entity<AppUser>(b =>
            //    {
            //        b.Property(x => x.ClinicCode).IsRequired().HasMaxLength(AppUserConsts.MaxClinicCodeLength).HasColumnName(nameof(AppUser.ClinicCode));
            //        b.Property(x => x.DoctorCode).IsRequired().HasMaxLength(AppUserConsts.MaxDoctorCodeLength).HasColumnName(nameof(AppUser.DoctorCode));
            //        b.Property(x => x.PasswordText).IsRequired(false).HasMaxLength(AppUserConsts.MaxPasswordTextLength).HasColumnName(nameof(AppUser.PasswordText));
            //    });

            //});

            /* Configure your own tables/entities inside the ConfigureMall method */

            builder.ConfigureMall();
            
        }
    }
}
