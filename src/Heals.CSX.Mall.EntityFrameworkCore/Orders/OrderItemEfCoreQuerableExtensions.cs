using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Heals.CSX.Mall.Orders
{
    public static class OrderItemEfCoreQueryableExtensions
    {
        public static IQueryable<OrderItem> IncludeDetails(this IQueryable<OrderItem> queryable, bool include = true)
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