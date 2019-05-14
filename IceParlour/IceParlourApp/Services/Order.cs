using IceParlourApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceParlourApp.Services
{
    public class Order : IOrder
    {
        readonly BillingContext billingContext;

        public Order(BillingContext context)
        {
            billingContext = context;
        }

        public string CreateOrder(OrderViewModel model)
        {
            try
            {
                var address = new AddressMaster();
                address.CompleteAddress = model.Address;
                address.ZipCode = model.ZipCode;
                var order = new OrderMaster();
                order.AddressId = address.AddressId;
                order.Address = address;
                order.CreatedOn = DateTime.UtcNow;
                order.CustomerName = model.CustomerName;
                order.IsPaid = true;
                order.OrderNumber = 0;
                order.PaymentType = model.PaymentType;
                order.Quantity = model.Quantity;
                order.Remarks = model.Remarks;
                order.TotalAmount = model.TotalAmount;
                order.NumberOfScoop = model.Quantity;
                var orderList = new List<OrderDetail>();
                if (model.IceCreamId != 0)
                {
                    var orderDetails = new OrderDetail();
                    orderDetails.OrderNumber = order.OrderNumber;
                    orderDetails.IceCreamId = model.IceCreamId;
                    orderList.Add(orderDetails);
                }
                if (model.ToppingsId != 0)
                {
                    var orderDetails = new OrderDetail();
                    orderDetails.OrderNumber = order.OrderNumber;
                    orderDetails.IceCreamId = model.ToppingsId;
                    orderList.Add(orderDetails);
                }
                order.OrderDetail = orderList;
                billingContext.Order.Add(order);
                billingContext.SaveChangesAsync();

                return "Order Placed Successfully";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
