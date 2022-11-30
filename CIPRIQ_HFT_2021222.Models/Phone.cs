using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CIPRIQ_HFT_2022231.Models
{
    public class Phone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        public string name { get; set; }

        public string PriceCategory { get; set; }
        public int Price { get; set; }

        public int Storage { get; set; }

        public int RAM { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Brand brand { get; set; }

        [ForeignKey(nameof(brand))]
        public int BrandID { get; set; }

        public override string ToString()
        {
            return $"ID:{ID} Name:{name} Price Category:{PriceCategory} Price:{Price} Storage:{Storage} RAM:{RAM}";
        }
    }
}
