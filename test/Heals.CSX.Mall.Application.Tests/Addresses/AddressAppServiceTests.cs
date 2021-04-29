using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Heals.CSX.Mall.Addresses
{
    public class AddressAppServiceTests : MallApplicationTestBase
    {
        private readonly IAddressAppService _addressAppService;

        public AddressAppServiceTests()
        {
            _addressAppService = GetRequiredService<IAddressAppService>();
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
