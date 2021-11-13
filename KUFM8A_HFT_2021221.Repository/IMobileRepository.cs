using KUFM8A_HFT_2021221.Models;
using System.Linq;

namespace KUFM8A_HFT_2021221.Repository
{
    public interface IMobileRepository
    {
        void Create(Mobile mobile);
        void Delete(int id);
        Mobile Read(int id);
        IQueryable<Mobile> ReadAll();
        void Update(Mobile mobile);
    }
}