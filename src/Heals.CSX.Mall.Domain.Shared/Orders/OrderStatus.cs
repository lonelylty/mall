using System;
using System.Collections.Generic;
using System.Text;

namespace Heals.CSX.Mall.Orders
{
    public enum OrderStatus : short
    {
        //1) In-cart- clinic add product items to cart, but has not submitted order
        //2) Awaiting Fulfillment — clinic has submitted the order
        //3) Awaiting Shipment — order has been packaged and is awaiting to deliver to the clinic
        //4) Partially Shipped — only some items in the order have been shipped
        //5) Completed — order has been delivered to the clinic, and receipt is confirmed
        //6) Clinic Cancelled — clinic cancelled the order
        //7) Supplier Cancelled - supplier cancelled an order due to a stock inconsistency or other reasons
        InCart = 1,
        AwaitingFulfillment,
        AwaitingShipment,
        PartiallyShipped,
        Completed,
        ClinicCancelled,
        SupplierCancelled,
    }


    public enum OrderCatalog
    {
        ALL = 0,

        Pending = 1,    //In_Cart

        Processing = 2, //Awaiting Fulfillment
                        //Awaiting Shipment
                        //Partially Shipped

        Completed = 5,  //Completed

        Cancelled = 6  //Clinic Cancelled
                       //Supplier Cancelled
    }
}
