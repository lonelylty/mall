using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Heals.CSX.Mall.Carts
{
    public class CartAppServiceTests : MallApplicationTestBase
    {
        private readonly ICartAppService _cartAppService;

        public CartAppServiceTests()
        {
            _cartAppService = GetRequiredService<ICartAppService>();
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
