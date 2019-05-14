using IceParlourApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceParlourApp.Services
{
    public interface IOrder
    {
        string CreateOrder(OrderViewModel model);
    }
}
