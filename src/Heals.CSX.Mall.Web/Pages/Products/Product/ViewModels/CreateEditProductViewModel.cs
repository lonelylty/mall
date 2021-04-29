using Heals.CSX.Mall.Products;
using System;

using System.ComponentModel.DataAnnotations;

namespace Heals.CSX.Mall.Web.Pages.Products.Product.ViewModels
{
    public class CreateEditProductViewModel
    {
        [Display(Name = "ProductClinicId")]
        public Guid? ClinicId { get; set; }

        [Display(Name = "ProductClinicCode")]
        public string ClinicCode { get; set; }

        [Display(Name = "ProductName")]
        public string Name { get; set; }

        [Display(Name = "ProductProductID")]
        public string ProductID { get; set; }

        [Display(Name = "ProductSerialNumber")]
        public string SerialNumber { get; set; }

        [Display(Name = "ProductDescription")]
        public string Description { get; set; }

        [Display(Name = "ProductPictureUri")]
        public string PictureUri { get; set; }

        [Display(Name = "ProductSpecification")]
        public string Specification { get; set; }

        [Display(Name = "ProductSupplierName")]
        public string SupplierName { get; set; }

        [Display(Name = "ProductUnit")]
        public int Unit { get; set; }

        [Display(Name = "ProductUnitPrice")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "ProductSRP")]
        public decimal SRP { get; set; }

        [Display(Name = "ProductColor")]
        public string Color { get; set; }

        [Display(Name = "ProductStockLevel")]
        public ProductStatus StockLevel { get; set; }

        [Display(Name = "ProductBundled")]
        public bool Bundled { get; set; }

        [Display(Name = "ProductCatalogTypeId")]
        public Int16 CatalogTypeId { get; set; }

        [Display(Name = "ProductCatalogType")]
        public CatalogType CatalogType { get; set; }

        [Display(Name = "ProductCatalogBrand")]
        public string CatalogBrand { get; set; }
    }
}