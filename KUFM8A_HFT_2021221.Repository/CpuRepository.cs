using KUFM8A_HFT_2021221.Data;
using KUFM8A_HFT_2021221.Models;
using System.Linq;

namespace KUFM8A_HFT_2021221.Repository
{
    public class CpuRepository : ICpuRepository
    {
        MobileDbContext db;
        public CpuRepository(MobileDbContext db)
        {
            this.db = db;
        }

        public void Create(Cpu cpu)
        {
            db.CPUs.Add(cpu);
            db.SaveChanges();
        }

        public Cpu Read(int id)
        {
            return db.CPUs.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Cpu> ReadAll()
        {
            return db.CPUs;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Cpu cpu)
        {
            var oldcar = Read(cpu.Id);
            oldcar.CPUName = cpu.CPUName;
            oldcar.MobileId = cpu.MobileId;
            db.SaveChanges();
        }


    }
}
