using System;
using Heals.CSX.Mall.Products.Dtos;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using Heals.CSX.Mall.Controllers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Heals.CSX.Mall.Products
{
    [ApiController]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/mall/product")]
    public class ProductController : MallController//, IProductAppService
    {
        private readonly IProductAppService _service;

        public ProductController(IProductAppService service)
        {
            _service = service;
        }


        [HttpPost]
        public virtual Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ProductDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ProductDto>> GetListAsync([FromQuery]PagedAndSortedResultRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpGet]
        [Route("catalogs")]
        public virtual List<CatalogTypeDto> GetCatalogTypeListAsync()
        {
            return _service.GetCatalogTypeListAsync();
        }


        [HttpPost]
        [Route("batchCreate")]
        public virtual Task<List<ProductDto>> BatchCreateAsync(List<CreateUpdateProductDto> input)
        {
            //throw new NotImplementedException();
            return _service.BatchCreateAsync(input);
        }
    }
}