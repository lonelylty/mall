using System;
using Heals.CSX.Mall.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Heals.CSX.Mall.Carts
{
    public class CartItemRepository : EfCoreRepository<MallDbContext, CartItem, Guid>, ICartItemRepository
    {
        public CartItemRepository(IDbContextProvider<MallDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}