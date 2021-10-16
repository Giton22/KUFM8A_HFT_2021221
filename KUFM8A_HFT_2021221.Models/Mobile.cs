﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [NotMapped]
        public virtual Brand Brand { get; set; }
        [NotMapped]
        public virtual ICollection<Cpu> Cpus { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
    }
}
