using ABugsDeath.Animals;
using ABugsDeath.Assets;
using ABugsDeath.Interfaces;
using ABugsDeath.Services;
using ABugsDeath.Services.ServiceFactories;
using ABugsDeath.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ABugsDeathTests.ServiceFactoriesTests
{
    [TestClass]
    public class CockroachServiceFactoryTest
    {
        private decimal TestLeaderSalary = 3000;
        private decimal TestWorkerSalary = 1000;
        private IServiceFactory TestService;

        [TestInitialize]
        public void Init()
        {
            var TestMainFactory = new ServiceMainFactory();
            this.TestService = TestMainFactory.GetServiceFactory("CockroachServiceFactory");
        }

        [TestMethod]
        public void TestBuildBasicService()
        {
            #region Service and Worker Team
            var TestTeamLeader = new TeamLeader(TestLeaderSalary);
            var TestWorker1 = new Worker(TestWorkerSalary);
            var TestWorker2 = new Worker(TestWorkerSalary);
            #endregion

            #region 
            ServiceBase TestBasicService = TestService.BuildService("Basic") as ServiceBase;

            TestTeamLeader.AddWorker(TestWorker1);
            TestTeamLeader.AddWorker(TestWorker2);

            TestBasicService.Team = TestTeamLeader;
            #endregion

            #region Asserts: Control vars
            var TestPoison = TestBasicService.Poison;
            var TestAnimal = TestBasicService.Animal;
            var TestProtectionSuites = TestBasicService.Assets.Where(x => x.GetNombreRecurso().Equals("ProtectionSuite"));
            var TestSimpleMasks = TestBasicService.Assets.Where(x => x.GetNombreRecurso().Equals("SimpleMask"));
            var TestFinalPrice = TestTeamLeader.Price + TestPoison.Price + TestProtectionSuites.Sum(x => x.GetPrecioRecurso()) + TestSimpleMasks.Sum(x => x.GetPrecioRecurso());
            #endregion

            #region Asserts
            Assert.AreEqual(typeof(Cockroach), TestAnimal.GetType(), "Different Animal types!");
            Assert.AreEqual(typeof(Strychnine), TestPoison.GetType(), "Different Poison types!");
            Assert.AreEqual(TestPoison, TestBasicService.Assets.Where(x => x.Equals(TestBasicService.Poison)).SingleOrDefault(), "Different Poison instances!");
            Assert.AreEqual(2, TestProtectionSuites.Count(), "Not enough ProtectionSuites found!");
            Assert.AreEqual(2, TestSimpleMasks.Count(), "Not enough SimpleMasks found!");

            Assert.AreEqual(500, TestProtectionSuites[0].Price, "Different ProtectionSuite prices!");
            Assert.AreEqual(500, TestProtectionSuites[1].Price, "Different ProtectionSuite prices!");
            Assert.AreEqual(20, TestSimpleMasks[0].Price, "Different SimpleMask prices!");
            Assert.AreEqual(20, TestSimpleMasks[1].Price, "Different SimpleMask prices!");
            Assert.AreEqual(10, TestPoison.Price, "Different Poison prices!");

            Assert.AreEqual(TestFinalPrice, TestBasicService.Price, "Service price is different!");
            #endregion
        }

        [TestMethod]
        public void TestBuildPremiumService()
        {
            #region Service and Worker Team
            var TestTeamLeader = new TeamLeader(TestLeaderSalary);
            var TestWorker1 = new Worker(TestWorkerSalary);
            var TestWorker2 = new Worker(TestWorkerSalary);
            var TestWorker3 = new Worker(TestWorkerSalary);
            #endregion

            #region 
            ServiceBase TestPremiumService = TestService.BuildService("Premium") as ServiceBase;

            TestTeamLeader.AddWorker(TestWorker1);
            TestTeamLeader.AddWorker(TestWorker2);
            TestTeamLeader.AddWorker(TestWorker3);

            TestPremiumService.Team = TestTeamLeader;
            #endregion

            #region Asserts: Control vars
            var TestPoison = TestPremiumService.Poison;
            var TestAnimal = TestPremiumService.Animal;
            var TestBleach = TestPremiumService.Assets.Where(x => x.GetType() == typeof(Bleach)).Single();
            var TestProtectionSuites = TestPremiumService.Assets.Where(x => x.GetType() == typeof(ProtectionSuite)).ToList();
            var TestSimpleMasks = TestPremiumService.Assets.Where(x => x.GetType() == typeof(SimpleMask)).ToList();
            var TestFinalPrice = TestTeamLeader.Price + TestPoison.Price 
                + TestProtectionSuites.Sum(x => x.Price) + TestSimpleMasks.Sum(x => x.Price) + TestBleach.Price;
            #endregion

            #region Asserts
            Assert.AreEqual(typeof(Cockroach), TestAnimal.GetType(), "Different Animal types!");
            Assert.AreEqual(typeof(Strychnine), TestPoison.GetType(), "Different Poison types!");
            Assert.AreEqual(TestPoison, TestPremiumService.Assets.Where(x => x.Equals(TestPremiumService.Poison)).SingleOrDefault(), "Different Poison instances!");
            Assert.AreEqual(3, TestProtectionSuites.Count(), "Not enough ProtectionSuites found!");
            Assert.AreEqual(3, TestSimpleMasks.Count(), "Not enough SimpleMasks found!");

            Assert.AreEqual(500, TestProtectionSuites[0].Price, "Different ProtectionSuite prices!");
            Assert.AreEqual(500, TestProtectionSuites[1].Price, "Different ProtectionSuite prices!");
            Assert.AreEqual(500, TestProtectionSuites[2].Price, "Different ProtectionSuite prices!");
            Assert.AreEqual(20, TestSimpleMasks[0].Price, "Different SimpleMask prices!");
            Assert.AreEqual(20, TestSimpleMasks[1].Price, "Different SimpleMask prices!");
            Assert.AreEqual(20, TestSimpleMasks[2].Price, "Different SimpleMask prices!");
            Assert.AreEqual(10, TestBleach.Price, "Different Bleach prices!");
            Assert.AreEqual(24, TestPoison.Price, "Different Poison prices!");

            Assert.AreEqual(TestFinalPrice, TestPremiumService.Price, "Service price is different!");
            #endregion
        }

        [TestMethod]
        public void TestBuildDeluxeService()
        {
            #region Service and Worker Team
            var TestTeamLeader = new TeamLeader(TestLeaderSalary);
            var TestWorker1 = new Worker(TestWorkerSalary);
            var TestWorker2 = new Worker(TestWorkerSalary);
            var TestWorker3 = new Worker(TestWorkerSalary);
            #endregion

            #region 
            ServiceBase TestDeluxeService = TestService.BuildService("Deluxe") as ServiceBase;

            TestTeamLeader.AddWorker(TestWorker1);
            TestTeamLeader.AddWorker(TestWorker2);
            TestTeamLeader.AddWorker(TestWorker3);

            TestDeluxeService.Team = TestTeamLeader;
            #endregion

            #region Asserts: Control vars
            var TestPoison = TestDeluxeService.Poison;
            var TestAnimal = TestDeluxeService.Animal;
            var TestBleach = TestDeluxeService.Assets.Where(x => x.GetType() == typeof(Bleach)).Single();
            var TestProtectionSuites = TestDeluxeService.Assets.Where(x => x.GetType() == typeof(ProtectionSuite)).ToList();
            var TestSimpleMasks = TestDeluxeService.Assets.Where(x => x.GetType() == typeof(SimpleMask)).ToList();
            var TestFinalPrice = TestTeamLeader.Price + TestPoison.Price
                + TestProtectionSuites.Sum(x => x.Price) + TestSimpleMasks.Sum(x => x.Price) + TestBleach.Price;

            var TestProtectionSuitePrice = 1000;
            var TestSimpleMaskPrice = 80;
            #endregion

            #region Asserts
            Assert.AreEqual(typeof(Cockroach), TestAnimal.GetType(), "Different Animal types!");
            Assert.AreEqual(typeof(Strychnine), TestPoison.GetType(), "Different Poison types!");
            Assert.AreEqual(TestPoison, TestDeluxeService.Assets.Where(x => x.Equals(TestDeluxeService.Poison)).SingleOrDefault(), "Different Poison instances!");
            Assert.AreEqual(3, TestProtectionSuites.Count(), "Not enough ProtectionSuites found!");
            Assert.AreEqual(3, TestSimpleMasks.Count(), "Not enough SimpleMasks found!");

            Assert.AreEqual(TestProtectionSuitePrice, TestProtectionSuites[0].Price, "Different ProtectionSuite prices!");
            Assert.AreEqual(TestProtectionSuitePrice, TestProtectionSuites[1].Price, "Different ProtectionSuite prices!");
            Assert.AreEqual(TestProtectionSuitePrice, TestProtectionSuites[2].Price, "Different ProtectionSuite prices!");
            Assert.AreEqual(TestSimpleMaskPrice, TestSimpleMasks[0].Price, "Different SimpleMask prices!");
            Assert.AreEqual(TestSimpleMaskPrice, TestSimpleMasks[1].Price, "Different SimpleMask prices!");
            Assert.AreEqual(TestSimpleMaskPrice, TestSimpleMasks[2].Price, "Different SimpleMask prices!");
            Assert.AreEqual(50, TestBleach.Price, "Different Bleach prices!");
            Assert.AreEqual(48, TestPoison.Price, "Different Poison prices!");

            Assert.AreEqual(TestFinalPrice, TestDeluxeService.Price, "Service price is different!");
            #endregion
        }

        [TestMethod]
        public void TestNotFoundBuildder()
        {
            try
            {
                ServiceBase asdf = TestService.BuildService("Asdf") as ServiceBase;
                Assert.Fail("ServiceBase wasn't supposed to be instantiated!");
            }
            catch (ArgumentException argex)
            {
                Assert.AreEqual("CockroachService builder unavailable or still not implemented.", argex.Message, "Unexpected exception message: " + argex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
        }
    }
}
