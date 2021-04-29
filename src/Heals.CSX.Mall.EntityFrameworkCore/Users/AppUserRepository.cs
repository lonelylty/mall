using System;
using Heals.CSX.Mall.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Heals.CSX.Mall.Users
{
    public class AppUserRepository : EfCoreRepository<MallDbContext, AppUser, Guid>, IAppUserRepository
    {
        public AppUserRepository(IDbContextProvider<MallDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}