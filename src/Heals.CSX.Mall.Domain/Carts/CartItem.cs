using Ardalis.GuardClauses;
using Heals.CSX.Mall.Products;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Heals.CSX.Mall.Carts
{
    public class CartItem : FullAuditedAggregateRoot<Guid>
    {

        public decimal UnitPrice { get;  set; }

        public int Quantity { get;  set; }

        /// <summary>
        /// // FK for Product reference
        /// </summary>
        public Guid ProductId { get;  set; }

        public Product Product { get; set; }

        public Guid CartId { get;  set; }


        public CartItem(Guid productId, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            SetQuantity(quantity);
        }

        public void AddQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            Quantity = quantity;
        }

        protected CartItem()
        {
        }

        public CartItem(
            Guid id,
            decimal unitPrice,
            int quantity,
            Guid productId,
            Product product,
            Guid cartId
        ) : base(id)
        {
            UnitPrice = unitPrice;
            Quantity = quantity;
            ProductId = productId;
            Product = product;
            CartId = cartId;
        }
    }
}
