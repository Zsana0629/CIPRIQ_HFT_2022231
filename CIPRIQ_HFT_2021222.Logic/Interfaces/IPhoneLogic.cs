using CIPRIQ_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPRIQ_HFT_2022231.Logic.Interfaces
{
   public interface IPhoneLogic
    {
        void Create(Phone item);
        void Delete(int id);
        Phone Read(int id);
        IQueryable<Phone> ReadAll();
        void Update(Phone item);
        //double AVGPrice();
        //IQueryable<BrandStatistic> ReadBrandStats();
        //IQueryable<Phone> GetCarsByPriceRange(int min, int max);
    }
}
