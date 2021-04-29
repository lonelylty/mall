using Heals.CSX.Mall.Orders;
using Heals.CSX.Mall.Orders.Dtos;
using Heals.CSX.Mall.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Volo.Abp.Specifications;

namespace Heals.CSX.Mall.Helper
{
    public static class DtoExtensions
    {
        public static MallEmailOrderInfo ToEmailOrderInfo(this Order order)
        {

            var emailProductInfos = new List<MallEmailProductInfo>();

            order.OrderItems.ForEach(t => emailProductInfos.Add(new MallEmailProductInfo
            {
                ProductNo = t.ItemOrdered.ProductSeqId,
                ProductName = t.ItemOrdered.ProductName,
                ProductDescription = t.ItemOrdered.ProductName,
                ProductUnitPrice = t.UnitPrice,
                ProductQty = t.Units
            }));

            var emailOrderInfo = new MallEmailOrderInfo
            {
                ClinicID = order.ShipToAddress.ClinicCode,
                ClinicName = order.ShipToAddress.ClinicName,
                CustomerName = order.ShipToAddress.Contacts,
                ClinicPhone = order.ShipToAddress.Phone,
                ClinicShippingAddress = order.ShipToAddress.ShippingAddress,
                OrderNo = order.OrderNo,
                MallEmailProductInfos = emailProductInfos,
                OrderQty = order.QtyTotal(),
                OrderTotalAmount = order.Total(),
                OrderRemark = order.ShipToAddress.Remarks
            };

            return emailOrderInfo;
        }

    }
}
