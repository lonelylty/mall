using System;
using System.Threading.Tasks;
using Heals.CSX.Mall.Orders;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Heals.CSX.Mall.EntityFrameworkCore.Orders
{
    public class ProductItemOrderedRepositoryTests : MallEntityFrameworkCoreTestBase
    {
        private readonly IProductItemOrderedRepository _productItemOrderedRepository;

        public ProductItemOrderedRepositoryTests()
        {
            _productItemOrderedRepository = GetRequiredService<IProductItemOrderedRepository>();
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
