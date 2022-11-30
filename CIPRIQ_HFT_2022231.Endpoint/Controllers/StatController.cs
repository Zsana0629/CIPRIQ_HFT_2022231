using CIPRIQ_HFT_2022231.Logic.Interfaces;
using CIPRIQ_HFT_2022231.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIPRIQ_HFT_2022231.Endpoint.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ICountryLogic countryLogic;
        public StatController(ICountryLogic countryLogic)
        {
            this.countryLogic = countryLogic;
        }

        [HttpGet]
        public Country PhoneFinder([FromQuery] string input)
        {
            return countryLogic.PhoneFinder(input);
        }

        [HttpGet]
        public IQueryable<CountryStat> CountryPhoneStats() { return countryLogic.CountryPhoneStats(); }

        [HttpGet]
        public IQueryable CountriesPhoneRam([FromQuery] int ram) { return countryLogic.CountriesPhoneRam(ram); }

        [HttpGet]
        public double CountryPhonesAvgStorage([FromQuery] string name) { return countryLogic.CountryPhonesAvgStorage(name); }

        [HttpGet]
        public IQueryable<Phone> PhonesInCountry([FromQuery] string input) { return countryLogic.PhonesInCountry(input); }

    }
}

