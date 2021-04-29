using Heals.CSX.Mall.Addresses.Dtos;
using Heals.CSX.Mall.Users.Dtos;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Heals.CSX.Mall.Orders.Dtos
{
    [Serializable]
    public class OrderDto : AuditedEntityDto<Guid>
    {
        public string OrderNo { get; set; }

        public Guid BuyerId { get; set; }

        public AppUserDto Buyer { get; set; }

        public Guid ShipToAddressId { get; set; }

        public AddressDto ShipToAddress { get; set; }

        public OrderStatus Status { get; set; }

        public DateTimeOffset OrderDate { get; set; }

        public DateTimeOffset? TargetDeliveryDate { get; set; }

        public DateTimeOffset? ActualDeliveryDate { get; set; }

        public IReadOnlyCollection<OrderItemDto> OrderItems { get; set; }
    }
}