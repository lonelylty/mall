using Heals.CSX.Mall.Users;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.MailKit;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace Heals.CSX.Mall
{
    [DependsOn(
        typeof(MallDomainModule),
        //typeof(AbpAccountApplicationModule),
        typeof(MallApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        //typeof(AbpEmailingModule),
        typeof(AbpMailKitModule)
        //typeof(AbpTenantManagementApplicationModule),
        //typeof(AbpFeatureManagementApplicationModule)
        )]
    public class MallApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //context.Services.AddScoped<UserManager<MallUser>>().Configure<IdentityOptions>(options =>
            //{
            //    // Default Password settings.
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequiredLength = 1;
            //    options.Password.RequiredUniqueChars = 1;
            //});
            //context.Services.AddScoped<SignInManager<MallUser>>();

            context.Services.AddSingleton<IConfiguration>(context.Services.GetConfiguration());
            context.Services.AddScoped<IUserSessionManager, UserSessionManager>();
            context.Services.AddScoped<UserSessionManager>();
            context.Services.AddScoped<IAuthorizationManager, AuthorizationManager>();


            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<MallApplicationModule>();
            });

            //Configure<AbpMailKitOptions>(options =>
            //{
            //    options.SecureSocketOption = SecureSocketOptions.SslOnConnect;
            //});

        }
    }
}
