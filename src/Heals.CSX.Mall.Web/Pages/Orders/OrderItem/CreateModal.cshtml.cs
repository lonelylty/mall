using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Heals.CSX.Mall.Orders;
using Heals.CSX.Mall.Orders.Dtos;
using Heals.CSX.Mall.Web.Pages.Orders.OrderItem.ViewModels;

namespace Heals.CSX.Mall.Web.Pages.Orders.OrderItem
{
    public class CreateModalModel : MallPageModel
    {
        [BindProperty]
        public CreateEditOrderItemViewModel ViewModel { get; set; }

        private readonly IOrderItemAppService _service;

        public CreateModalModel(IOrderItemAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditOrderItemViewModel, CreateUpdateOrderItemDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}