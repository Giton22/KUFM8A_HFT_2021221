using KUFM8A_HFT_2021221.Endpoint.Services;
using KUFM8A_HFT_2021221.Logic;
using KUFM8A_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace KUFM8A_HFT_2021221.Endpoint.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CpuController : ControllerBase
    {
        ICpuLogic logic;
        IHubContext<SignalRHub> hub;


        public CpuController(ICpuLogic cpuLogic, IHubContext<SignalRHub> hub)
        {
            logic = cpuLogic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("CpuCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Cpu value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("CpuUpdated", value);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cpuToDelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("CpuDeleted", cpuToDelete);
        }
    }
}