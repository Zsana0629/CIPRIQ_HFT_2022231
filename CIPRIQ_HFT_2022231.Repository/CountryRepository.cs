using CIPRIQ_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPRIQ_HFT_2022231.Repository
{
  public  class CountryRepository : Repository<Country>
    {
        public CountryRepository(PhoneDbContext ptx) : base(ptx)
        {
        }
        public override Country Read(int id)
        {
            return ptx.countries.FirstOrDefault(b => b.ID == id);
        }
        public override void Update(Country item)
        {
            var old = Read(item.ID);
            foreach (var prop in item.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ptx.SaveChanges();
        }
    }
}
