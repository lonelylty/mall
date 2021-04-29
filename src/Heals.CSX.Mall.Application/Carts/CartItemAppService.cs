using System;
using Heals.CSX.Mall.Permissions;
using Heals.CSX.Mall.Carts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Heals.CSX.Mall.Carts
{
    public class CartItemAppService : CrudAppService<CartItem, CartItemDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCartItemDto, CreateUpdateCartItemDto>,
        ICartItemAppService
    {
        protected override string GetPolicyName { get; set; } = MallPermissions.CartItem.Default;
        protected override string GetListPolicyName { get; set; } = MallPermissions.CartItem.Default;
        protected override string CreatePolicyName { get; set; } = MallPermissions.CartItem.Create;
        protected override string UpdatePolicyName { get; set; } = MallPermissions.CartItem.Update;
        protected override string DeletePolicyName { get; set; } = MallPermissions.CartItem.Delete;

        private readonly ICartItemRepository _repository;
        
        public CartItemAppService(ICartItemRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
