using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Heals.CSX.Mall.Orders
{
    public class OrderItemAppServiceTests : MallApplicationTestBase
    {
        private readonly IOrderItemAppService _orderItemAppService;

        public OrderItemAppServiceTests()
        {
            _orderItemAppService = GetRequiredService<IOrderItemAppService>();
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
