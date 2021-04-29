using System;
using System.ComponentModel;
namespace Heals.CSX.Mall.Carts.Dtos
{
    [Serializable]
    public class CreateUpdateCartItemDto
    {
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public Guid ProductId { get; set; }

        //public Product Product { get; set; }

        //public Guid CartId { get; set; }
    }
}