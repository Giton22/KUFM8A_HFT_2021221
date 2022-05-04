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
    public class MobileController : ControllerBase
    {
        IMobileLogic logic;
        IHubContext<SignalRHub> hub;

        public MobileController(IMobileLogic mobileLogic, IHubContext<SignalRHub> hub)
        {
            logic = mobileLogic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("MobileCreated", value);

        }

        [HttpPut]
        public void Put([FromBody] Mobile value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("MobileUpdated", value);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var mobileToDelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("MobileDeleted", mobileToDelete);
        }
    }
}