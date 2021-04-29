using System;
using Volo.Abp.Domain.Repositories;

namespace Heals.CSX.Mall.Users
{
    public interface IAppUserRepository : IRepository<AppUser, Guid>
    {
    }
}