using System.Threading.Tasks;

namespace Heals.CSX.Mall.Web.Pages.Products.Product
{
    public class IndexModel : MallPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
