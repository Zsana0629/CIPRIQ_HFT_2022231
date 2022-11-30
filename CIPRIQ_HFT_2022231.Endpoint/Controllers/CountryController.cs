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
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        ICountryLogic logic;

        public CountryController(ICountryLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Country> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Country Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Country value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Country value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}

