using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KUFM8A_HFT_2021221.Models
{
    [Table("brands")]
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Mobile> Mobiles {get; set; }
        public Brand()
        {
            Mobiles = new HashSet<Mobile>();
        }
    }
}
