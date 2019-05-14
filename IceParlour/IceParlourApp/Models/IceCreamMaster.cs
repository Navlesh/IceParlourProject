using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceParlourApp.Models
{
    [Table("IceCreamMaster")]
    public class IceCreamMaster
    {
        [Key]        
        public int IceCreamId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public bool IsToppings { get; set; }

        public int PriceId { get; set; }
        [ForeignKey("PriceId")]
        public PriceMaster PriceMaster { get; set; }

    }
}
