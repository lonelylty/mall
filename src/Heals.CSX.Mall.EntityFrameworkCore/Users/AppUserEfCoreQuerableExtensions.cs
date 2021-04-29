using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Heals.CSX.Mall.Users
{
    public static class AppUserEfCoreQueryableExtensions
    {
        public static IQueryable<AppUser> IncludeDetails(this IQueryable<AppUser> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}