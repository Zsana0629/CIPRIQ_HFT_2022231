using CIPRIQ_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPRIQ_HFT_2022231.Repository
{
   public class PhoneRepository : Repository<Phone>
    {
        public PhoneRepository(PhoneDbContext ptx) : base(ptx)
        {
        }
        public override Phone Read(int id)
        {
            return ptx.phones.FirstOrDefault(b => b.ID == id);
        }
        public override void Update(Phone item)
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
