using KUFM8A_HFT_2021221.Models;
using System.Collections.Generic;

namespace KUFM8A_HFT_2021221.Logic
{
    public interface ICpuLogic
    {
        void Create(Cpu cpu);
        void Delete(int id);
        Cpu Read(int id);
        IEnumerable<Cpu> ReadAll();
        void Update(Cpu cpu);
    }
}