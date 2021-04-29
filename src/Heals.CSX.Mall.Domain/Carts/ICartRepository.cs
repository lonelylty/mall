using System;
using Volo.Abp.Domain.Repositories;

namespace Heals.CSX.Mall.Carts
{
    public interface ICartRepository : IRepository<Cart, Guid>
    {
    }
}