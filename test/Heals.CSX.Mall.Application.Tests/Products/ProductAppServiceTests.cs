using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Heals.CSX.Mall.Products
{
    public class ProductAppServiceTests : MallApplicationTestBase
    {
        private readonly IProductAppService _productAppService;

        public ProductAppServiceTests()
        {
            _productAppService = GetRequiredService<IProductAppService>();
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
