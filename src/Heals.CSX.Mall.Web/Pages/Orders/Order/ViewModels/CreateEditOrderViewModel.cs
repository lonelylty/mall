using Heals.CSX.Mall.Addresses.Dtos;
using Heals.CSX.Mall.Orders;
using Heals.CSX.Mall.Orders.Dtos;
using Heals.CSX.Mall.Users.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Heals.CSX.Mall.Web.Pages.Orders.Order.ViewModels
{
    public class CreateEditOrderViewModel
    {
        [Display(Name = "OrderOrderNo")]
        public string OrderNo { get; set; }

        [Display(Name = "OrderBuyerId")]
        public Guid BuyerId { get; set; }

        [Display(Name = "OrderBuyer")]
        public AppUserDto Buyer { get; set; }

        [Display(Name = "OrderShipToAddressId")]
        public Guid ShipToAddressId { get; set; }

        [Display(Name = "OrderShipToAddress")]
        public AddressDto ShipToAddress { get; set; }

        [Display(Name = "OrderStatus")]
        public OrderStatus Status { get; set; }

        [Display(Name = "OrderOrderDate")]
        public DateTimeOffset OrderDate { get; set; }

        [Display(Name = "OrderTargetDeliveryDate")]
        public DateTimeOffset? TargetDeliveryDate { get; set; }

        [Display(Name = "OrderActualDeliveryDate")]
        public DateTimeOffset? ActualDeliveryDate { get; set; }

        [Display(Name = "OrderOrderItems")]
        public IReadOnlyCollection<OrderItemDto> OrderItems { get; set; }
    }
}