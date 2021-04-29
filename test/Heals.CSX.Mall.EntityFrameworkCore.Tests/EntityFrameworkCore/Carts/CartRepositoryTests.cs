using System;
using System.Threading.Tasks;
using Heals.CSX.Mall.Carts;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Heals.CSX.Mall.EntityFrameworkCore.Carts
{
    public class CartRepositoryTests : MallEntityFrameworkCoreTestBase
    {
        private readonly ICartRepository _cartRepository;

        public CartRepositoryTests()
        {
            _cartRepository = GetRequiredService<ICartRepository>();
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
