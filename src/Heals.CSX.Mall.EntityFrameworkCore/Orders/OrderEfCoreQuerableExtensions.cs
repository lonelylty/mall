using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Heals.CSX.Mall.Orders
{
    public static class OrderEfCoreQueryableExtensions
    {
        public static IQueryable<Order> IncludeDetails(this IQueryable<Order> queryable, bool include = true)
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