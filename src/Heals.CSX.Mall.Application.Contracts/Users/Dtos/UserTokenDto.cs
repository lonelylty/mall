using System;
using System.Collections.Generic;
using System.Text;

namespace Heals.CSX.Mall.Users.Dtos
{
    public class UserTokenDto
    {
        public string Token { get; set; }

        public DateTime TokenExpireOn { get; set; }

        public UserSummaryDto UserInfo { get; set; }
    }
}
