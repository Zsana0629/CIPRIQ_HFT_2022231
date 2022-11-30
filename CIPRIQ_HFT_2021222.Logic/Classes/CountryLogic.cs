using CIPRIQ_HFT_2022231.Logic.Interfaces;
using CIPRIQ_HFT_2022231.Models;
using CIPRIQ_HFT_2022231.Repository;
using System.Linq;

namespace CIPRIQ_HFT_2022231.Logic.Classes
{
   public class CountryLogic : ICountryLogic
    {
        IRepository<Country> repo;

        public CountryLogic(IRepository<Country> repo)
        {
            this.repo = repo;
        }

        public void Create(Country item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Country Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Country> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Country item)
        {
            this.repo.Update(item);
        }
        public Country PhoneFinder (string input)
        {
            var Country = from C in repo.ReadAll()
                          from B in C.Brands
                          from P in B.Phones
                          where P.name == input
                          select C;
            return Country.First();
        }
    }
}

