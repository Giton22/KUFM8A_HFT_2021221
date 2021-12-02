using KUFM8A_HFT_2021221.Models;
using System.Linq;

namespace KUFM8A_HFT_2021221.Repository
{
    public interface ICpuRepository
    {
        void Create(Cpu brand);
        void Delete(int id);
        Cpu Read(int id);
        IQueryable<Cpu> ReadAll();
        void Update(Cpu brand);
    }
}
