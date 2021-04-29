using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Heals.CSX.Mall.Web.Pages.Carts.Cart.ViewModels
{
    public class CreateEditCartViewModel
    {
        [Display(Name = "CartBuyerId")]
        public Guid BuyerId { get; set; }

        //[Display(Name = "CartItems")]
        //public List<CartItem> Items { get; set; }
    }
}