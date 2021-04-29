using System;
using Heals.CSX.Mall.Carts.Dtos;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using Heals.CSX.Mall.Controllers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Microsoft.AspNetCore.Authorization;

namespace Heals.CSX.Mall.Carts
{
    [ApiController]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/mall/cart")]
    //[RemoteService(Name = "MallCart")]
    public class CartController : MallController
    {
        private readonly ICartAppService _service;

        public CartController(ICartAppService service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual Task<CartDto> CreateAsync(CreateUpdateCartDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CartDto> UpdateAsync(Guid id, CreateUpdateCartDto input)
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
        public virtual Task<CartDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CartDto>> GetListAsync([FromQuery] PagedAndSortedResultRequestDto input)
        {
            return _service.GetListAsync(input);
        }
    }
}