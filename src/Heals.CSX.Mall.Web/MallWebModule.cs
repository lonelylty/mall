using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Heals.CSX.Mall.EntityFrameworkCore;
using Heals.CSX.Mall.Localization;
//using Heals.CSX.Mall.MultiTenancy;
using Heals.CSX.Mall.Web.Menus;
using Microsoft.OpenApi.Models;
using Volo.Abp;
//using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
//using Volo.Abp.AspNetCore.Mvc.UI;
//using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
//using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
//using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
//using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
//using Volo.Abp.PermissionManagement.Web;
using Volo.Abp.Swashbuckle;
//using Volo.Abp.TenantManagement.Web;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.UI;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Heals.CSX.Mall.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace Heals.CSX.Mall.Web
{
    [DependsOn(
        typeof(MallHttpApiModule),
        typeof(MallApplicationModule),
        typeof(MallEntityFrameworkCoreModule),
        typeof(AbpAutofacModule),
        //typeof(AbpIdentityWebModule),
        //typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        //typeof(AbpTenantManagementWebModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpSwashbuckleModule)
        )]
    public class MallWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(MallResource),
                    typeof(MallDomainModule).Assembly,
                    typeof(MallDomainSharedModule).Assembly,
                    typeof(MallApplicationModule).Assembly,
                    typeof(MallApplicationContractsModule).Assembly,
                    typeof(MallWebModule).Assembly
                );
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureUrls(configuration);
            ConfigureAuthentication(context, configuration);
            ConfigureSession(context);
            ConfigureAutoMapper();
            //ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureLocalizationServices();
            ConfigureNavigationServices();
            //ConfigureAutoApiControllers();
            ConfigureSwaggerServices(context.Services);

            context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(configPolicy =>
                {
                    configPolicy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();

            //if (!env.IsDevelopment())
            //{
            //    app.UseErrorPage();
            //}

            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();
            app.UseSession();

            //if (MultiTenancyConsts.IsEnabled)
            //{
            //    app.UseMultiTenancy();
            //}

            //app.UseIdentityServer();
            app.UseAuthorization();
            app.UseSwagger();
            //app.UseAbpSwaggerUI(options =>
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Mall API");
                //options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
            //app.UseMvc();
        }



        #region Configure
        private void ConfigureUrls(IConfiguration configuration)
        {
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            //context.Services.AddAlwaysAllowAuthorization();
            //context.Services.AddAuthentication()
            //    .AddJwtBearer(options =>
            //    {
            //        options.Authority = configuration["AuthServer:Authority"];
            //        options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
            //        options.Audience = "Mall";
            //    });

            context.Services.AddDbContext<MallIdentityContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("Default")));
            context.Services.AddIdentity<MallUser, MallRole>()
                .AddEntityFrameworkStores<MallIdentityContext>();
            context.Services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 1;
            });

            context.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddCookie(options => options.SlidingExpiration = true)
           .AddJwtBearer(options =>
           {
               options.RequireHttpsMetadata = false;
               options.SaveToken = true;
               options.Authority = configuration["JwtBearerOptions:Authority"];
               options.Audience = configuration["JwtBearerOptions:Audience"];
               options.Configuration = new OpenIdConnectConfiguration();
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidIssuer = configuration["JwtBearerOptions:Issuer"],
                   ValidAudience = configuration["JwtBearerOptions:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtBearerOptions:Key"]))
               };
           });

            // config authorization
            context.Services.AddAuthorization(options =>
            {
                var defaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
                options.DefaultPolicy = defaultPolicy;
                //options.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        private void ConfigureSession(ServiceConfigurationContext context)
        {
            context.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(30.0);
                options.Cookie.Name = "mall.api.session";
                options.Cookie.IsEssential = true;
            });
            context.Services.AddHttpContextAccessor();
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<MallWebModule>();
            });
        }

        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<MallDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Heals.CSX.Mall.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<MallDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Heals.CSX.Mall.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<MallApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Heals.CSX.Mall.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<MallApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Heals.CSX.Mall.Application"));
                    options.FileSets.ReplaceEmbeddedByPhysical<MallWebModule>(hostingEnvironment.ContentRootPath);
                });
            }
        }

        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
                options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
                options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
                options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
                options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            });
        }

        private void ConfigureNavigationServices()
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new MallMenuContributor());
            });
        }

        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(MallApplicationModule).Assembly);
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    //options.SwaggerDoc("v1", new OpenApiInfo { Title = "Mall API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);

                    //var security = new OpenApiSecurityScheme
                    //{
                    //    Description = "Please enter Bearer JWT. For example: Bearer {This String Should Be Replaced With JWT}",
                    //    Name = "Authorization",
                    //    In = ParameterLocation.Header,
                    //    Type = SecuritySchemeType.ApiKey
                    //};
                    //// 必须 oauth2 这个名称
                    //options.AddSecurityDefinition("oauth2", security);
                    //options.AddSecurityRequirement(new OpenApiSecurityRequirement { { security, new List<string>() } });
                    //options.OperationFilter<AddResponseHeadersFilter>();
                    //options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                    //options.OperationFilter<SecurityRequirementsOperationFilter>();

                    var basePath = Path.GetDirectoryName(typeof(MallHttpApiModule).Assembly.Location);
                    var xmlPath = Path.Combine(basePath, "Heals.CSX.Mall.HttpApi.xml");
                    options.IncludeXmlComments(xmlPath, true);
                    options.DocumentFilter<EnumDocumentFilter>();
                    //options.DescribeAllEnumsAsStrings();
                }
            );
        }
        
        #endregion

        public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
        {
            readonly IApiVersionDescriptionProvider provider;

            public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

            public void Configure(SwaggerGenOptions options)
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                      description.GroupName,
                        new OpenApiInfo()
                        {
                            Title = $"Mall API {description.ApiVersion}",
                            Version = description.ApiVersion.ToString(),
                        });
                }
            }
        }
    }
}
