using System;
using Heals.CSX.Mall.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Heals.CSX.Mall.Orders
{
    public class ProductItemOrderedRepository : EfCoreRepository<MallDbContext, ProductItemOrdered, Guid>, IProductItemOrderedRepository
    {
        public ProductItemOrderedRepository(IDbContextProvider<MallDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}