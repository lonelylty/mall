using System;
using Heals.CSX.Mall.Orders.Dtos;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using Heals.CSX.Mall.Controllers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Volo.Abp.Settings;
using Heals.CSX.Mall.Products.Dtos;

namespace Heals.CSX.Mall.Orders
{

    [ApiController]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/mall/order")]
    //[RemoteService(Name = "MallOrder")]
    public class OrderController : MallController
    {
        private readonly IOrderAppService _service;

        private readonly ISettingEncryptionService _settingEncryptionService;
        private readonly ISettingDefinitionManager _settingDefinitionManager;

        public OrderController(IOrderAppService service, ISettingEncryptionService settingEncryptionService, ISettingDefinitionManager settingDefinitionManager)
        {
            _service = service;
            _settingEncryptionService = settingEncryptionService;
            _settingDefinitionManager = settingDefinitionManager;
        }

        [HttpPost]
        public virtual Task<OrderDto> CreateAsync(CreateOrderDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<OrderDto> UpdateAsync(Guid id, UpdateOrderDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpPut]
        [Route("cancel/{id}")]
        public virtual Task CancelAsync(Guid id)
        {
           return _service.UpdateAsync(id, new UpdateOrderDto { Status = OrderStatus.ClinicCancelled });
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<OrderDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        [Route("userOrders/{id}")]
        public virtual Task<List<OrderDto>> GetUserOrdersAsync(Guid id)
        {
            return _service.GetOrdersAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<OrderDto>> GetListAsync([FromQuery] OrderListRequestDto input)
        {
            return _service.GetListAsync(input);
        }


        /// <summary>
        /// Repeat Order
        /// </summary>
        /// <param name="id">Order Guid</param>
        /// <returns></returns>
        [HttpPost]
        [Route("repeat/{id}")]
        public virtual Task<OrderDto> RepeatOrderAsync(Guid id)
        {
            return _service.RepeatOrderAsync(id);
            throw new NotImplementedException();
        }


        [HttpGet]
        [Route("catalogs")]
        public virtual List<CatalogTypeDto> GetCatalogListAsync()
        {
            return _service.GetOrderCatalogListAsync();
        }


        //[HttpGet]
        //[Route("encryptsmtpPwd")]
        //public IActionResult EncryptPwd(string pwd= "King870903")
        //{
        //    var setting = _settingDefinitionManager.Get("Abp.Mailing.Smtp.Password");
        //    var psd= _settingEncryptionService.Encrypt(setting, pwd);
        //    return Success<string>(psd);
        //}

        //[HttpGet]
        //[Route("sendEmail")]
        //public IActionResult SendEmail()
        //{
        //    //_service.SendEmail();
        //    return Success();
        //}
    }
}