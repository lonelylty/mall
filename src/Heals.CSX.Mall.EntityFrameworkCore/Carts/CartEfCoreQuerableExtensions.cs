using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Heals.CSX.Mall.Carts
{
    public static class CartEfCoreQueryableExtensions
    {
        public static IQueryable<Cart> IncludeDetails(this IQueryable<Cart> queryable, bool include = true)
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