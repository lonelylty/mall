using Microsoft.AspNetCore.Mvc;

namespace Heals.CSX.Mall.Web.Pages
{
    public class IndexModel : MallPageModel
    {
        public IActionResult OnGet()
        {
            return Redirect("/swagger");
        }
    }
}