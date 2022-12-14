using CIPRIQ_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPRIQ_HFT_2022231.Logic.Interfaces
{
    public interface ICountryLogic
    {
        void Create(Country item);
        void Delete(int id);
        Country Read(int id);
        IQueryable<Country> ReadAll();
        void Update(Country item);

        public Country PhoneFinder(string input);

        public IQueryable<CountryStat> CountryPhoneStats();

        public IQueryable CountriesPhoneRam(int ram);

        public double CountryPhonesAvgStorage(string name);

        public IQueryable<Phone> PhonesInCountry(string input);
    }
}
