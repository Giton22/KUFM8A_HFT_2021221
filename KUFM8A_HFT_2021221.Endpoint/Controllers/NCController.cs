using KUFM8A_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KUFM8A_HFT_2021221.Endpoint.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class NcController : ControllerBase
    {
        IMobileLogic mobileLogic;
        ICpuLogic cpuLogic;

        public NcController(IMobileLogic mobileLogic, ICpuLogic cpuLogic)
        {
            this.mobileLogic = mobileLogic;
            this.cpuLogic = cpuLogic;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> MobileCountbyBrand()
        {
            return mobileLogic.MobileCountbyBrand();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AveragePriceByBrands()
        {
            return mobileLogic.AveragePriceByBrands();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AveragePriceByRegion()
        {
            return mobileLogic.AveragePriceByRegion();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> RegionBrandCount()
        {
            return mobileLogic.RegionBrandCount();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> CPUCountByMobile()
        {
            return cpuLogic.CPUCountByMobile();
        }

    }
}