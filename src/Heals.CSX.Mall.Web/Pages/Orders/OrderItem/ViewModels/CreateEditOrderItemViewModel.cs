using Heals.CSX.Mall.Orders.Dtos;
using System;

using System.ComponentModel.DataAnnotations;

namespace Heals.CSX.Mall.Web.Pages.Orders.OrderItem.ViewModels
{
    public class CreateEditOrderItemViewModel
    {
        [Display(Name = "OrderItemItemOrderedId")]
        public Guid ItemOrderedId { get; set; }

        [Display(Name = "OrderItemItemOrdered")]
        public ProductItemOrderedDto ItemOrdered { get; set; }

        [Display(Name = "OrderItemUnitPrice")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "OrderItemUnits")]
        public int Units { get; set; }
    }
}