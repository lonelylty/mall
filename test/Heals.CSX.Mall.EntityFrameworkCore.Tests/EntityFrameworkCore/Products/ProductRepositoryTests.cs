using System;
using System.Threading.Tasks;
using Heals.CSX.Mall.Products;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Heals.CSX.Mall.EntityFrameworkCore.Products
{
    public class ProductRepositoryTests : MallEntityFrameworkCoreTestBase
    {
        private readonly IProductRepository _productRepository;

        public ProductRepositoryTests()
        {
            _productRepository = GetRequiredService<IProductRepository>();
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
