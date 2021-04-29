using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Heals.CSX.Mall.Users
{
    public class AppUserAppServiceTests : MallApplicationTestBase
    {
        private readonly IAppUserAppService _appUserAppService;

        public AppUserAppServiceTests()
        {
            _appUserAppService = GetRequiredService<IAppUserAppService>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
        */
    }
}
