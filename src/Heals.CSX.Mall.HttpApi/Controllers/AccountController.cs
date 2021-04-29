using Heals.CSX.Mall.Models;
using Heals.CSX.Mall.Products;
using Heals.CSX.Mall.Users;
using Heals.CSX.Mall.Users.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Heals.CSX.Mall.Controllers
{

    [ApiController]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/mall/account")]
    public class AccountController : MallController
    {
        
        private readonly IAppUserAppService _service;

        public AccountController(IAppUserAppService service)
        : base(service.UserSessionManager)
        {
            _service = service;
        }

        /// <summary>
        /// Login return token
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            var signInResult = await _service.LoginAsync(loginDto);

            if (signInResult.Item1)
            {
                var userTokenDto = signInResult.Item2;
                HttpContext.User = signInResult.Item3;
                return Success(userTokenDto, "login and returned token successfully.");
            }
            else
            {
                return Failed(ErrorCode.LoginFail, "user name and password is not matched.");
            }
        }

        [HttpPost]
        [Route("registerToken")]
        public async Task<IActionResult> RegisterAsync(RegisterDto registerDto)
        {
            var res = await _service.RegisterAsync(registerDto);

            if (string.IsNullOrEmpty(res.Item1))
            {
                return Success(res.Item2, "Register Mall Token successfully.");
            }
            else
            {
                return Failed(ErrorCode.CreateFail, res.Item1);
            }
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> LogoutAsync(LogoutDto logoutDto)
        {
            if (string.IsNullOrEmpty(logoutDto.UserName))
            {
                return Failed(Models.ErrorCode.FormatError, "user name could not be empty.");
            }

            await _service.LogoutAsync();

            _userSessionManager.DeleteUserSession(logoutDto.UserName);

            return Success(logoutDto, "Logout successfully.");
        }
    }
}
