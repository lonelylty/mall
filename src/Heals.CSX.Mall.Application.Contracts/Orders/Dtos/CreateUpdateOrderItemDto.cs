using System;
using System.ComponentModel;
namespace Heals.CSX.Mall.Orders.Dtos
{
    [Serializable]
    public class CreateUpdateOrderItemDto
    {
        //public Guid ItemOrderedId { get; set; }

        public CreateUpdateProductItemOrderedDto ItemOrdered { get; set; }

        public decimal UnitPrice { get; set; }

        public int Units { get; set; }
    }
}