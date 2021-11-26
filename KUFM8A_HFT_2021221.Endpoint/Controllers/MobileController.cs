using KUFM8A_HFT_2021221.Logic;
using KUFM8A_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace KUFM8A_HFT_2021221.Endpoint.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        IMobileLogic logic;

        public MobileController(MobileLogic mobileLogic)
        {
            logic = mobileLogic;
        }

        [HttpGet]
        public IEnumerable<Mobile> Get()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Mobile Get(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Mobile value)
        {
            logic.Create(value);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] Mobile value)
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