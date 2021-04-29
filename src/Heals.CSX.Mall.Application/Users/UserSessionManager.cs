using Heals.CSX.Mall.AppUsers;
using Heals.CSX.Mall.Users.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Heals.CSX.Mall.Users
{
    public class UserSessionManager : IUserSessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private ISession Session => _httpContextAccessor.HttpContext.Session;

        private ClaimsPrincipal CurrentUser => _httpContextAccessor.HttpContext.User;

        public UserSessionManager(IHttpContextAccessor httpContextAccessor, IMemoryCache cache)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void DeleteUserSession(string sessionKey)
        {
            if (string.IsNullOrEmpty(sessionKey))
            {
                throw new ArgumentException($"parameter value is null or empty.", nameof(sessionKey));
            }

            Session.Remove(sessionKey);
        }

        public UserSession GetCurrentSession()
        {
            var userName = CurrentUser?.FindFirst(AppUserConsts.ClaimTypeClinicCode)?.Value;
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }

            var userId = CurrentUser?.FindFirst(AppUserConsts.ClaimTypeClinicCode)?.Value;
            var clinicId = CurrentUser?.FindFirst(AppUserConsts.ClaimTypeClinicCode)?.Value;
            var clinicCode = CurrentUser?.FindFirst(AppUserConsts.ClaimTypeClinicCode)?.Value;
            var doctorId = CurrentUser?.FindFirst(AppUserConsts.ClaimTypeClinicCode)?.Value;
            var doctorCode = CurrentUser?.FindFirst(AppUserConsts.ClaimTypeClinicCode)?.Value;
            var healsTokenStr = CurrentUser?.FindFirst(AppUserConsts.ClaimTypeClinicCode)?.Value;

            var userSession = new UserSession
            {
                UserId = !string.IsNullOrEmpty(userId) ? new Guid(userId) : Guid.Empty,
                UserName = userName,
                ClinicId = !string.IsNullOrEmpty(clinicId) ? new Guid(clinicId) : Guid.Empty,
                ClinicCode = clinicCode,
            };

            return userSession;
        }

        public UserSession GetUserSession(string sessionKey)
        {
            if (string.IsNullOrEmpty(sessionKey))
            {
                throw new ArgumentException($"parameter value is null or empty.", nameof(sessionKey));
            }

            var userSessionJson = Session.GetString(sessionKey);
            var userSession = !string.IsNullOrEmpty(userSessionJson)
                ? JsonConvert.DeserializeObject<UserSession>(userSessionJson)
                : null;

            return userSession;
        }

        public void SetUserSession(string sessionKey, UserSession userSession)
        {
            if (string.IsNullOrEmpty(sessionKey))
            {
                throw new ArgumentException($"parameter value is null or empty.", nameof(sessionKey));
            }

            if (userSession == null)
            {
                throw new ArgumentNullException(nameof(userSession));
            }

            var json = JsonConvert.SerializeObject(userSession);
            Session.SetString(sessionKey, json);
        }

        private void SetSession(string key, string value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = String.Empty;
                }
            }
            catch (Exception e)
            {
                value = String.Empty;
            }
            Session.SetString(key, value);
        }

        private string GetSession(string key)
        {
            var value = String.Empty;
            try
            {
                value = Session.GetString(key);
                if (string.IsNullOrWhiteSpace(value))
                    value = String.Empty;
            }
            catch (Exception e)
            {
                value = String.Empty;
            }
            return value;
        }

    }
}
