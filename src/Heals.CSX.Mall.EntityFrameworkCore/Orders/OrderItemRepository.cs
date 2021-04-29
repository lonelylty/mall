using System;
using Heals.CSX.Mall.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Heals.CSX.Mall.Orders
{
    public class OrderItemRepository : EfCoreRepository<MallDbContext, OrderItem, Guid>, IOrderItemRepository
    {
        public OrderItemRepository(IDbContextProvider<MallDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}