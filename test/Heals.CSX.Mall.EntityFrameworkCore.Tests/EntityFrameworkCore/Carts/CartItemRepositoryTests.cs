using System;
using System.Threading.Tasks;
using Heals.CSX.Mall.Carts;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Heals.CSX.Mall.EntityFrameworkCore.Carts
{
    public class CartItemRepositoryTests : MallEntityFrameworkCoreTestBase
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemRepositoryTests()
        {
            _cartItemRepository = GetRequiredService<ICartItemRepository>();
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
