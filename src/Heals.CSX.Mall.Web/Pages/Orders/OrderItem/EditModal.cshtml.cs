using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Heals.CSX.Mall.Orders;
using Heals.CSX.Mall.Orders.Dtos;
using Heals.CSX.Mall.Web.Pages.Orders.OrderItem.ViewModels;

namespace Heals.CSX.Mall.Web.Pages.Orders.OrderItem
{
    public class EditModalModel : MallPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditOrderItemViewModel ViewModel { get; set; }

        private readonly IOrderItemAppService _service;

        public EditModalModel(IOrderItemAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<OrderItemDto, CreateEditOrderItemViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditOrderItemViewModel, CreateUpdateOrderItemDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}