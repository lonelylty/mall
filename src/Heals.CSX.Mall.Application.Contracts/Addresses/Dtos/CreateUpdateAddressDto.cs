using System;
using System.ComponentModel;
namespace Heals.CSX.Mall.Addresses.Dtos
{
    [Serializable]
    public class CreateUpdateAddressDto
    {
        public string ClinicCode { get; set; }

        public string ClinicName { get; set; }

        public string Contacts { get; set; }

        public string Phone { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAccount { get; set; }

        public string Remarks { get; set; }

        public string HealsRemarks { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }
    }
}