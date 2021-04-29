using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Heals.CSX.Mall.Pages
{
    public class Index_Tests : MallWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
