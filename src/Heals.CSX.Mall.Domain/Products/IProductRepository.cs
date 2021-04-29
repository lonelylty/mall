using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Heals.CSX.Mall.Products
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<int> GetCatalogTypeNumAsync(short catalogTypeId);

        Task BatchCreateAsync(List<Product> products);

    }
}