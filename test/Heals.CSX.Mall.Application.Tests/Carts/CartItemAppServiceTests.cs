using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Heals.CSX.Mall.Carts
{
    public class CartItemAppServiceTests : MallApplicationTestBase
    {
        private readonly ICartItemAppService _cartItemAppService;

        public CartItemAppServiceTests()
        {
            _cartItemAppService = GetRequiredService<ICartItemAppService>();
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
