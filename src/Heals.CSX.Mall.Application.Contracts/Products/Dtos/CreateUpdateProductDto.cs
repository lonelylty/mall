using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Heals.CSX.Mall.Products.Dtos
{
    [Serializable]
    public class CreateUpdateProductDto
    {
        protected CreateUpdateProductDto()
        {
        }

        public Guid? ClinicId { get; set; }

        [Required(ErrorMessage = "{0}±ØÐë"),MaxLength(ProductConsts.MaxClinicCodeLength, ErrorMessage="{0}")]
        public string ClinicCode { get; set; }

        public string Name { get; set; }

        //public string ProductID { get; set; }

        public string SerialNumber { get; set; }

        public string Description { get; set; }

        //[Description("PictureBase64 string")]
        public string PictureBase64 { get; set; }

        public string Specification { get; set; }

        public string SupplierName { get; set; }

        public int Unit { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal SRP { get; set; }

        public string Color { get; set; }

        public ProductStatus StockLevel { get; set; }

        public bool Bundled { get; set; }

        public Int16 CatalogTypeId { get; set; }

        //public string CatalogType { get; set; }

        public string CatalogBrand { get; set; }
    }
}