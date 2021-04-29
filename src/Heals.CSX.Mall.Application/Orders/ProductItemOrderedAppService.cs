using System;
using Heals.CSX.Mall.Permissions;
using Heals.CSX.Mall.Orders.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Heals.CSX.Mall.Orders
{
    public class ProductItemOrderedAppService : CrudAppService<ProductItemOrdered, ProductItemOrderedDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProductItemOrderedDto, CreateUpdateProductItemOrderedDto>,
        IProductItemOrderedAppService
    {
        protected override string GetPolicyName { get; set; } = MallPermissions.ProductItemOrdered.Default;
        protected override string GetListPolicyName { get; set; } = MallPermissions.ProductItemOrdered.Default;
        protected override string CreatePolicyName { get; set; } = MallPermissions.ProductItemOrdered.Create;
        protected override string UpdatePolicyName { get; set; } = MallPermissions.ProductItemOrdered.Update;
        protected override string DeletePolicyName { get; set; } = MallPermissions.ProductItemOrdered.Delete;

        private readonly IProductItemOrderedRepository _repository;
        
        public ProductItemOrderedAppService(IProductItemOrderedRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
