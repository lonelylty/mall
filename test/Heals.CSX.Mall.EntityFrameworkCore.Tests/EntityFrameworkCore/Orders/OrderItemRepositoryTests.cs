using System;
using System.Threading.Tasks;
using Heals.CSX.Mall.Orders;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Heals.CSX.Mall.EntityFrameworkCore.Orders
{
    public class OrderItemRepositoryTests : MallEntityFrameworkCoreTestBase
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemRepositoryTests()
        {
            _orderItemRepository = GetRequiredService<IOrderItemRepository>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
        */
    }
}
