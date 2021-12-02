using KUFM8A_HFT_2021221.Models;
using KUFM8A_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KUFM8A_HFT_2021221.Logic
{
    public class CpuLogic : ICpuLogic
    {
        ICpuRepository cpuRepository;
        public CpuLogic(ICpuRepository cpuRepository)
        {
            this.cpuRepository = cpuRepository;
        }

        public void Create(Cpu cpu)
        {
            if (cpu.CPUName.Length < 3)
            {
                throw new Exception("Name must be over 2 ");
            }
            else if (cpu.CPUName == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                cpuRepository.Create(cpu);
            }
        }

        public Cpu Read(int id)
        {
            return cpuRepository.Read(id);
        }

        public IEnumerable<Cpu> ReadAll()
        {
            return cpuRepository.ReadAll();
        }

        public void Delete(int id)
        {
            cpuRepository.Delete(id);
        }

        public void Update(Cpu cpu)
        {
            cpuRepository.Update(cpu);

        }
        public IEnumerable<KeyValuePair<string, int>> CPUCountByMobile()
        {
            return from x in cpuRepository.ReadAll()
                   group x by x.Mobile.Model into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());
        }
    }
}
