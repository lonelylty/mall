using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Heals.CSX.Mall.Carts;
using Heals.CSX.Mall.Carts.Dtos;
using Heals.CSX.Mall.Web.Pages.Carts.CartItem.ViewModels;

namespace Heals.CSX.Mall.Web.Pages.Carts.CartItem
{
    public class EditModalModel : MallPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditCartItemViewModel ViewModel { get; set; }

        private readonly ICartItemAppService _service;

        public EditModalModel(ICartItemAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<CartItemDto, CreateEditCartItemViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCartItemViewModel, CreateUpdateCartItemDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}