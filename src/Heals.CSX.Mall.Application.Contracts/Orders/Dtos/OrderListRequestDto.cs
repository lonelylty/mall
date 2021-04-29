using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Heals.CSX.Mall.Orders.Dtos
{
    public class OrderListRequestDto : PagedAndSortedResultRequestDto
    {
        public string OrderNo { get; set; }
        [Required]
        public Guid BuyerId { get; set; }
        [Required]
        public OrderCatalog OrderCatalog { get; set; }
        [Required]
        public DateTime OrderStartDate { get; set; }
        [Required]
        public DateTime OrderEndDate { get; set; }

        //OrderNo
        //BuyerId
        //Status
        //OrderStartDate
        //OrderEndDate
    }
}
