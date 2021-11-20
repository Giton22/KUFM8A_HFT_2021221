using KUFM8A_HFT_2021221.Models;
using KUFM8A_HFT_2021221.Repository;
using System;
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
            mobileRepository.Create(mobile);
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
    }
}
