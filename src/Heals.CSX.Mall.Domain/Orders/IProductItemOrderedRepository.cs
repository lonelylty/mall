using System;
using Volo.Abp.Domain.Repositories;

namespace Heals.CSX.Mall.Orders
{
    public interface IProductItemOrderedRepository : IRepository<ProductItemOrdered, Guid>
    {
    }
}