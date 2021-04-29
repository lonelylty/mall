using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Heals.CSX.Mall.Orders;
using Heals.CSX.Mall.Orders.Dtos;
using Heals.CSX.Mall.Web.Pages.Orders.Order.ViewModels;

namespace Heals.CSX.Mall.Web.Pages.Orders.Order
{
    public class CreateModalModel : MallPageModel
    {
        [BindProperty]
        public CreateEditOrderViewModel ViewModel { get; set; }

        private readonly IOrderAppService _service;

        public CreateModalModel(IOrderAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditOrderViewModel, CreateOrderDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}