using KUFM8A_HFT_2021221.Models;
using KUFM8A_HFT_2021221.Repository;
using System;
using System.Linq;
using System.Collections.Generic;

namespace KUFM8A_HFT_2021221.Logic
{
    public class MobileLogic : IMobileLogic
    {
        IMobileRepository mobileRepository;
        public MobileLogic(IMobileRepository mobileRepository)
        {
            this.mobileRepository = mobileRepository;
        }

        public void Create(Mobile mobile)
        {
            if (mobile.Model.Length<3)
            {
                throw new Exception("Name must be over 3 ");
            }
            else
            {
                mobileRepository.Create(mobile);
            }
   
        }

        public Mobile Read(int id)
        {
            return mobileRepository.Read(id);
        }

        public IEnumerable<Mobile> ReadAll()
        {
            return mobileRepository.ReadAll();
        }

        public void Delete(int id)
        {
            mobileRepository.Delete(id);
        }

        public void Update(Mobile mobile)
        {
            mobileRepository.Update(mobile);

        }
        public IEnumerable<KeyValuePair<string, int>> MobileCountbyBrand()
        {
            return from x in mobileRepository.ReadAll()
                   group x by x.Brand.Name into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());

        }
        public IEnumerable<KeyValuePair<string,List<string>>> MobilesByBrand()
        {
            return from x in mobileRepository.ReadAll()
                   group x by x.Brand.Name into g
                   select new KeyValuePair<string, List<string>>
                   (g.Key, g.Select(x => x.Model).ToList());

        }
    }
}
