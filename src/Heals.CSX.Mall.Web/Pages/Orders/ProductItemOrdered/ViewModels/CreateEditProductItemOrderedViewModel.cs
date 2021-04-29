using System;

using System.ComponentModel.DataAnnotations;

namespace Heals.CSX.Mall.Web.Pages.Orders.ProductItemOrdered.ViewModels
{
    public class CreateEditProductItemOrderedViewModel
    {
        [Display(Name = "ProductItemOrderedProductId")]
        public Guid ProductId { get; set; }

        [Display(Name = "ProductItemOrderedProductSeqId")]
        public string ProductSeqId { get; set; }

        [Display(Name = "ProductItemOrderedProductName")]
        public string ProductName { get; set; }

        [Display(Name = "ProductItemOrderedPictureUri")]
        public string PictureUri { get; set; }
    }
}