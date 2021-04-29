using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Heals.CSX.Mall.Orders.Dtos;
using Heals.CSX.Mall.Products.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Heals.CSX.Mall.Orders
{
    public interface IOrderAppService :
        ICrudAppService< 
            OrderDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateOrderDto,
            UpdateOrderDto>
    {
        Task<OrderDto> RepeatOrderAsync(Guid id);
        Task<List<OrderDto>> GetOrdersAsync(Guid id);

        Task SendEmail(MallEmailOrderInfo emailInfo, string to);

        List<CatalogTypeDto> GetOrderCatalogListAsync();

        Task<PagedResultDto<OrderDto>> GetListAsync(OrderListRequestDto input);
    }
}