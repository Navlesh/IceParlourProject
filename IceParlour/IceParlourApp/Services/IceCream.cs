using IceParlourApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IceParlourApp.Services
{
    public class IceCream : IIceCream
    {
        readonly BillingContext billingContext;

        public IceCream(BillingContext context)
        {
            billingContext = context;
        }

        public double GetPrice(int iceCreamId)
        {
            var price = billingContext.IceCreamMaster.Where(ice => ice.IceCreamId == iceCreamId)
                .Join(billingContext.PriceMaster,
                    p => p.PriceId,
                    ice => ice.PriceId,
                    (ice, p) => new { p.Price }).Select(p=>p.Price).FirstOrDefault();
            return price; //Convert.ToDouble(price.);
        }

        public List<SelectListItem> ListIceCreamTypes()
        {            
            var items = billingContext.IceCreamMaster.Where(ice => ice.IsToppings == false)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.IceCreamId.ToString(),
                            Text = n.Name
                        }).ToList();
            items.Insert(0, new SelectListItem { Text = "Select an Item", Value = "0" });
            return items;
        }

        public List<SelectListItem> ListToppings()
        {
            var items = billingContext.IceCreamMaster.Where(ice => ice.IsToppings == true)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.IceCreamId.ToString(),
                            Text = n.Name
                        }).ToList();
            items.Insert(0, new SelectListItem { Text = "Select an Item", Value = "0" });
            return items;
        }
    }
}
