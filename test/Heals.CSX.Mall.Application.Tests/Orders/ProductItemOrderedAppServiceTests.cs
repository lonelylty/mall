using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Heals.CSX.Mall.Orders
{
    public class ProductItemOrderedAppServiceTests : MallApplicationTestBase
    {
        private readonly IProductItemOrderedAppService _productItemOrderedAppService;

        public ProductItemOrderedAppServiceTests()
        {
            _productItemOrderedAppService = GetRequiredService<IProductItemOrderedAppService>();
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
