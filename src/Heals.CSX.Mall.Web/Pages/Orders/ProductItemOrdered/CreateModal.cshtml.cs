using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Heals.CSX.Mall.Orders;
using Heals.CSX.Mall.Orders.Dtos;
using Heals.CSX.Mall.Web.Pages.Orders.ProductItemOrdered.ViewModels;

namespace Heals.CSX.Mall.Web.Pages.Orders.ProductItemOrdered
{
    public class CreateModalModel : MallPageModel
    {
        [BindProperty]
        public CreateEditProductItemOrderedViewModel ViewModel { get; set; }

        private readonly IProductItemOrderedAppService _service;

        public CreateModalModel(IProductItemOrderedAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditProductItemOrderedViewModel, CreateUpdateProductItemOrderedDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}