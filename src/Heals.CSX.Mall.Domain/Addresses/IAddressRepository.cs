using System;
using Volo.Abp.Domain.Repositories;

namespace Heals.CSX.Mall.Addresses
{
    public interface IAddressRepository : IRepository<Address, Guid>
    {
    }
}