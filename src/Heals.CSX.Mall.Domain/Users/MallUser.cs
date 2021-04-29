using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heals.CSX.Mall.Users
{
    public class MallUser : IdentityUser<Guid>
    {
        public string ClinicCode { get; set; }
        public string DoctorCode { get; set; }
        public string PasswordText { get; set; }
    }
}
