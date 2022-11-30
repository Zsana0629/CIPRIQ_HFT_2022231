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
   public  class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        public string name { get; set; }
        

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Brand> Brands { get; set; }


        public Country()
        {
            Brands = new List<Brand>();
        }

        public override string ToString()
        {
            return $"ID:{ID} Name:{name}";
        }
    }
}
