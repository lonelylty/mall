using System;
using Heals.CSX.Mall.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Heals.CSX.Mall.Carts
{
    public class CartRepository : EfCoreRepository<MallDbContext, Cart, Guid>, ICartRepository
    {
        public CartRepository(IDbContextProvider<MallDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}