using System;
using Heals.CSX.Mall.Permissions;
using Heals.CSX.Mall.Addresses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Heals.CSX.Mall.Addresses
{
    public class AddressAppService : CrudAppService<Address, AddressDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateAddressDto, CreateUpdateAddressDto>,
        IAddressAppService
    {
        //protected override string GetPolicyName { get; set; } = MallPermissions.Address.Default;
        //protected override string GetListPolicyName { get; set; } = MallPermissions.Address.Default;
        //protected override string CreatePolicyName { get; set; } = MallPermissions.Address.Create;
        //protected override string UpdatePolicyName { get; set; } = MallPermissions.Address.Update;
        //protected override string DeletePolicyName { get; set; } = MallPermissions.Address.Delete;

        private readonly IAddressRepository _repository;
        
        public AddressAppService(IAddressRepository repository) : base(repository)
        {
            _repository = repository;
        }


        public async Task<AddressDto> GetAsync(string clinicCode)
        {
            var address = await _repository.FirstOrDefaultAsync(t => t.ClinicCode == clinicCode);
            return await MapToGetOutputDtoAsync(address);
        }
    }
}
