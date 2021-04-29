using System;

using System.ComponentModel.DataAnnotations;

namespace Heals.CSX.Mall.Web.Pages.Addresses.Address.ViewModels
{
    public class CreateEditAddressViewModel
    {
        [Display(Name = "AddressClinicCode")]
        public string ClinicCode { get; set; }

        [Display(Name = "AddressClinicName")]
        public string ClinicName { get; set; }

        [Display(Name = "AddressContacts")]
        public string Contacts { get; set; }

        [Display(Name = "AddressPhone")]
        public string Phone { get; set; }

        [Display(Name = "AddressCustomerName")]
        public string CustomerName { get; set; }

        [Display(Name = "AddressCustomerAccount")]
        public string CustomerAccount { get; set; }

        [Display(Name = "AddressRemarks")]
        public string Remarks { get; set; }

        [Display(Name = "AddressHealsRemarks")]
        public string HealsRemarks { get; set; }

        [Display(Name = "AddressStreet")]
        public string Street { get; set; }

        [Display(Name = "AddressCity")]
        public string City { get; set; }

        [Display(Name = "AddressState")]
        public string State { get; set; }

        [Display(Name = "AddressCountry")]
        public string Country { get; set; }

        [Display(Name = "AddressZipCode")]
        public string ZipCode { get; set; }
    }
}