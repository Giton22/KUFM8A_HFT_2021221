using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KUFM8A_HFT_2021221.Models
{
    [Table("mobiles")]
    public class Mobile
    {

        public Mobile(string name, int id)
        {
            Model = name;
            BrandId = id;
        }
        public Mobile()
        {
            Cpus = new HashSet<Cpu>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("mobile_id", TypeName = "int")]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Model { get; set; }
        public int Price { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Brand? Brand { get; set; }
        [NotMapped]
        public virtual ICollection<Cpu> Cpus { get; set; }

        [ForeignKey(nameof(Brand))]
        public int? BrandId { get; set; }
        public override string ToString()
        {
            return $"Id:{Id} Model: {Model} Price: {Price}";
        }
    }
}
