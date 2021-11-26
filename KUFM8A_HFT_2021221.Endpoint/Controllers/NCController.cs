using KUFM8A_HFT_2021221.Logic;
using KUFM8A_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace KUFM8A_HFT_2021221.Endpoint.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class NcController : ControllerBase
    {
        IMobileLogic logic;

        public NcController(IMobileLogic mobileLogic)
        {
            logic = mobileLogic;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> MobileCountbyBrand()
        {
            return logic.MobileCountbyBrand();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, List<string>>> MobilesByBrand()
        {
            return logic.MobilesByBrand();
        }
    }
}