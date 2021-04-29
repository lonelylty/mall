using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Heals.CSX.Mall.Users.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Heals.CSX.Mall.Users
{
    public interface IAppUserAppService :
        ICrudAppService< 
            AppUserDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateAppUserDto,
            CreateUpdateAppUserDto>
    {
        Task<(bool, UserTokenDto, ClaimsPrincipal)> LoginAsync(LoginDto loginDto);

        Task<(string, UserTokenDto)> RegisterAsync(RegisterDto registerDto);

        Task LogoutAsync();

        IUserSessionManager UserSessionManager { get; }
    }
}