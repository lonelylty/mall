using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Heals.CSX.Mall.Orders
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {

        Task<int> GetUserOrderNofDayAsync(Guid buyerId, DateTimeOffset day);

        Task<List<Order>> GetOrderAsync(Guid id);
    }
}