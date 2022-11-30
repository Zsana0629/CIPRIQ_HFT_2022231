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
    public class PhoneController : ControllerBase
    {
        IPhoneLogic logic;

        public PhoneController(IPhoneLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Phone> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Phone Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Phone value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Phone value)
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

