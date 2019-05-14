using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceParlourApp.Models
{
    [Table("AddressMaster")]
    public class AddressMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string CompleteAddress { get; set; }
        [Required]
        [MaxLength(6)]
        [MinLength(6)]
        public Int32 ZipCode { get; set; }
    }
}
