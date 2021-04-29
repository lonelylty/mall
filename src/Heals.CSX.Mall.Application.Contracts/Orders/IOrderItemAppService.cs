using System;
using Heals.CSX.Mall.Orders.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Heals.CSX.Mall.Orders
{
    public interface IOrderItemAppService :
        ICrudAppService< 
            OrderItemDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateOrderItemDto,
            CreateUpdateOrderItemDto>
    {

    }
}