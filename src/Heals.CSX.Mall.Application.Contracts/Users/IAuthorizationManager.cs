using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Heals.CSX.Mall.Users.Dtos;

namespace Heals.CSX.Mall.Users
{
    public interface IAuthorizationManager
    {
        Task<string> CreateTokenAsync(AppUserDto user, params Claim[] additionalClaims);
    }
}
