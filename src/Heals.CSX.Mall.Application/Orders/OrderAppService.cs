using System;
using Heals.CSX.Mall.Permissions;
using Heals.CSX.Mall.Orders.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Emailing;
using Volo.Abp.MailKit;
using Volo.Abp.Emailing.Templates;
using Volo.Abp.TextTemplating;
using Heals.CSX.Mall.Helper;
using Heals.CSX.Mall.Addresses;
using Heals.CSX.Mall.Products.Dtos;
using Microsoft.Extensions.Caching.Memory;
using Volo.Abp.Domain.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Heals.CSX.Mall.Orders
{

    public class OrderAppService : CrudAppService<Order, OrderDto, Guid, PagedAndSortedResultRequestDto, CreateOrderDto, UpdateOrderDto>,
        IOrderAppService
    {
        //protected override string GetPolicyName { get; set; } = MallPermissions.Order.Default;
        //protected override string GetListPolicyName { get; set; } = MallPermissions.Order.Default;
        //protected override string CreatePolicyName { get; set; } = MallPermissions.Order.Create;
        //protected override string UpdatePolicyName { get; set; } = MallPermissions.Order.Update;
        //protected override string DeletePolicyName { get; set; } = MallPermissions.Order.Delete;

        private readonly IOrderRepository _repository;
        private readonly IAddressRepository _addressRepository;

        private readonly IEmailSender _emailSender;

        private readonly ITemplateRenderer _templateRenderer;


        private readonly IMemoryCache _memoryCache;
        private readonly string _orderCatalogCacheKey = "orderCatalogCacheKey";
        private readonly double _orderCatalogCacheDays = 1;

        public OrderAppService(IOrderRepository repository, IAddressRepository addressRepository, IEmailSender emailSender,
            ITemplateRenderer templateRenderer, IMemoryCache cache) : base(repository)
        {
            _repository = repository;
            _addressRepository = addressRepository;
            _emailSender = emailSender;
            _templateRenderer = templateRenderer;
            _memoryCache = cache;
        }

        public async override Task<OrderDto> CreateAsync(CreateOrderDto input)
        {
            //< clinicID >< ddmmyyyy >< increment number >
            //OrderNo rules
            var addDate = DateTime.Now;
            var rowCount = await _repository.GetUserOrderNofDayAsync(input.BuyerId, addDate.ToDateTimeOffset());
            var clinicCode = string.Empty;
            var orderNo = $"{clinicCode}{addDate.ToString(MallConsts.OrderDateFormat)}{++rowCount:D4}";


            var order = new Order(id: GuidGenerator.Create(),
            orderNo,
            input.BuyerId,
            input.ShipToAddressId,
            OrderStatus.AwaitingFulfillment,
            addDate.ToDateTimeOffset(),
            addDate.AddDays(MallConsts.TargetDeliveryDays).ToDateTimeOffset(),
            null,
            ObjectMapper.Map<List<CreateUpdateOrderItemDto>, List<OrderItem>>(input.OrderItems));

            await _repository.InsertAsync(order);

            order.ShipToAddress = await _addressRepository.GetAsync(order.ShipToAddressId);
            await SendEmail(order.ToEmailOrderInfo());

            return ObjectMapper.Map<Order, OrderDto>(order);

        }

        public async override Task<OrderDto> UpdateAsync(Guid id, UpdateOrderDto input)
        {
            var order = await _repository.GetAsync(id);
            if (input.ShipToAddressId != null && order.ShipToAddressId != input.ShipToAddressId) order.ShipToAddressId = (Guid)input.ShipToAddressId;
            if (order.Status != input.Status) order.Status = input.Status;

            await _repository.UpdateAsync(order, autoSave: true);

            return await MapToGetOutputDtoAsync(order);
        }


        public async Task<PagedResultDto<OrderDto>> GetListAsync(OrderListRequestDto input)
        {

            //OrderNo
            //BuyerId
            //Status
            //OrderStartDate
            //OrderEndDate
            var query = _repository.GetDbSet().AsQueryable();

            if (!string.IsNullOrEmpty(input.OrderNo)) query = query.Where(t => t.OrderNo == input.OrderNo);

            if (input.BuyerId != Guid.Empty) query = query.Where(t => t.BuyerId == input.BuyerId);


            //if (input.OrderCatalog== OrderCatalog.ALL) 
            if (input.OrderCatalog == OrderCatalog.Pending)   

                query = query.Where(t => t.Status == OrderStatus.InCart);

            if (input.OrderCatalog == OrderCatalog.Processing)

                query = query.Where(t => t.Status == OrderStatus.AwaitingFulfillment ||
                                         t.Status == OrderStatus.AwaitingShipment ||
                                         t.Status == OrderStatus.PartiallyShipped);

            if (input.OrderCatalog == OrderCatalog.Completed)

                query = query.Where(t => t.Status == OrderStatus.Completed);

            if (input.OrderCatalog == OrderCatalog.Cancelled)

                query = query.Where(t => t.Status == OrderStatus.ClinicCancelled ||
                                         t.Status == OrderStatus.ClinicCancelled);

            query = query.Where(t => t.OrderDate >= input.OrderStartDate.ToDateTimeOffset() && t.OrderDate <= input.OrderEndDate.ToDateTimeOffset());

            var orders = await query.Include(t=>t.OrderItems).ToListAsync();

            var orderDtos = ObjectMapper.Map<List<Order>, List<OrderDto>>(orders);

            return new PagedResultDto<OrderDto>(orders.Count, orderDtos);
        }

        public async Task<List<OrderDto>> GetOrdersAsync(Guid id)
        {
            var orders = await _repository.GetOrderAsync(id);
            return ObjectMapper.Map<List<Order>, List<OrderDto>>(orders);
        }


        public async Task<OrderDto> RepeatOrderAsync(Guid id)
        {
            var order = await _repository.GetAsync(id);

            var addDate = DateTime.Now;
            var rowCount = await _repository.GetUserOrderNofDayAsync(order.BuyerId, addDate.ToDateTimeOffset());
            var clinicCode = string.Empty;
            var orderNo = $"{clinicCode}{addDate.ToString(MallConsts.OrderDateFormat)}{++rowCount:D4}";


            var newOrder = new Order(id: GuidGenerator.Create(),
            orderNo,
            order.BuyerId,
            order.ShipToAddressId,
            OrderStatus.AwaitingFulfillment,
            addDate.ToDateTimeOffset(),
            addDate.AddDays(MallConsts.TargetDeliveryDays).ToDateTimeOffset(),
            null,
            order.OrderItems);

            await _repository.InsertAsync(newOrder);

            newOrder.ShipToAddress = await _addressRepository.GetAsync(newOrder.ShipToAddressId);
            await SendEmail(newOrder.ToEmailOrderInfo());

            return ObjectMapper.Map<Order, OrderDto>(newOrder);

        }


        public async Task SendEmail(MallEmailOrderInfo emailInfo, string to = "lonelylty@gmail.com")
        {
            string productStr = "";

            emailInfo.MallEmailProductInfos.ForEach(t => productStr += $@"
                
                    Product ID:{t.ProductNo}<br/>

                    Product Name:{t.ProductName}<br/>

                    Product Description:{t.ProductDescription}<br/>

                    Product Unit Price:{t.ProductUnitPrice}<br/>

                    Product Qty:{t.ProductQty}<br/>
            ");

            var body = await _templateRenderer.RenderAsync(
               StandardEmailTemplates.Message,
               new
               {
                   message = $@"1. Clinic Info<br/>

                    Clinic ID: {emailInfo.ClinicID}<br/>

                    Clinic Name:{emailInfo.ClinicName}<br/>

                    Customer Name:{emailInfo.CustomerName}<br/>

                    Clinic Phone:{emailInfo.ClinicPhone}<br/>

                    Clinic Shipping Address:{emailInfo.ClinicShippingAddress}<br/>

                    <br/>

                    2.Order Details<br/>

                    Order ID:{emailInfo.OrderNo}<br/>"

                    + productStr + 

                    $@"Order Qty:{emailInfo.OrderQty}<br/>

                    Order Total Amount:{emailInfo.OrderTotalAmount}<br/>

                    Order Remark: {emailInfo.OrderRemark}"
               }
            );

            string subject = $"{emailInfo.ClinicID} {emailInfo.OrderNo}";
            await _emailSender.SendAsync(to, subject, body);
        }


        public List<CatalogTypeDto> GetOrderCatalogListAsync()
        {
            return _memoryCache.GetOrCreate(_orderCatalogCacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = DateTime.Now.AddDays(_orderCatalogCacheDays);

                var list = new List<CatalogTypeDto>();

                foreach (var item in Enum.GetValues(typeof(OrderCatalog)))
                {
                    list.Add(new CatalogTypeDto { Name = item.ToString(), Value = Convert.ToInt16(Enum.Format(typeof(OrderCatalog), item, "D")) });
                }
                return list;
            });
        }
    }
}
