using System;
using System.Collections.Generic;
using System.Text;

namespace Heals.CSX.Mall.Orders.Dtos
{
    [Serializable]
    public class UpdateOrderDto
    {
        //public string OrderNo { get; set; }

        //public Guid BuyerId { get; set; }


        public Guid? ShipToAddressId { get; set; }

        //public CreateUpdateAddressDto ShipToAddress { get; set; }

        public OrderStatus Status { get; set; }

        //public DateTimeOffset OrderDate { get; set; }

        //public DateTimeOffset? TargetDeliveryDate { get; set; }

        //public DateTimeOffset? ActualDeliveryDate { get; set; }

        //public List<CreateUpdateOrderItemDto> OrderItems { get; set; }
    }
}
