using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Heals.CSX.Mall.Carts;
using Heals.CSX.Mall.Carts.Dtos;
using Heals.CSX.Mall.Web.Pages.Carts.CartItem.ViewModels;

namespace Heals.CSX.Mall.Web.Pages.Carts.CartItem
{
    public class CreateModalModel : MallPageModel
    {
        [BindProperty]
        public CreateEditCartItemViewModel ViewModel { get; set; }

        private readonly ICartItemAppService _service;

        public CreateModalModel(ICartItemAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCartItemViewModel, CreateUpdateCartItemDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}