using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace Heals.CSX.Mall.Carts.Dtos
{
    [Serializable]
    public class CreateUpdateCartDto
    {
        public Guid BuyerId { get; set; }

        public List<CreateUpdateCartItemDto> Items { get; set; }
    }
}