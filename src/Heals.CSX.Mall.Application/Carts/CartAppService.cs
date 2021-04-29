using System;
using Heals.CSX.Mall.Permissions;
using Heals.CSX.Mall.Carts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Linq;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Heals.CSX.Mall.Products;
using Heals.CSX.Mall.Products.Dtos;
using System.Collections.Generic;

namespace Heals.CSX.Mall.Carts
{
    public class CartAppService : CrudAppService<Cart, CartDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCartDto, CreateUpdateCartDto>,
        ICartAppService
    {
        //protected override string GetPolicyName { get; set; } = MallPermissions.Cart.Default;
        //protected override string GetListPolicyName { get; set; } = MallPermissions.Cart.Default;
        //protected override string CreatePolicyName { get; set; } = MallPermissions.Cart.Create;
        //protected override string UpdatePolicyName { get; set; } = MallPermissions.Cart.Update;
        //protected override string DeletePolicyName { get; set; } = MallPermissions.Cart.Delete;

        private readonly ICartRepository _repository;
        private readonly ICartItemRepository _cartItemRepository;

        public CartAppService(ICartRepository repository, ICartItemRepository cartItemRepository) : base(repository)
        {
            _repository = repository;
            _cartItemRepository = cartItemRepository;
        }


        public async override Task<CartDto> GetAsync(Guid id)
        {
            var query = _repository.WithDetails(x => x.Items).Where(x => x.Id == id);
            var cart = await AsyncExecuter.FirstOrDefaultAsync(query);

            var itemQuery = _cartItemRepository.WithDetails(x => x.Product).Where(x => x.CartId == id);
            var cartItem = await AsyncExecuter.ToListAsync(itemQuery);

            return await MapToGetOutputDtoAsync(cart);
            //return ObjectMapper.Map<Cart, CartDto>(cart);
            //return await Task.Run(() => { return _repository.WithDetails(x => x.Items).As<CartDto>(); });
        }

        public async override Task<PagedResultDto<CartDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var query = _repository.GetDbSet().IncludeIf(true, x => x.Items).Skip(input.SkipCount).Take(input.MaxResultCount).OrderByDescending(t=>t.CreationTime);
            var itemQuery = _cartItemRepository.IncludeIf(true, x => x.Product).Skip(input.SkipCount).Take(input.MaxResultCount).OrderByDescending(t => t.CreationTime);

            var cart = await AsyncExecuter.ToListAsync(query);
            var cartItem = await AsyncExecuter.ToListAsync(itemQuery);

            var cartDtos = ObjectMapper.Map<List<Cart>, List<CartDto>>(cart);

            return new PagedResultDto<CartDto>(cart.Count, cartDtos);
        }
    }
}
