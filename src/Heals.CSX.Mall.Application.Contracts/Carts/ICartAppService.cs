using System;
using Heals.CSX.Mall.Carts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Heals.CSX.Mall.Carts
{
    public interface ICartAppService :
        ICrudAppService< 
            CartDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateCartDto,
            CreateUpdateCartDto>
    {

    }
}