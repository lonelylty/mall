using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Heals.CSX.Mall.Permissions;
using Heals.CSX.Mall.Products.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Heals.CSX.Mall.Products
{
    public class ProductAppService : CrudAppService<Product, ProductDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProductDto, CreateUpdateProductDto>,
        IProductAppService
    {
        //protected override string GetPolicyName { get; set; } = MallPermissions.Product.Default;
        //protected override string GetListPolicyName { get; set; } = MallPermissions.Product.Default;
        //protected override string CreatePolicyName { get; set; } = MallPermissions.Product.Create;
        //protected override string UpdatePolicyName { get; set; } = MallPermissions.Product.Update;
        //protected override string DeletePolicyName { get; set; } = MallPermissions.Product.Delete;

        private readonly IProductRepository _repository;

        private readonly IMemoryCache _memoryCache;
        private readonly string _catalogTypeCacheKey = "catalogTypeCacheKey";
        private readonly double _catalogTypeCacheDays = 1; 


        public ProductAppService(IProductRepository repository, IMemoryCache cache) : base(repository)
        {
            _repository = repository;
            _memoryCache = cache;
        }


        public async override Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
        {
            //ProductID rules
            var rowCount = await _repository.GetCatalogTypeNumAsync(input.CatalogTypeId);
            var productId = $"{input.CatalogTypeId}-{++rowCount:D5}";

            string fileName = string.Empty;

            if (!string.IsNullOrEmpty(input.PictureBase64))
            {
                fileName = FileHelper.PictureBase64Save(input.PictureBase64, productId);
            }

            var product = new Product(id: GuidGenerator.Create(),
            input.ClinicId,
            input.ClinicCode,
            input.Name,
            productId, //input.ProductID
            input.SerialNumber,
            input.Description,
            fileName,
            input.Specification,
            input.SupplierName,
            input.Unit,
            input.UnitPrice,
            input.SRP,
            input.Color,
            input.StockLevel,
            input.Bundled,
            input.CatalogTypeId,
            input.CatalogBrand);

            await _repository.InsertAsync(product);

            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async override Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
        {

            var product = await _repository.GetAsync(id);

            string fileName = string.Empty;

            if (!string.IsNullOrEmpty(input.PictureBase64))
            {
                fileName = FileHelper.PictureBase64Save(input.PictureBase64, product.ProductID);
            }

            if (input.ClinicId != null) product.ClinicId = input.ClinicId;
            if (!string.IsNullOrEmpty(input.ClinicCode)) product.ClinicCode = input.ClinicCode;
            if (!string.IsNullOrEmpty(input.Name)) product.Name = input.Name;
            if (!string.IsNullOrEmpty(input.SerialNumber)) product.SerialNumber = input.SerialNumber;
            if (!string.IsNullOrEmpty(input.Description)) product.Description = input.Description;
            if (!string.IsNullOrEmpty(fileName)) product.PictureUri = fileName;
            if (!string.IsNullOrEmpty(input.Specification)) product.Specification = input.Specification;
            if (!string.IsNullOrEmpty(input.SupplierName)) product.SupplierName = input.SupplierName;
            if (input.Unit != 0) product.Unit = input.Unit;
            if (input.UnitPrice != 0) product.UnitPrice = input.UnitPrice;
            if (input.SRP != 0) product.SRP = input.SRP;
            if (!string.IsNullOrEmpty(input.Color)) product.Color = input.Color;
            product.StockLevel = input.StockLevel;
            product.Bundled = input.Bundled;
            if (input.CatalogTypeId != 0) product.CatalogTypeId = input.CatalogTypeId;
            if (!string.IsNullOrEmpty(input.CatalogBrand)) product.CatalogBrand = input.CatalogBrand;

            await _repository.UpdateAsync(product, autoSave: true);

            return await MapToGetOutputDtoAsync(product);
            //return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public List<CatalogTypeDto> GetCatalogTypeListAsync()
        {
            return _memoryCache.GetOrCreate(_catalogTypeCacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = DateTime.Now.AddDays(_catalogTypeCacheDays);

                var list = new List<CatalogTypeDto>();

                foreach (var item in Enum.GetValues(typeof(CatalogType)))
                {
                    list.Add(new CatalogTypeDto { Name = item.ToString(), Value = Convert.ToInt16(Enum.Format(typeof(CatalogType), item, "D")) });
                }
                return list;
            });
        }


        public async Task<List<ProductDto>> BatchCreateAsync(List<CreateUpdateProductDto> input)
        {
            var productList = new List<Product>();

            var productGroup = input.GroupBy(t => t.CatalogTypeId).ToDictionary(t => t.Key, t => t.ToList());

            foreach (var item in productGroup)
            {
                //Key=CatalogTypeId
                var rowCount = await _repository.GetCatalogTypeNumAsync(item.Key);

                foreach (var p in item.Value)
                {
                    //ProductID rules
                    var productId = $"{p.CatalogTypeId}-{++rowCount:D5}";

                    productList.Add(new Product(id: GuidGenerator.Create(),
                        p.ClinicId,
                        p.ClinicCode,
                        p.Name,
                        productId, //input.ProductID
                        p.SerialNumber,
                        p.Description,
                        "",
                        p.Specification,
                        p.SupplierName,
                        p.Unit,
                        p.UnitPrice,
                        p.SRP,
                        p.Color,
                        p.StockLevel,
                        p.Bundled,
                        p.CatalogTypeId,
                        p.CatalogBrand));
                }
            }

            await _repository.BatchCreateAsync(productList);

            return ObjectMapper.Map<List<Product>, List<ProductDto>>(productList);
        }



    }
}
