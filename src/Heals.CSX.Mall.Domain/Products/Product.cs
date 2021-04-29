using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace Heals.CSX.Mall.Products
{
    [DisableAuditingAttribute]
    public class Product : FullAuditedAggregateRoot<Guid>
    {
        public Guid? ClinicId { get; set; }
        
        public string ClinicCode { get; set; }

        public string Name { get;  set; }

        /// <summary>
        /// System auto generated, unique ID, max length 9 characters
        /// ID generation rule: <categoryID>-<5 increment digits>
        /// For example: 1-00001
        /// </summary>
        public string ProductID { get;  set; }

        /// <summary>
        /// Product manufacturing S/N
        /// </summary>
        public string SerialNumber { get;  set; }

        public string Description { get;  set; }
        
        public string PictureUri { get;  set; }

        /// <summary>
        /// allow free text, or image display
        /// </summary>
        public string Specification { get;  set; }

        public string SupplierName { get;  set; }

        public int Unit { get; set; } = 999;

        public decimal UnitPrice { get;  set; }

        /// <summary>
        /// Suggested reseller price
        /// </summary>
        public decimal SRP { get;  set; }

        public string Color { get;  set; }

        public ProductStatus StockLevel { get;  set; }

        /// <summary>
        /// Yes or No To identify whether this is a bundle or a unit item
        /// </summary>
        public bool Bundled { get;  set; }

        /// <summary>
        /// product catalog enum value
        /// </summary>
        public Int16 CatalogTypeId { get;  set; }


        public string CatalogBrand { get;  set; }

        protected Product()
        {
        }

        public Product(
            Guid id,
            Guid? clinicId,
            string clinicCode,
            string name,
            string productID,
            string serialNumber,
            string description,
            string pictureUri,
            string specification,
            string supplierName,
            int unit,
            decimal unitPrice,
            decimal sRP,
            string color,
            ProductStatus stockLevel,
            bool bundled,
            Int16 catalogTypeId,
            string catalogBrand
        ) : base(id)
        {
            ClinicId = clinicId;
            ClinicCode = clinicCode;
            Name = name;
            ProductID = productID;
            SerialNumber = serialNumber;
            Description = description;
            PictureUri = pictureUri;
            Specification = specification;
            SupplierName = supplierName;
            Unit = unit;
            UnitPrice = unitPrice;
            SRP = sRP;
            Color = color;
            StockLevel = stockLevel;
            Bundled = bundled;
            CatalogTypeId = catalogTypeId;
            CatalogBrand = catalogBrand;
        }
    }
    
}
