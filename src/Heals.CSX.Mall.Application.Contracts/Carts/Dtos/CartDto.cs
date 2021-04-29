using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Heals.CSX.Mall.Carts.Dtos
{
    [Serializable]
    public class CartDto : AuditedEntityDto<Guid>
    {
        public Guid BuyerId { get; set; }

        public List<CartItemDto> Items { get; set; }
    }
}