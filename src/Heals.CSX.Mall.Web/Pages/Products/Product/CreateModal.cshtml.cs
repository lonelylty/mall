using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Heals.CSX.Mall.Products;
using Heals.CSX.Mall.Products.Dtos;
using Heals.CSX.Mall.Web.Pages.Products.Product.ViewModels;

namespace Heals.CSX.Mall.Web.Pages.Products.Product
{
    public class CreateModalModel : MallPageModel
    {
        [BindProperty]
        public CreateEditProductViewModel ViewModel { get; set; }

        private readonly IProductAppService _service;

        public CreateModalModel(IProductAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditProductViewModel, CreateUpdateProductDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}