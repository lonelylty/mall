using System;
using Heals.CSX.Mall.Permissions;
using Heals.CSX.Mall.Orders.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Heals.CSX.Mall.Orders
{
    public class OrderItemAppService : CrudAppService<OrderItem, OrderItemDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateOrderItemDto, CreateUpdateOrderItemDto>,
        IOrderItemAppService
    {
        protected override string GetPolicyName { get; set; } = MallPermissions.OrderItem.Default;
        protected override string GetListPolicyName { get; set; } = MallPermissions.OrderItem.Default;
        protected override string CreatePolicyName { get; set; } = MallPermissions.OrderItem.Create;
        protected override string UpdatePolicyName { get; set; } = MallPermissions.OrderItem.Update;
        protected override string DeletePolicyName { get; set; } = MallPermissions.OrderItem.Delete;

        private readonly IOrderItemRepository _repository;
        
        public OrderItemAppService(IOrderItemRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
