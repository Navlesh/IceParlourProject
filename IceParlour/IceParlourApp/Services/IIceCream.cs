using IceParlourApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceParlourApp.Services
{
    public interface IIceCream
    {
        List<SelectListItem> ListIceCreamTypes();

        List<SelectListItem> ListToppings();

        double GetPrice(int iceCreamId);
    }
}
