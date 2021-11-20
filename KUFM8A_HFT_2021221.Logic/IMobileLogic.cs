using KUFM8A_HFT_2021221.Models;
using System.Collections.Generic;

namespace KUFM8A_HFT_2021221.Logic
{
    public interface IMobileLogic
    {
        void Create(Mobile mobile);
        void Delete(int id);
        Mobile Read(int id);
        IEnumerable<Mobile> ReadAll();
        void Update(Mobile mobile);
    }
}