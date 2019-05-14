using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceParlourApp.Models
{
    [Table("PriceMaster")]
    public class PriceMaster
    {
        [Key]
        public int PriceId { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Currency { get; set; }
    }
}
