using System;
using System.Collections.Generic;
using System.Text;

namespace Heals.CSX.Mall.Users.Dtos
{
    public class UserSession
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Computer { get; set; }

        public string ClinicCode { get; set; }

        public Guid ClinicId { get; set; }

        public Guid DoctorId { get; set; }

        public string DoctorCode { get; set; }

        public string Token { get; set; }
    }
}
