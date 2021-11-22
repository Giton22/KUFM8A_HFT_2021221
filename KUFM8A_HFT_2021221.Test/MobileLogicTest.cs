using KUFM8A_HFT_2021221.Logic;
using KUFM8A_HFT_2021221.Models;
using KUFM8A_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace KUFM8A_HFT_2021221.Test
{   [TestFixture]
    public class MobileLogicTest
    {
        private MobileLogic mobileLogic { get; set; }
        private CpuLogic cpuLogic { get; set; }
        [SetUp]
        public void Setup()
        {
            Mock<IMobileRepository> mockedMobileRepo = new Mock<IMobileRepository>();
            Mock<ICpuRepository> mockedCpuRepo = new Mock<ICpuRepository>();
            Brand fakeBrand = new Brand() { Name = "Oppo" };
            Mobile fakeMobile = new Mobile() { Model = "A10" };
            mockedMobileRepo.Setup(t => t.Create(It.IsAny<Mobile>()));
            mockedMobileRepo.Setup(t => t.ReadAll()).Returns(
             new List<Mobile>() {
              new Mobile() {
              Model = "Z6",
              Brand=fakeBrand

            },
            new Mobile() {
                Model = "Z7",
                Brand = fakeBrand
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
            this.cpuLogic = new CpuLogic(mockedCpuRepo.Object);
            this.mobileLogic = new MobileLogic(mockedMobileRepo.Object);

        }
        [Test]
        public void TestMobileCountByBrand()
        {
            var result = mobileLogic.MobileCountbyBrand().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("Oppo", 2)));
        }
        [Test]
        public void TestMobileByBrand()
        {
            var result = mobileLogic.MobilesByBrand().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, List<string>>("Oppo", new List<string>() { "Z6", "Z7" })));
        }
        [Test]
        public void TestCPUCountByMobile()
        {
            var result = cpuLogic.CPUCountByMobile().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("A10", 2)));
        }

        [TestCase("A10", true)]
        [TestCase("Mi9", true)]
        [TestCase("As", false)]
        [TestCase(null,false)]
        public void TestCreateMobile(string model,bool result)
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
    }
}
