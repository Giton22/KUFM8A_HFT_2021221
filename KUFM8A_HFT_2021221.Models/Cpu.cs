using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KUFM8A_HFT_2021221.Models
{
    [Table("cpus")]

    public class Cpu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cpu_id", TypeName = "int")]

        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string CPUName { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Mobile? Mobile { get; set; }

        [ForeignKey(nameof(Mobile))]
        public int? MobileId { get; set; }
        public Cpu()
        {

        }
        public override string ToString()
        {
            return $"Id:{Id} CPUName: {CPUName}";
        }
    }
}
