using System;
using Volo.Abp.Application.Dtos;

namespace Heals.CSX.Mall.Orders.Dtos
{
    [Serializable]
    public class ProductItemOrderedDto : AuditedEntityDto<Guid>
    {
        public Guid ProductId { get; set; }

        public string ProductNo { get; set; }

        public string ProductName { get; set; }

        public string PictureUri { get; set; }
    }
}