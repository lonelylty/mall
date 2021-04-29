using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Heals.CSX.Mall.Users.Dtos
{
    public class RegisterDto : LoginDto
    {
        [Required]
        public string CSXAccessToken { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string ClinicAddress { get; set; }
    }
}
