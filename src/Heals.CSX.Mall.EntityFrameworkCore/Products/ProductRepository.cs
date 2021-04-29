using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heals.CSX.Mall.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Heals.CSX.Mall.Products
{
    public class ProductRepository : EfCoreRepository<MallDbContext, Product, Guid>, IProductRepository
    {
        public ProductRepository(IDbContextProvider<MallDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

       

        public async Task<int> GetCatalogTypeNumAsync(short catalogTypeId)
        {
            return await DbSet.CountAsync(x => x.CatalogTypeId == catalogTypeId);
        }

        public async Task BatchCreateAsync(List<Product> products)
        {
            await DbSet.AddRangeAsync(products);
        }
    }
}