using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Heals.CSX.Mall.Orders
{
    public static class ProductItemOrderedEfCoreQueryableExtensions
    {
        public static IQueryable<ProductItemOrdered> IncludeDetails(this IQueryable<ProductItemOrdered> queryable, bool include = true)
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