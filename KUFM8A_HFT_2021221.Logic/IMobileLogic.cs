using KUFM8A_HFT_2021221.Models;
using System.Collections.Generic;

namespace KUFM8A_HFT_2021221.Logic
{
    public interface IMobileLogic
    {
        IEnumerable<KeyValuePair<string, double>> AveragePriceByBrands();
        IEnumerable<KeyValuePair<string, double>> AveragePriceByRegion();
        void Create(Mobile mobile);
        void Delete(int id);
        IEnumerable<KeyValuePair<string, int>> MobileCountbyBrand();
        Mobile Read(int id);
        IEnumerable<Mobile> ReadAll();
        IEnumerable<KeyValuePair<string, int>> RegionBrandCount();
        void Update(Mobile mobile);
    }
}