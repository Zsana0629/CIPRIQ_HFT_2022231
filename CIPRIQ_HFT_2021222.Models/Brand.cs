using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPRIQ_HFT_2022231.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id {get; set;}
        public string name { get; set; }
        [NotMapped]
        public virtual ICollection<Phone> Phones { get; set; }
        [NotMapped]
        public virtual Country country { get; set; }

        public int CountryID { get; set; }

        public Brand()
        {
            Phones = new List<Phone>();
        }

        public override string ToString()
        {
            //return base.ToString();
            throw new NotImplementedException();
        }
    }
}
