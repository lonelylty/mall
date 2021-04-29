using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Heals.CSX.Mall.Orders;
using Heals.CSX.Mall.Orders.Dtos;
using Heals.CSX.Mall.Web.Pages.Orders.ProductItemOrdered.ViewModels;

namespace Heals.CSX.Mall.Web.Pages.Orders.ProductItemOrdered
{
    public class EditModalModel : MallPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditProductItemOrderedViewModel ViewModel { get; set; }

        private readonly IProductItemOrderedAppService _service;

        public EditModalModel(IProductItemOrderedAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<ProductItemOrderedDto, CreateEditProductItemOrderedViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditProductItemOrderedViewModel, CreateUpdateProductItemOrderedDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}