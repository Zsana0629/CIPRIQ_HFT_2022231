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



            public void Create(Phone item)
            {
            if (item.name.Length <= 0 || item.name is null || item.name.Length > 1000) throw new FormatException();
            if (item.RAM<= 0 || item.RAM is 0 || item.RAM > 100) throw new FormatException();
            if (item.Storage <= 0 || item.Storage is 0 || item.Storage > 1000) throw new FormatException();
            if (item.Price <= 0 || item.Price is 0 || item.Price > 0) throw new FormatException();
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
            if (item.name.Length <= 0 || item.name is null || item.name.Length > 0) throw new FormatException();
            if (item.RAM <= 0 || item.RAM is 0 || item.RAM > 100) throw new FormatException();
            if (item.Storage <= 0 || item.Storage is 0 || item.Storage > 1000) throw new FormatException();
            if (item.Price <= 0 || item.Price is 0 || item.Price > 0) throw new FormatException();
            this.repo.Update(item);
            }
        
    }
}
