using System;
using Heals.CSX.Mall.Addresses.Dtos;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using Heals.CSX.Mall.Controllers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Microsoft.AspNetCore.Authorization;

namespace Heals.CSX.Mall.Addresses
{

    [ApiController]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/mall/address")]
    //[RemoteService(Name = "MallAddress")]
    //[Route("/api/app/address")]
    public class AddressController : MallController
    {
        private readonly IAddressAppService _service;

        public AddressController(IAddressAppService service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual Task<AddressDto> CreateAsync(CreateUpdateAddressDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<AddressDto> UpdateAsync(Guid id, CreateUpdateAddressDto input)
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
        public virtual Task<AddressDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        [Route("clinicCode/{clinicCode}")]
        public virtual Task<AddressDto> GetByClinicCodeAsync(string clinicCode)
        {
            return _service.GetAsync(clinicCode);
            throw new NotImplementedException();
        }

        [HttpGet]
        public virtual Task<PagedResultDto<AddressDto>> GetListAsync([FromQuery] PagedAndSortedResultRequestDto input)
        {
            return _service.GetListAsync(input);
        }
    }
}