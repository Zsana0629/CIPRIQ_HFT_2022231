using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPRIQ_HFT_2022231.Models
{
    public class CountryStat
    {
        public string name { get; set; }
        public int PhoneNumber { get; set; }
        public int MostExpensive { get; set; }
        public override string ToString()
        {
            return $"Name:{name} Number of Phones:{PhoneNumber} Most expensive phone price:{MostExpensive}";
        }
    }
}
