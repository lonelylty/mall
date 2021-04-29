using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Heals.CSX.Mall.Orders
{
    public class OrderItem : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// FK for ProductItemOrdered reference
        /// </summary>
        public Guid ItemOrderedId { get; private set; }

        public ProductItemOrdered ItemOrdered { get; private set; }

        public decimal UnitPrice { get; private set; }

        public int Units { get; private set; }


        public OrderItem(ProductItemOrdered itemOrdered, decimal unitPrice, int units)
        {
            ItemOrdered = itemOrdered;
            UnitPrice = unitPrice;
            Units = units;
        }

        protected OrderItem()
        {
        }

        public OrderItem(
            Guid id,
            Guid itemOrderedId,
            ProductItemOrdered itemOrdered,
            decimal unitPrice,
            int units
        ) : base(id)
        {
            ItemOrderedId = itemOrderedId;
            ItemOrdered = itemOrdered;
            UnitPrice = unitPrice;
            Units = units;
        }
    }
}
