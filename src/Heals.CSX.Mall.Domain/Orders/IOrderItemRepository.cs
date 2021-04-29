using System;
using Volo.Abp.Domain.Repositories;

namespace Heals.CSX.Mall.Orders
{
    public interface IOrderItemRepository : IRepository<OrderItem, Guid>
    {
    }
}