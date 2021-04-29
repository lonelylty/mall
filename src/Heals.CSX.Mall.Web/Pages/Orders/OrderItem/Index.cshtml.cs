using System.Threading.Tasks;

namespace Heals.CSX.Mall.Web.Pages.Orders.OrderItem
{
    public class IndexModel : MallPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
