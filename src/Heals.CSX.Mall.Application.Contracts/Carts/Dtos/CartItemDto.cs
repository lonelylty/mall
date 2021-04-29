using Heals.CSX.Mall.Products.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Heals.CSX.Mall.Carts.Dtos
{
    [Serializable]
    public class CartItemDto : AuditedEntityDto<Guid>
    {
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public Guid ProductId { get; set; }

        public ProductDto ProductDto { get; set; }

        public Guid CartId { get; set; }
    }
}