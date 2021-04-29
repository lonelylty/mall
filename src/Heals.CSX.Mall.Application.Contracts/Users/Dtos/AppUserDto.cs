using System;
using Volo.Abp.Application.Dtos;

namespace Heals.CSX.Mall.Users.Dtos
{
    [Serializable]
    public class AppUserDto : AuditedEntityDto<Guid>
    {
        public string UserName { get; set; }

        //public string Name { get; set; }

        //public string Surname { get; set; }

        public string Email { get; set; }

        //public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        //public bool PhoneNumberConfirmed { get; set; }

        public string ClinicCode { get; set; }

        public string DoctorCode { get; set; }

        //public string PasswordText { get; set; }
    }
}