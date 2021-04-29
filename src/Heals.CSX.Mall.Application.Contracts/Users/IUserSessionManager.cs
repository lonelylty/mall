using Heals.CSX.Mall.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heals.CSX.Mall.Users
{
    public interface IUserSessionManager
    {
        UserSession GetUserSession(string sessionKey);

        UserSession GetCurrentSession();

        void SetUserSession(string sessionKey, UserSession userSession);

        void DeleteUserSession(string sessionKey);
    }
}
