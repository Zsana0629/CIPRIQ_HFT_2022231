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
    class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        public string name { get; set; }

        [NotMapped]
        public virtual ICollection<Brand> Brands { get; set; }

        public Country()
        {
            Brands = new HashSet<Brand>();
        }

        public override string ToString()
        {
            //return base.ToString();
            throw new NotImplementedException();
        }
    }
}
