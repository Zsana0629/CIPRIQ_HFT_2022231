using CIPRIQ_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPRIQ_HFT_2022231.Repository
{
    class Brand_Repository : Repository<Brand>
    {
        public Brand_Repository(PhoneDbContext ptx) : base(ptx)
        {
        }
        public override Brand Read(int id)
        {
            return ptx.brands.FirstOrDefault(b => b.CountryID == id);
        }
        public override void Update(Brand item)
        {
            var old = Read(item.CountryID);
            foreach (var prop in item.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ptx.SaveChanges();
        }
    }
}
