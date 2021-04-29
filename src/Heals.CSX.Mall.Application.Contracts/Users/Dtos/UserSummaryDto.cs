using System;
using System.Collections.Generic;
using System.Text;

namespace Heals.CSX.Mall.Users.Dtos
{
    public class UserSummaryDto
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string ClinicCode { get; set; }

        public string DoctorCode { get; set; }
    }
}
