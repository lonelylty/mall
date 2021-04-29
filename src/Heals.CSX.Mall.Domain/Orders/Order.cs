using Ardalis.GuardClauses;
using Heals.CSX.Mall.Addresses;
using Heals.CSX.Mall.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace Heals.CSX.Mall.Orders
{
    [DisableAuditingAttribute]
    public class Order : FullAuditedAggregateRoot<Guid>
    {
        public Order(Guid buyerId, Address shipToAddress, List<OrderItem> items)
        {
            Guard.Against.NullOrEmpty(buyerId, nameof(buyerId));
            Guard.Against.Null(shipToAddress, nameof(shipToAddress));
            Guard.Against.Null(items, nameof(items));

            BuyerId = buyerId;
            ShipToAddress = shipToAddress;
            _orderItems = items;
        }

        //auto generated, unique ID among the whole site, max length 16 digits
        //Oroder number generation rule: <clinicID><ddmmyyyy><increment number>
        //increment number is 4 digits
        //For example: 152260320210001
        public string OrderNo { get;  set; }


        public Guid BuyerId { get;  set; } // FK for Buyer reference


        public Guid ShipToAddressId { get; set; } // FK for Address reference

        public Address ShipToAddress { get;  set; }


        public OrderStatus Status { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? TargetDeliveryDate { get; set; }
        public DateTimeOffset? ActualDeliveryDate { get; set; }

        // DDD Patterns comment
        // Using a private collection field, better for DDD Aggregate's encapsulation
        // so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
        // but only through the method Order.AddOrderItem() which includes behavior.
        private List<OrderItem> _orderItems = new List<OrderItem>();

        // Using List<>.AsReadOnly() 
        // This will create a read only wrapper around the private list so is protected against "external updates".
        // It's much cheaper than .ToList() because it will not have to copy all items in a new collection. (Just one heap alloc for the wrapper instance)
        //https://msdn.microsoft.com/en-us/library/e78dcd75(v=vs.110).aspx 
        public List<OrderItem> OrderItems => _orderItems;

        public decimal Total()
        {
            var total = 0m;
            foreach (var item in _orderItems)
            {
                total += item.UnitPrice * item.Units;
            }
            return total;
        }


        public int QtyTotal()
        {
            var total = 0;
            foreach (var item in _orderItems)
            {
                total += item.Units;
            }
            return total;
        }

        protected Order()
        {
        }

        public Order(
            Guid id,
            string orderNo,
            Guid buyerId,
            Guid shipToAddressId,
            //Address shipToAddress,
            OrderStatus status,
            DateTimeOffset orderDate,
            DateTimeOffset? targetDeliveryDate,
            DateTimeOffset? actualDeliveryDate,
            List<OrderItem> orderItems
        ) : base(id)
        {
            OrderNo = orderNo;
            BuyerId = buyerId;
            ShipToAddressId = shipToAddressId;
            //ShipToAddress = shipToAddress;
            Status = status;
            OrderDate = orderDate;
            TargetDeliveryDate = targetDeliveryDate;
            ActualDeliveryDate = actualDeliveryDate;
            _orderItems = orderItems;
        }
    }
}
