using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Heals.CSX.Mall.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(MallHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class MallConsoleApiClientModule : AbpModule
    {
        
    }
}
