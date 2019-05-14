using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IceParlourApp.Models
{
    public class OrderViewModel
    {
        public int OrderNumber { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a Ice Cream")]
        public int IceCreamId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a Toppings")]
        public int ToppingsId { get; set; }

        [Required]
        [Display(Name="Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Number Of Scoop")]
        public int Quantity { get; set; } = 1;
        public string Remarks { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        [Range(1, 999999, ErrorMessage = "Please enter a valid Zip Code of 6 digit")]
        public int ZipCode { get; set; }

        public string Address { get; set; }
        [Display(Name = "Total")]
        public double TotalAmount { get; set; }

        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }
        public bool IsPaid { get; set; } = false;

        public ICollection<OrderDetail> OrderDetail { get; set; }
        [Display(Name = "Ice Cream Type")]
        public List<SelectListItem> IceCreamType { get; set; }
        [Display(Name = "Toppings")]
        public List<SelectListItem> Toppings { get; set; }
    }
}
