using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Heals.CSX.Mall.Addresses;
using Heals.CSX.Mall.Addresses.Dtos;
using Heals.CSX.Mall.Web.Pages.Addresses.Address.ViewModels;

namespace Heals.CSX.Mall.Web.Pages.Addresses.Address
{
    public class CreateModalModel : MallPageModel
    {
        [BindProperty]
        public CreateEditAddressViewModel ViewModel { get; set; }

        private readonly IAddressAppService _service;

        public CreateModalModel(IAddressAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditAddressViewModel, CreateUpdateAddressDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}