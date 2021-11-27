using KUFM8A_HFT_2021221.Logic;
using KUFM8A_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace KUFM8A_HFT_2021221.Endpoint.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CpuController : ControllerBase
    {
        ICpuLogic logic;

        public CpuController(ICpuLogic cpuLogic)
        {
            logic = cpuLogic;
        }

        [HttpGet]
        public IEnumerable<Cpu> Get()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Cpu Get(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Cpu value)
        {
            logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Cpu value)
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