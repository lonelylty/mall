using System;

using System.ComponentModel.DataAnnotations;

namespace Heals.CSX.Mall.Web.Pages.Carts.CartItem.ViewModels
{
    public class CreateEditCartItemViewModel
    {
        [Display(Name = "CartItemUnitPrice")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "CartItemQuantity")]
        public int Quantity { get; set; }

        [Display(Name = "CartItemProductId")]
        public Guid ProductId { get; set; }

        //[Display(Name = "CartItemProduct")]
        //public Product Product { get; set; }

        [Display(Name = "CartItemCartId")]
        public Guid CartId { get; set; }
    }
}