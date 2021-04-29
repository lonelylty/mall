using Heals.CSX.Mall.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Heals.CSX.Mall
{
    [DependsOn(
        typeof(MallEntityFrameworkCoreTestModule)
        )]
    public class MallDomainTestModule : AbpModule
    {

    }
}