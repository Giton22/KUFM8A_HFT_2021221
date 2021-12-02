using KUFM8A_HFT_2021221.Logic;
using KUFM8A_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KUFM8A_HFT_2021221.Endpoint.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic logic;

        public BrandController(IBrandLogic brandLogic)
        {
            logic = brandLogic;
        }

        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}