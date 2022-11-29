using CIPRIQ_HFT_2022231.Logic.Interfaces;
using CIPRIQ_HFT_2022231.Models;
using CIPRIQ_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPRIQ_HFT_2022231.Logic.Classes
{
   public class PhoneLogic : IPhoneLogic
    {
       
            IRepository<Phone> repo;

            public PhoneLogic(IRepository<Phone> repo)
            {
                this.repo = repo;
            }

            public double AVGPrice()
            {
                return this.repo.ReadAll().Average(c => c.BrandID);
            }

            public void Create(Phone item)
            {
                this.repo.Create(item);
            }

            public void Delete(int id)
            {
                this.repo.Delete(id);
            }

            public Phone Read(int id)
            {
                return this.repo.Read(id);
            }

            public IQueryable<Phone> ReadAll()
            {
                return this.repo.ReadAll();
            }

            public void Update(Phone item)
            {
                this.repo.Update(item);
            }
        
    }
}
