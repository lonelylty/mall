using System;
using System.Collections.Generic;
using System.Text;

namespace Heals.CSX.Mall.Orders
{
    public class MallEmailOrderInfo
    {

        public string ClinicID { get; set; }
        public string ClinicName { get; set; }
        public string CustomerName { get; set; }
        public string ClinicPhone { get; set; }
        public string ClinicShippingAddress { get; set; }

        public string OrderNo { get; set; }
        public List<MallEmailProductInfo> MallEmailProductInfos { get; set; }
        public int OrderQty { get; set; }
        public decimal OrderTotalAmount { get; set; }
        public string OrderRemark { get; set; }
    }

    public class MallEmailProductInfo
    {
        public string ProductNo { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public int ProductQty { get; set; }
    }
    
}
