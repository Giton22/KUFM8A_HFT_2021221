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

        [SetUp]
        public void Setup()
        {
            Mock<IMobileRepository> mockedMobileRepo = new Mock<IMobileRepository>();
            Mock<ICpuRepository> mockedCpuRepo = new Mock<ICpuRepository>();
            Brand fakeBrand = new Brand() { Name = "Oppo" };
            mockedMobileRepo.Setup(t => t.Create(It.IsAny<Mobile>()));
            mockedMobileRepo.Setup(t => t.ReadAll()).Returns(
             new List<Mobile>() {
              new Mobile() {
              Model = "306",
              Brand=fakeBrand

            },
            new Mobile() {
                Model = "406",
                Brand = fakeBrand
            },
             }.AsQueryable());

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
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string,List<string>>("Oppo",new List<string>() { "306", "406" })));
        }
        [TestCase("A10",true)]
        [TestCase("Mi9", true)]
        [TestCase("As", false)]
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
    }
}
