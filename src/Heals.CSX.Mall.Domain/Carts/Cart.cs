using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Heals.CSX.Mall.Carts
{
    public class Cart : FullAuditedAggregateRoot<Guid>
    {
        public Guid BuyerId { get; private set; }

        //private List<CartItem> _items = new List<CartItem>();
        //public List<CartItem> Items { get => _items; set => _items = value; }
        private readonly List<CartItem> _items = new List<CartItem>();
        
        public List<CartItem> Items => _items; 

        public Cart(Guid buyerId)
        {
            BuyerId = buyerId;
        }

        public void AddItem(Guid productId, decimal unitPrice, int quantity = 1)
        {
            if (!Items.Any(i => i.ProductId == productId))
            {
                _items.Add(new CartItem(productId, quantity, unitPrice));
                return;
            }
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
            existingItem.AddQuantity(quantity);
        }

        public void RemoveEmptyItems()
        {
            _items.RemoveAll(i => i.Quantity == 0);
        }

        public void SetNewBuyerId(Guid buyerId)
        {
            BuyerId = buyerId;
        }

        protected Cart()
        {
        }

        public Cart(
            Guid id,
            Guid buyerId,
            List<CartItem> items
        ) : base(id)
        {
            BuyerId = buyerId;
            _items = items;
        }
    }
}
