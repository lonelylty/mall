using System;
using Volo.Abp.Application.Dtos;

namespace Heals.CSX.Mall.Orders.Dtos
{
    [Serializable]
    public class OrderItemDto : AuditedEntityDto<Guid>
    {
        public Guid ItemOrderedId { get; set; }

        public ProductItemOrderedDto ItemOrdered { get; set; }

        public decimal UnitPrice { get; set; }

        public int Units { get; set; }
    }
}