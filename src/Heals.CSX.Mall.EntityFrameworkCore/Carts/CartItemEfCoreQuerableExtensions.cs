using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Heals.CSX.Mall.Carts
{
    public static class CartItemEfCoreQueryableExtensions
    {
        public static IQueryable<CartItem> IncludeDetails(this IQueryable<CartItem> queryable, bool include = true)
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