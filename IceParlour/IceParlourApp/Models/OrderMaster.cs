using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceParlourApp.Models
{
    [Table("OrderMaster")]
    public class OrderMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }

        public int Quantity { get; set; }
        public string Remarks { get; set; }

        [ForeignKey("AddressId")]
        public int AddressId { get; set; }
        public AddressMaster Address { get; set; }

        [Required]
        public int NumberOfScoop { get; set; }

        public double TotalAmount { get; set; }
        public string PaymentType { get; set; }
        public bool IsPaid { get; set; }
        public DateTime CreatedOn { get; set; }

        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
