using System;
using System.Threading.Tasks;
using Heals.CSX.Mall.Addresses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Heals.CSX.Mall.Addresses
{
    public interface IAddressAppService :
        ICrudAppService< 
            AddressDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateAddressDto,
            CreateUpdateAddressDto>
    {
        Task<AddressDto> GetAsync(string clinicCode);
    }
}