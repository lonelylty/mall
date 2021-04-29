using System;
using System.Collections.Generic;
using System.Text;

namespace Heals.CSX.Mall.AppUsers
{
    public static class AppUserConsts
    {
        public const int MaxClinicCodeLength = 64;

        public const int MaxDoctorCodeLength = 128;

        public const int MaxPasswordTextLength = 128;

        public const int UserTokenExpiresInMinute = 43200;

        public const string ClaimTypeClinicCode = "cliniccode";

        public const string ClaimTypeDoctorCode = "doctorcode";

    }
}
