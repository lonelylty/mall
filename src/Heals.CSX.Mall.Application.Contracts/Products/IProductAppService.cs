using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Heals.CSX.Mall.Products.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Heals.CSX.Mall.Products
{
    public interface IProductAppService :
        ICrudAppService< 
            ProductDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateProductDto,
            CreateUpdateProductDto>
    {
        List<CatalogTypeDto> GetCatalogTypeListAsync();

        Task<List<ProductDto>> BatchCreateAsync(List<CreateUpdateProductDto> input);

    }
}