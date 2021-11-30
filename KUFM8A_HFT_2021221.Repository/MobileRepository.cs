using KUFM8A_HFT_2021221.Data;
using KUFM8A_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUFM8A_HFT_2021221.Repository
{
    public class MobileRepository : IMobileRepository
    {
        MobileDbContext db;
        public MobileRepository(MobileDbContext db)
        {
            this.db = db;
        }

        public void Create(Mobile mobile)
        {
            db.Mobiles.Add(mobile);
            db.SaveChanges();
        }

        public Mobile Read(int id)
        {
            return db.Mobiles.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Mobile> ReadAll()
        {
            return db.Mobiles;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Mobile mobile)
        {
            var oldmobile = Read(mobile.Id);
            oldmobile.Model = mobile.Model;
            oldmobile.BrandId = mobile.BrandId;
            oldmobile.Price = mobile.Price;
            db.SaveChanges();
        }
    }
}
