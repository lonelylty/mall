using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Heals.CSX.Mall.AppUsers;
using Heals.CSX.Mall.Permissions;
using Heals.CSX.Mall.Products;
using Heals.CSX.Mall.Users.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Heals.CSX.Mall.Users
{
    public class AppUserAppService : CrudAppService<AppUser, AppUserDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateAppUserDto, CreateUpdateAppUserDto>,
        IAppUserAppService
    {
        //protected override string GetPolicyName { get; set; } = MallPermissions.AppUser.Default;
        //protected override string GetListPolicyName { get; set; } = MallPermissions.AppUser.Default;
        //protected override string CreatePolicyName { get; set; } = MallPermissions.AppUser.Create;
        //protected override string UpdatePolicyName { get; set; } = MallPermissions.AppUser.Update;
        //protected override string DeletePolicyName { get; set; } = MallPermissions.AppUser.Delete;

        private readonly IAppUserRepository _repository;
        private readonly IConfiguration _configuration;

        //identity
        private readonly UserManager<MallUser> _userManager;
        private readonly SignInManager<MallUser> _signInManager;

        //custom user manager
        private readonly IAuthorizationManager _authorizationManager;
        private readonly IUserSessionManager _userSessionManager;

        public IUserSessionManager UserSessionManager { get => _userSessionManager; }


        public AppUserAppService(IAppUserRepository repository,
             IConfiguration configuration, 
             IAuthorizationManager authorizationManager,
             UserManager<MallUser> userManager,
             SignInManager<MallUser> signInManager,
             IUserSessionManager userSessionManager
            ) : base(repository)
        {
            _repository = repository;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _authorizationManager = authorizationManager;
            _userSessionManager = userSessionManager;


            // Configure validation logic for usernames
            _userManager.Options.User = new UserOptions()
            {
                //AllowedUserNameCharacters = false,
                //AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            _userManager.Options.Password = new PasswordOptions()
            {

                RequireDigit = false,
                RequireLowercase = false,
                RequireNonAlphanumeric = false,
                RequireUppercase = false,
                RequiredLength = 1,
                RequiredUniqueChars = 1
            };
        }


        public async Task<(bool,UserTokenDto, ClaimsPrincipal)> LoginAsync(LoginDto loginDto)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password,
                isPersistent: true, lockoutOnFailure: false);

            if (signInResult.Succeeded)
            {
                // generate token
                var user = await _userManager.FindByNameAsync(loginDto.UserName);
                var additionalClaims = GetAdditionalClaims(user);

                if (!double.TryParse(_configuration["JwtBearerOptions:ExpiresInMinute"], out double expiresInMinutes))
                {
                    expiresInMinutes = AppUserConsts.UserTokenExpiresInMinute; // default expire time: 1 month

                }

                var userDto = ObjectMapper.Map<MallUser, AppUserDto>(user);

                var encodedJwt = await _authorizationManager.CreateTokenAsync(userDto, additionalClaims.ToArray());

                // set session
                var userSummary = new UserSummaryDto
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    ClinicCode = user.ClinicCode,
                    DoctorCode = user.DoctorCode,
                };
                var userSession = new UserSession
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    ClinicCode = user.ClinicCode,
                    DoctorCode = user.DoctorCode,
                    Token = encodedJwt,
                };

                _userSessionManager.SetUserSession(user.UserName, userSession);

                return (true, new UserTokenDto
                {
                    Token = encodedJwt,
                    TokenExpireOn = DateTime.Now.AddMinutes(expiresInMinutes),
                    UserInfo = userSummary,
                }, await _signInManager.CreateUserPrincipalAsync(user));
            }
            else
            {
                return (false, new UserTokenDto { }, new ClaimsPrincipal { });
            }

        }


        public async Task<(string, UserTokenDto)> RegisterAsync(RegisterDto registerDto)
        {

            var jwtSecurityTokens = new JwtSecurityTokenHandler().ReadJwtToken(registerDto.CSXAccessToken);
            if (jwtSecurityTokens.Issuer != _configuration["JwtBearerOptions:Issuer"])
                return ("Csx Access Token verification failed ", new UserTokenDto());

            var user = new MallUser
            {
                UserName = registerDto.UserName,
                ClinicCode = registerDto.ClinicCode,
                DoctorCode = registerDto.DoctorCode,
                Email = registerDto.Email,
                PasswordText = registerDto.Password,
                PhoneNumber = registerDto.PhoneNumber,
            };

            var res = await _userManager.CreateAsync(user, registerDto.Password);

            var message = "";

            if (res.Succeeded)
            {
                var userId = await _userManager.GetUserIdAsync(user);

                // generate token
                var additionalClaims = GetAdditionalClaims(user);

                if (!double.TryParse(_configuration["JwtBearerOptions:ExpiresInMinute"], out double expiresInMinutes))
                {
                    expiresInMinutes = AppUserConsts.UserTokenExpiresInMinute; // default expire time: 1 month
                }

                var userDto = ObjectMapper.Map<MallUser, AppUserDto>(user);
                var encodedJwt = await _authorizationManager.CreateTokenAsync(userDto, additionalClaims.ToArray());

                return (message, new UserTokenDto
                {
                    UserInfo= new UserSummaryDto {
                        UserId = new Guid(userId),
                        Email = user.Email,
                        PhoneNo = user.PhoneNumber,
                        UserName = user.UserName,
                        ClinicCode = user.ClinicCode,
                        DoctorCode = user.DoctorCode
                    },
                    TokenExpireOn = DateTime.Now.AddMinutes(expiresInMinutes),
                    Token = encodedJwt,
                });
            }

            foreach (var error in res.Errors)
            {
                message += error.Description;
            }
            return (message, new UserTokenDto());
        }


        public async Task LogoutAsync() 
        {
            await _signInManager.SignOutAsync();
        }

        private List<Claim> GetAdditionalClaims(MallUser user)
        {
            var additionalClaims = new List<Claim> { };
            if (user != null)
            {
                additionalClaims.Add(new Claim(AppUserConsts.ClaimTypeClinicCode, user.ClinicCode));
                additionalClaims.Add(new Claim(AppUserConsts.ClaimTypeDoctorCode, user.DoctorCode));
            }

            return additionalClaims;
        }
    }
}
