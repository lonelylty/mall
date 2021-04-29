using System;
using Volo.Abp.Application.Dtos;

namespace Heals.CSX.Mall.Products.Dtos
{
    [Serializable]
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public Guid? ClinicId { get; set; }

        public string ClinicCode { get; set; }

        public string Name { get; set; }

        public string ProductID { get; set; }

        public string SerialNumber { get; set; }

        public string Description { get; set; }

        public string PictureUri { get; set; }

        public string Specification { get; set; }

        public string SupplierName { get; set; }

        public int Unit { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal SRP { get; set; }

        public string Color { get; set; }

        public ProductStatus StockLevel { get; set; }

        public bool Bundled { get; set; }

        public Int16 CatalogTypeId { get; set; }

        //public CatalogType CatalogType { get; set; }

        public string CatalogBrand { get; set; }
    }
}