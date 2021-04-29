using System;
using System.Threading.Tasks;
using Heals.CSX.Mall.Users;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Heals.CSX.Mall.EntityFrameworkCore.Users
{
    public class AppUserRepositoryTests : MallEntityFrameworkCoreTestBase
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUserRepositoryTests()
        {
            _appUserRepository = GetRequiredService<IAppUserRepository>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
        */
    }
}
