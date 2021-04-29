using Volo.Abp.Modularity;

namespace Heals.CSX.Mall
{
    [DependsOn(
        typeof(MallApplicationModule),
        typeof(MallDomainTestModule)
        )]
    public class MallApplicationTestModule : AbpModule
    {

    }
}