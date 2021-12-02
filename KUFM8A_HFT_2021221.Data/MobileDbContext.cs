using KUFM8A_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;

namespace KUFM8A_HFT_2021221.Data
{
    public partial class MobileDbContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Mobile> Mobiles { get; set; }
        public virtual DbSet<Cpu> CPUs { get; set; }


        public MobileDbContext()
        {
            this.Database.EnsureCreated();
        }
        public MobileDbContext(DbContextOptions<MobileDbContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    //ConnectionString:
                    //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True
                    UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mobile>(entity =>
            {
                entity.HasOne(mobile => mobile.Brand)
                    .WithMany(brand => brand.Mobiles)
                    .HasForeignKey(mobile => mobile.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Cpu>(entity =>
            {
                entity.HasOne(cpu => cpu.Mobile)
                    .WithMany(mobile => mobile.Cpus)
                    .HasForeignKey(Cpu => Cpu.MobileId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            // Part 1
            Brand xiaomi = new Brand() { Id = 1, Name = "Xiaomi", Region = "China" };
            Brand samsung = new Brand() { Id = 2, Name = "Samsung", Region = "South Korean" };
            Brand huawei = new Brand() { Id = 3, Name = "Huawei", Region = "China" };

            Mobile xiaomi1 = new Mobile() { Id = 1, BrandId = xiaomi.Id, Model = "Mi 10", Price = 200 };
            Mobile xiaomi2 = new Mobile() { Id = 2, BrandId = xiaomi.Id, Model = "Mi 11", Price = 400 };
            Mobile samsung1 = new Mobile() { Id = 3, BrandId = samsung.Id, Model = "Galaxy S10", Price = 500 };
            Mobile samsung2 = new Mobile() { Id = 4, BrandId = samsung.Id, Model = "Galaxy S20", Price = 600 };
            Mobile huawei1 = new Mobile() { Id = 5, BrandId = huawei.Id, Model = "P10", Price = 300 };
            Mobile huawei2 = new Mobile() { Id = 6, BrandId = huawei.Id, Model = "Mate 10", Price = 400 };

            Cpu xioamicpu1 = new Cpu() { Id = 1, MobileId = xiaomi1.Id, CPUName = "Snapdragon 865" };
            Cpu xioamicpu2 = new Cpu() { Id = 2, MobileId = xiaomi2.Id, CPUName = "Snapdragon 888" };
            Cpu samsungcpu1 = new Cpu() { Id = 3, MobileId = samsung1.Id, CPUName = "Exynos 9820" };
            Cpu samsungcpu2 = new Cpu() { Id = 4, MobileId = samsung1.Id, CPUName = "Snapdragon 855" };
            Cpu samsungcpu3 = new Cpu() { Id = 5, MobileId = samsung2.Id, CPUName = "Exynos 990" };
            Cpu samsungcpu4 = new Cpu() { Id = 6, MobileId = samsung2.Id, CPUName = "Snapdragon 865" };
            Cpu huaweicpu1 = new Cpu() { Id = 7, MobileId = huawei1.Id, CPUName = "Kirin 960" };
            Cpu huaweicpu2 = new Cpu() { Id = 8, MobileId = huawei2.Id, CPUName = "Kirin 970" };


            modelBuilder.Entity<Brand>().HasData(xiaomi, samsung, huawei);
            modelBuilder.Entity<Mobile>().HasData(xiaomi1, xiaomi2, samsung1, samsung2, huawei1, huawei2);
            modelBuilder.Entity<Cpu>().HasData(xioamicpu1, xioamicpu2, samsungcpu1, samsungcpu2, samsungcpu3, samsungcpu4, huaweicpu1, huaweicpu2);

        }
    }
}
