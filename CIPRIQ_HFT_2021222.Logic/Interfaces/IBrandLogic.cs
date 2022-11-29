using CIPRIQ_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPRIQ_HFT_2022231.Logic.Interfaces
{
   public  interface IBrandLogic
    {
        void Create(Brand item);
        void Delete(int id);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand item);
    }
}
