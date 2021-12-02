using ConsoleTools;
using KUFM8A_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace KUFM8A_HFT_2021221.Client
{
    class Program
    {
        static RestService rest = new RestService("http://localhost:23793");
        static void Main(string[] args)

        {
            var nc = new ConsoleMenu(args, 1)
                .Add("Mobile Count by Brand", () => MobileCountbyBrand())
                .Add("Region Brand Count", () => RegionBrandCount())
                .Add("Average Price By Brands", () => AveragePriceByBrands())
                .Add("Average Price By Region", () => AveragePriceByRegion())
                .Add("CPU Count By Mobile", () => CPUCountByMobile())
                .Add("Exit", ConsoleMenu.Close).Configure(config =>
                {
                    config.SelectedItemBackgroundColor = ConsoleColor.Blue;
                    config.Selector = "[KEKW]";
                    config.EnableFilter = false;
                    config.ClearConsole = true;
                    config.Title = "Main menu";
                    config.EnableWriteTitle = true;
                    config.EnableBreadcrumb = false;
                    config.WriteItemAction = item => Console.Write("{1}", config.Selector, item.Name);

                });


            var brand = new ConsoleMenu(args, 1)
                .Add("Add new Brand", () => CreateBrand("brand"))
                .Add("Read a Brand", () => ReadABrand("brand"))
                .Add("Read all Brand", () => ReadAllBrands("brand"))
                .Add("Update a Brand", () => UpdateBrand("brand"))
                .Add("Delete a Brand", () => DeleteBrand("brand"))
                .Add("Exit", ConsoleMenu.Close).Configure(config =>
                {
                    config.SelectedItemBackgroundColor = ConsoleColor.Blue;
                    config.Selector = "[KEKW]";
                    config.EnableFilter = false;
                    config.ClearConsole = true;
                    config.Title = "Main menu";
                    config.EnableWriteTitle = true;
                    config.EnableBreadcrumb = false;
                    config.WriteItemAction = item => Console.Write("{1}", config.Selector, item.Name);

                });

            var mobile = new ConsoleMenu(args, 1)
                .Add("Add new Mobile", () => CreateMobile("mobile"))
                .Add("Read a Mobile", () => ReadAMobile("mobile"))
                .Add("Read all Mobiles", () => ReadAllMobiles("mobile"))
                .Add("Update a Mobile", () => UpdateMobile("mobile"))
                .Add("Delete a Mobile", () => DeleteMobile("mobile"))
                .Add("Exit", ConsoleMenu.Close).Configure(config =>
                {
                    config.SelectedItemBackgroundColor = ConsoleColor.Blue;
                    config.Selector = "[KEKW]";
                    config.EnableFilter = false;
                    config.ClearConsole = true;
                    config.Title = "Main menu";
                    config.EnableWriteTitle = true;
                    config.EnableBreadcrumb = false;
                    config.WriteItemAction = item => Console.Write("{1}", config.Selector, item.Name);

                });


            var Cpu = new ConsoleMenu(args, 1)
                .Add("Add new Cpu", () => CreatCpu("cpu"))
                .Add("Read a Cpu", () => ReadACpu("cpu"))
                .Add("Read all Cpu", () => ReadAllCpus("cpu"))
                .Add("Update a Cpu", () => UpdateCpu("cpu"))
                .Add("Delete a Cpu", () => DeleteCpu("cpu"))
                .Add("Exit", ConsoleMenu.Close).Configure(config =>
                {
                    config.SelectedItemBackgroundColor = ConsoleColor.Blue;
                    config.Selector = "[KEKW]";
                    config.EnableFilter = false;
                    config.ClearConsole = true;
                    config.Title = "Main menu";
                    config.EnableWriteTitle = true;
                    config.EnableBreadcrumb = false;
                    config.WriteItemAction = item => Console.Write("{1}", config.Selector, item.Name);

                });


            var mainmenu = new ConsoleMenu(args, 0)
                           .Add("Brand Menu", brand.Show)
                           .Add("Mobile Menu", mobile.Show)
                           .Add("Cpu Menu", Cpu.Show)
                           .Add("Noncrud Menu", nc.Show)
                           .Add("Exit", () => Environment.Exit(0))
          .Configure(config =>
          {
              config.SelectedItemBackgroundColor = ConsoleColor.Blue;
              config.Selector = "[KEKW]";
              config.EnableFilter = false;
              config.ClearConsole = true;
              config.Title = "Main menu";
              config.EnableWriteTitle = true;
              config.EnableBreadcrumb = false;
              config.WriteItemAction = item => Console.Write("{1}", config.Selector, item.Name);

          });

            mainmenu.Show();
        }
        static void CreateBrand(string endpoint)
        {
            Console.WriteLine("Brand Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Region:");
            string region = Console.ReadLine();
            var brand = new Brand() { Name = name, Region = region };
            rest.Post(brand, endpoint);
        }
        static void ReadABrand(string endpoint)
        {
            Console.WriteLine("Brand Id:");
            int id = int.Parse(Console.ReadLine());
            var brand = rest.Get<Brand>(id, endpoint);
            Console.WriteLine(brand.ToString());
            Console.ReadLine();
        }
        static void ReadAllBrands(string endpoint)
        {
            var list = rest.Get<Brand>(endpoint);
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString() + "\n");
            }
            Console.ReadLine();
        }
        static void UpdateBrand(string endpoint)
        {

            Console.WriteLine("Brand Id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Brand name:");
            string name = Console.ReadLine();
            Console.WriteLine("Region:");
            string region = Console.ReadLine();
            var brand = new Brand() { Id = id, Name = name, Region = region };
            rest.Put<Brand>(brand, endpoint);
            Console.WriteLine($"Brand with id:{id} succesfully updated!");
            Console.ReadLine();

        }
        static void DeleteBrand(string endpoint)
        {
            Console.WriteLine("Brand Id:");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, endpoint);
            Console.WriteLine($"Brand with id:{id} succesfully deleted!");
            Console.ReadLine();
        }

        static void CreateMobile(string endpoint)
        {
            var list = rest.Get<Brand>("brand");
            Console.WriteLine("Mobile Model:");
            string model = Console.ReadLine();
            Console.WriteLine("BrandId:");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Id} - {item.Name}");
            }
            int brandId = int.Parse(Console.ReadLine());
            Console.WriteLine("Price:");
            int price = int.Parse(Console.ReadLine());
            var brand = new Mobile() { Model = model, BrandId = brandId, Price = price };
            rest.Post(brand, endpoint);
        }
        static void ReadAMobile(string endpoint)
        {
            Console.WriteLine("Mobile Id:");
            int id = int.Parse(Console.ReadLine());
            var mobile = rest.Get<Mobile>(id, endpoint);
            Console.WriteLine(mobile.ToString());
            Console.ReadLine();
        }
        static void ReadAllMobiles(string endpoint)
        {
            var list = rest.Get<Mobile>(endpoint);
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString() + "\n");
            }
            Console.ReadLine();

        }
        static void UpdateMobile(string endpoint)
        {
            var list = rest.Get<Brand>("brand");
            Console.WriteLine("Mobile Id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Model:");
            string model = Console.ReadLine();
            Console.WriteLine("Price:");
            int price = int.Parse(Console.ReadLine());
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Id} - {item.Name}");
            }
            Console.WriteLine("Brand id:");
            int brandId = int.Parse(Console.ReadLine());
            var mobile = new Mobile() { Id = id, Model = model, Price = price, BrandId = brandId };
            rest.Put<Mobile>(mobile, endpoint);
            Console.WriteLine($"Mobile with id:{id} succesfully updated!");
            Console.ReadLine();
        }
        static void DeleteMobile(string endpoint)
        {

            Console.WriteLine("Mobile Id:");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, endpoint);
            Console.WriteLine($"Mobile with id:{id} succesfully deleted!");
            Console.ReadLine();
        }

        static void CreatCpu(string endpoint)
        {
            var list = rest.Get<Mobile>("mobile");
            Console.WriteLine("Cpu Name:");
            string cpuname = Console.ReadLine();
            Console.WriteLine("MobileId:");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Id} - {item.Model}");
            }
            Console.WriteLine("MobileId:");
            int mobileId = int.Parse(Console.ReadLine());
            var cpu = new Cpu() { CPUName = cpuname, MobileId = mobileId };
            rest.Post(cpu, endpoint);
        }
        static void ReadACpu(string endpoint)
        {
            Console.WriteLine("Cpu Id:");
            int id = int.Parse(Console.ReadLine());
            var cpu = rest.Get<Cpu>(id, endpoint);
            Console.WriteLine(cpu.ToString());
            Console.ReadLine();
        }
        static void ReadAllCpus(string endpoint)
        {
            var list = rest.Get<Cpu>(endpoint);
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString() + "\n");
            }
            Console.ReadLine();

        }
        static void UpdateCpu(string endpoint)
        {
            var list = rest.Get<Mobile>("mobile");
            Console.WriteLine("Cpu Id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Cpu Name:");
            string name = Console.ReadLine();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Id} - {item.Model}");
            }
            Console.WriteLine("Mobile:");
            int mobileId = int.Parse(Console.ReadLine());
            var cpu = new Cpu() { Id = id, CPUName = name, MobileId = mobileId };
            rest.Put<Cpu>(cpu, endpoint);
            Console.WriteLine($"Cpu with id:{id} succesfully updated!");
            Console.ReadLine();
        }
        static void DeleteCpu(string endpoint)
        {
            Console.WriteLine("Cpu Id:");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, endpoint);
            Console.WriteLine($"Cpu with id:{id} succesfully deleted!");
            Console.ReadLine();

        }
        static void MobileCountbyBrand()
        {
            Console.WriteLine("MobileCountbyBrand");
            var list = rest.Get<KeyValuePair<string, int>>("nc/MobileCountbyBrand");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key}-{item.Value}");

            }
            Console.ReadLine();
        }
        static void RegionBrandCount()
        {
            Console.WriteLine("MobileCountbyBrand");
            var list = rest.Get<KeyValuePair<string, int>>("nc/RegionBrandCount");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key}-{item.Value}");

            }
            Console.ReadLine();
        }
        static void AveragePriceByBrands()
        {
            Console.WriteLine("MobileCountbyBrand");
            var list = rest.Get<KeyValuePair<string, double>>("nc/AveragePriceByBrands");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key}-{item.Value}");

            }
            Console.ReadLine();
        }
        static void AveragePriceByRegion()
        {
            Console.WriteLine("MobileCountbyBrand");
            var list = rest.Get<KeyValuePair<string, double>>("nc/AveragePriceByRegion");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key}-{item.Value}");

            }
            Console.ReadLine();
        }
        static void CPUCountByMobile()
        {
            Console.WriteLine("MobileCountbyBrand");
            var list = rest.Get<KeyValuePair<string, int>>("nc/CPUCountByMobile");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key}-{item.Value}");

            }
            Console.ReadLine();
        }
    }
}