using System;
using System.Threading.Tasks;
using Heals.CSX.Mall.Addresses;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Heals.CSX.Mall.EntityFrameworkCore.Addresses
{
    public class AddressRepositoryTests : MallEntityFrameworkCoreTestBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressRepositoryTests()
        {
            _addressRepository = GetRequiredService<IAddressRepository>();
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
