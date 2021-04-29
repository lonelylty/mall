using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Heals.CSX.Mall.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Heals.CSX.Mall.Orders
{
    public class OrderRepository : EfCoreRepository<MallDbContext, Order, Guid>, IOrderRepository
    {
        public OrderRepository(IDbContextProvider<MallDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<int> GetUserOrderNofDayAsync(Guid buyerId,DateTimeOffset day)
        {
            return await DbSet.CountAsync(x => x.BuyerId == buyerId && x.OrderDate.Date == day.Date);
        }

        public async Task<List<Order>> GetOrderAsync(Guid id)
        {
            return await DbSet.Where(x => x.BuyerId == id ).ToListAsync();
        }

        
    }
}