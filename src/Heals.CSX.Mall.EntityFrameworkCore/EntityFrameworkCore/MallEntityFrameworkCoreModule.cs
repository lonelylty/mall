using Heals.CSX.Mall.Carts;
using Heals.CSX.Mall.Addresses;
using Heals.CSX.Mall.Orders;
using Heals.CSX.Mall.Products;
using Heals.CSX.Mall.Users;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Heals.CSX.Mall.EntityFrameworkCore
{
    [DependsOn(
        typeof(MallDomainModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpIdentityServerEntityFrameworkCoreModule),
        //typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(AbpTenantManagementEntityFrameworkCoreModule),
        typeof(AbpFeatureManagementEntityFrameworkCoreModule)
        )]
    public class MallEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            //Volo.Abp.IdentityServer.AbpIdentityServerDbProperties.DbTablePrefix = MallConsts.DbTablePrefix;
            //Volo.Abp.Identity.AbpIdentityDbProperties.DbTablePrefix= MallConsts.DbTablePrefix;
            //Volo.Abp.AuditLogging.AbpAuditLoggingDbProperties.DbTablePrefix = MallConsts.DbTablePrefix;
            //Volo.Abp.BackgroundJobs.BackgroundJobsDbProperties.DbTablePrefix = MallConsts.DbTablePrefix;
            //Volo.Abp.PermissionManagement.AbpPermissionManagementDbProperties.DbTablePrefix = MallConsts.DbTablePrefix;
            //Volo.Abp.FeatureManagement.FeatureManagementDbProperties.DbTablePrefix = MallConsts.DbTablePrefix;
            //Volo.Abp.SettingManagement.AbpSettingManagementDbProperties.DbTablePrefix = MallConsts.DbTablePrefix;
            //Volo.Abp.TenantManagement.AbpTenantManagementDbProperties.DbTablePrefix= MallConsts.DbTablePrefix;

            Volo.Abp.Identity.AbpIdentityDbProperties.DbTablePrefix= MallConsts.DbTablePrefix;
            Volo.Abp.AuditLogging.AbpAuditLoggingDbProperties.DbTablePrefix = MallConsts.DbTablePrefix;
            Volo.Abp.BackgroundJobs.BackgroundJobsDbProperties.DbTablePrefix = MallConsts.DbTablePrefix;
            Volo.Abp.SettingManagement.AbpSettingManagementDbProperties.DbTablePrefix = MallConsts.DbTablePrefix;

            MallEfCoreEntityExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MallDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);
                options.AddRepository<AppUser, AppUserRepository>();
                options.AddRepository<Product, ProductRepository>();
                options.AddRepository<ProductItemOrdered, ProductItemOrderedRepository>();
                options.AddRepository<OrderItem, OrderItemRepository>();
                options.AddRepository<Address, AddressRepository>();
                options.AddRepository<Order, OrderRepository>();
                options.AddRepository<CartItem, CartItemRepository>();
                options.AddRepository<Cart, CartRepository>();
            });

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also MallMigrationsDbContextFactory for EF Core tooling. */
                options.UseSqlServer();
            });
        }
    }
}
