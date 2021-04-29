using Heals.CSX.Mall.Localization;
using Heals.CSX.Mall.Models;
using Heals.CSX.Mall.Users;
using Heals.CSX.Mall.Users.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Users;

namespace Heals.CSX.Mall.Controllers
{
    /* Inherit your controllers from this class.
     */
    [Authorize]
    public abstract class MallController : AbpController
    {
        protected MallController()
        {
            LocalizationResource = typeof(MallResource);
        }


        protected readonly IUserSessionManager _userSessionManager;

        protected MallController(IUserSessionManager userSessionManager)
        {
            _userSessionManager = userSessionManager;
        }

        public UserSession CurrentSession
        {
            get
            {
                return _userSessionManager.GetCurrentSession();
            }
        }


        /// <summary>
        /// Success
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="entityForAuditing"></param>
        /// <returns></returns>
        public static InvokeResult<T> Success<T>(T data = default, string message = null, object entityForAuditing = null)
        {
            return new InvokeResult<T>(default, ErrorCode.Success, null)
            {
                Data = data,
                Code = ErrorCode.Success,
                Message = message ?? ((Enum)(object)ErrorCode.Success).GetDescription(),
                DataForAudit = entityForAuditing,
            };
        }


        public static InvokeResult<T> Success<T>(T data, object entityForAuditing)
        {
            return Success(data, message: null, entityForAuditing);
        }

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static InvokeResult<string> Success(string message = null)
        {
            return new InvokeResult<string>(null, ErrorCode.Success, null)
            {
                Code = ErrorCode.Success,
                Message = (message ?? ((Enum)(object)ErrorCode.Success).GetDescription())
            };
        }

        /// <summary>
        /// Failed
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static InvokeResult<string> Failed(ErrorCode code = ErrorCode.Unknown, string message = null)
        {
            return new InvokeResult<string>(null, ErrorCode.Success, null)
            {
                Code = code,
                Message = (message ?? ((Enum)(object)code).GetDescription())
            };
        }
    }
}