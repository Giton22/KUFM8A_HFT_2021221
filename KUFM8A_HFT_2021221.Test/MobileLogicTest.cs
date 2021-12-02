using KUFM8A_HFT_2021221.Logic;
using KUFM8A_HFT_2021221.Models;
using KUFM8A_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace KUFM8A_HFT_2021221.Test
{
    [TestFixture]
    public class MobileLogicTest
    {
        private MobileLogic mobileLogic { get; set; }
        private CpuLogic cpuLogic { get; set; }
        private BrandLogic brandLogic { get; set; }

        [SetUp]
        public void Setup()
        {
            Mock<IMobileRepository> mockedMobileRepo = new Mock<IMobileRepository>();
            Mock<ICpuRepository> mockedCpuRepo = new Mock<ICpuRepository>();
            Mock<IBrandRepository> mockedBrandRepo = new Mock<IBrandRepository>();

            Brand fakeBrand = new Brand() { Name = "Oppo", Region = "China" };
            Mobile fakeMobile = new Mobile() { Model = "A10", Price = 200 };

            mockedMobileRepo.Setup(t => t.Create(It.IsAny<Mobile>()));
            mockedMobileRepo.Setup(t => t.ReadAll()).Returns(
             new List<Mobile>() {
              new Mobile() {
                Id=1,
                Model = "Z6",
                Brand=fakeBrand,
                Price=200

            },
            new Mobile() {
                Id=2,
                Model = "Z7",
                Brand = fakeBrand,
                Price=500
            },
             }.AsQueryable());

            mockedCpuRepo.Setup(t => t.Create(It.IsAny<Cpu>()));
            mockedCpuRepo.Setup(t => t.ReadAll()).Returns(
                new List<Cpu>()
                {
                    new Cpu()
                    {
                        CPUName="Exynos",
                        Mobile=fakeMobile

                    },
                    new Cpu()
                    {
                        CPUName="Snapdragon",
                        Mobile=fakeMobile
                    },

                }.AsQueryable());

            mockedBrandRepo.Setup(t => t.Create(It.IsAny<Brand>()));
            mockedBrandRepo.Setup(t => t.ReadAll()).Returns(
                new List<Brand>()
                {
                    new Brand()
                    {
                        Name="Oppo",
                        Region="China"

                    },
                    new Brand()
                    {
                        Name="Apple",
                        Region="USA"
                    },
                    new Brand()
                    {
                        Name="ZTE",
                        Region="China"
                    },

                }.AsQueryable());
            this.cpuLogic = new CpuLogic(mockedCpuRepo.Object);
            this.mobileLogic = new MobileLogic(mockedMobileRepo.Object);
            this.brandLogic = new BrandLogic(mockedBrandRepo.Object);

        }
        //************************************************************************************************************************************************
        [Test]
        public void TestMobileCountByBrand()
        {
            var result = mobileLogic.MobileCountbyBrand().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("Oppo", 2)));
        }
        //************************************************************************************************************************************************
        [Test]
        public void TestAveragePriceByBrands()
        {
            var result = mobileLogic.AveragePriceByBrands().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, double>("Oppo", 350)));
        }
        //************************************************************************************************************************************************
        [Test]
        public void TesRegionBrandCount()
        {
            var result = mobileLogic.RegionBrandCount().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, double>("China", 2)));
        }
        //************************************************************************************************************************************************
        [Test]
        public void TestMobileReadAll()
        {
            var result = mobileLogic.ReadAll().Count();
            Assert.That(result, Is.EqualTo(2));
        }
        //************************************************************************************************************************************************
        [Test]
        public void TestMobileUpdate()
        {
            var result = brandLogic.ReadAll().Count();
            Assert.That(result, Is.EqualTo(3));
        }
        //************************************************************************************************************************************************
        [Test]
        public void TestAveragePriceByRegion()
        {
            var result = mobileLogic.AveragePriceByRegion().ToArray();

            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, double>("China", 350)));
        }
        //************************************************************************************************************************************************
        [Test]
        public void TestCPUCountByMobile()
        {
            var result = cpuLogic.CPUCountByMobile().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("A10", 2)));
        }
        //************************************************************************************************************************************************
        [TestCase("A10", true)]
        [TestCase("Mi9", true)]
        [TestCase("As", false)]
        [TestCase(null, false)]
        public void TestCreateMobile(string model, bool result)
        {
            var testmobile = new Mobile() { Model = model };
            if (result)
            {

                Assert.That(() => { mobileLogic.Create(testmobile); }, Throws.Nothing);
            }
            else
            {
                Assert.That(() => { mobileLogic.Create(testmobile); }, Throws.Exception);
            }
        }

        //************************************************************************************************************************************************
        [TestCase("Exynos", true)]
        [TestCase("Snapdragon", true)]
        [TestCase("Me", false)]
        [TestCase(null, false)]
        public void TestCreateCpu(string name, bool result)
        {
            var testCpu = new Cpu() { CPUName = name };
            if (result)
            {

                Assert.That(() => { cpuLogic.Create(testCpu); }, Throws.Nothing);
            }
            else
            {
                Assert.That(() => { cpuLogic.Create(testCpu); }, Throws.Exception);
            }
        }
        //************************************************************************************************************************************************
        [TestCase("Oppo", true)]
        [TestCase("ZTE", true)]
        [TestCase("X", false)]
        [TestCase(null, false)]
        public void TestCreateBrand(string name, bool result)
        {
            var testBrand = new Brand() { Name = name };
            if (result)
            {

                Assert.That(() => { brandLogic.Create(testBrand); }, Throws.Nothing);
            }
            else
            {
                Assert.That(() => { brandLogic.Create(testBrand); }, Throws.Exception);
            }
        }
        //************************************************************************************************************************************************
    }
}
