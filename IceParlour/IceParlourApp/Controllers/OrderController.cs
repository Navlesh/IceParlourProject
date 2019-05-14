using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IceParlourApp.Models;
using IceParlourApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IceParlourApp.Controllers
{
    public class OrderController : Controller
    {
        readonly IIceCream iceCream;
        readonly IOrder order;

        public OrderController(IIceCream _iceCream, IOrder _order)
        {
            iceCream = _iceCream;
            order = _order;
        }
        // GET: Order
        public ActionResult Index()
        {
            var order = new OrderViewModel();
            order.IceCreamType = iceCream.ListIceCreamTypes();
            order.Toppings = iceCream.ListToppings();
            return View(order);
        }

        public ActionResult GetPrice(int id)
        {
            return Json(iceCream.GetPrice(id));
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(OrderViewModel orderModel)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    var message = order.CreateOrder(orderModel);
                    ViewBag.Message = message;
                }
                orderModel.IceCreamType = iceCream.ListIceCreamTypes();
                orderModel.Toppings = iceCream.ListToppings();
                return View(orderModel);
            }
            catch
            {
                return View();
            }
        }
    }
}