using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Heals.CSX.Mall.Carts;
using Heals.CSX.Mall.Carts.Dtos;
using Heals.CSX.Mall.Web.Pages.Carts.Cart.ViewModels;

namespace Heals.CSX.Mall.Web.Pages.Carts.Cart
{
    public class EditModalModel : MallPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditCartViewModel ViewModel { get; set; }

        private readonly ICartAppService _service;

        public EditModalModel(ICartAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<CartDto, CreateEditCartViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCartViewModel, CreateUpdateCartDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}