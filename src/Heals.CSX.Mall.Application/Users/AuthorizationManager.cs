using AutoMapper;
using Heals.CSX.Mall.Products;
using Heals.CSX.Mall.Users.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Heals.CSX.Mall.Users
{
    public class AuthorizationManager : IAuthorizationManager
    {
        private readonly UserManager<MallUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthorizationManager(IConfiguration configuration, UserManager<MallUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<string> CreateTokenAsync(AppUserDto userDto, params Claim[] additionalClaims)
        {
            var user = new MapperConfiguration(cfg => cfg.CreateMap<AppUserDto,MallUser>())
                .CreateMapper().Map<MallUser>(userDto);

            var claims = await _userManager.GetClaimsAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            if (!string.IsNullOrEmpty(user.Email))
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));

            claims.Add(new Claim(MallConsts.MallClaimTypeUserName, user.UserName));
            claims.Add(new Claim(MallConsts.MallClaimTypeUserId, user.Id.ToString()));

            // add additional claims
            if (additionalClaims != null)
            {
                foreach (var c in additionalClaims)
                    claims.Add(c);
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtBearerOptions:Key"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiresTime = DateTime.Now.AddMinutes(double.Parse(_configuration["JwtBearerOptions:ExpiresInMinute"]));
            var jwt = new JwtSecurityToken(
                issuer: _configuration["JwtBearerOptions:Issuer"],
                audience: _configuration["JwtBearerOptions:Audience"],
                claims,
                expires: expiresTime,
                signingCredentials: cred);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
