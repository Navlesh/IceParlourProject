using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceParlourApp.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }

        [ForeignKey("OrderNumber")]
        public int OrderNumber { get; set; }        

        [ForeignKey("IceCreamId")]
        public int IceCreamId { get; set; }
        public IceCreamMaster IceCreamMaster { get; set; }

        public OrderMaster Order { get; set; }
    }
}
