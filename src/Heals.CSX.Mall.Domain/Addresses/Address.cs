using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Heals.CSX.Mall.Addresses
{
    public class Address : FullAuditedAggregateRoot<Guid>
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

        protected Address()
        {
        }

        public Address(
            Guid id,
            string clinicCode,
            string clinicName,
            string contacts,
            string phone,
            string customerName,
            string customerAccount,
            string remarks,
            string healsRemarks,
            string street,
            string city,
            string state,
            string country,
            string zipCode
        ) : base(id)
        {
            ClinicCode = clinicCode;
            ClinicName = clinicName;
            Contacts = contacts;
            Phone = phone;
            CustomerName = customerName;
            CustomerAccount = customerAccount;
            Remarks = remarks;
            HealsRemarks = healsRemarks;
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        public string ShippingAddress => $"{Country} {State} {City} {Street}";
    }
}
