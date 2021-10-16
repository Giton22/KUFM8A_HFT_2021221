﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUFM8A_HFT_2021221.Models
{
    [Table("cpus")]

    class Cpu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cpu_id", TypeName = "int")]

        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string CPUName { get; set; }

        [NotMapped]
        public virtual Mobile Mobile { get; set; }

        [ForeignKey(nameof(Mobile))]
        public int MobileId { get; set; }
        public Cpu()
        {
            
        }
    }
}
