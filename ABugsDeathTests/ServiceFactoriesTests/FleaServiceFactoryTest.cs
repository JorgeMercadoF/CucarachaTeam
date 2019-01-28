using ABugsDeath.Animals;
using ABugsDeath.Assets;
using ABugsDeath.Interfaces;
using ABugsDeath.Services;
using ABugsDeath.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ABugsDeathTests.ServiceFactoriesTests
{
    [TestClass]
    public class FleaServiceFactoryTest
    {
        private decimal TestLeaderSalary = 3000;
        private decimal TestWorkerSalary = 1000;
        private IServiceFactory TestService;

        [TestInitialize]
        public void Init()
        {
            var TestMainFactory = new ServiceMainFactory();
            this.TestService = TestMainFactory.GetServiceFactory("FleaServiceFactory");
        }

        [TestMethod]
        public void TestBuildBasicService()
        {
            #region Service and Worker Team
            var TestTeamLeader = new TeamLeader(TestLeaderSalary);
            var TestWorker1 = new Worker(TestWorkerSalary);
            #endregion

            #region 
            ServiceBase TestBasicService = TestService.BuildService("Basic") as ServiceBase;

            TestTeamLeader.AddWorker(TestWorker1);

            TestBasicService.Team = TestTeamLeader;
            #endregion

            #region Asserts: Control vars
            var TestPoison = TestBasicService.Poison;
            var TestAnimal = TestBasicService.Animal;
            var TestProtectionSuite = TestBasicService.Assets.Where(x => x.GetType() == typeof(ProtectionSuite)).Single();
            var TestIsolatedMask = TestBasicService.Assets.Where(x => x.GetType() == typeof(IsolatedMask)).Single();
            var TestPoisonDiffuser = TestBasicService.Assets.Where(x => x.GetType() == typeof(PoisonDiffuser)).Single();
            var TestBleach = TestBasicService.Assets.Where(x => x.GetType() == typeof(Bleach)).Single();
            var TestFinalPrice = TestTeamLeader.Price + TestPoison.Price + TestProtectionSuite.Price + TestIsolatedMask.Price + TestPoisonDiffuser.Price + TestBleach.Price;
            #endregion

            #region Asserts
            Assert.AreEqual(typeof(Flea), TestAnimal.GetType(), "Different Animal types!");
            Assert.AreEqual(typeof(Cyanide), TestPoison.GetType(), "Different Poison types!");
            Assert.AreEqual(TestPoison, TestBasicService.Assets.Where(x => x.Equals(TestBasicService.Poison)).SingleOrDefault(), "Different Poison instances!");
            Assert.AreEqual(typeof(ProtectionSuite), TestProtectionSuite.GetType(), "No ProtectionSuite found!");
            Assert.AreEqual(typeof(IsolatedMask), TestIsolatedMask.GetType(), "No IsolatedMask found!");
            Assert.AreEqual(typeof(PoisonDiffuser), TestPoisonDiffuser.GetType(), "No PoisonDiffuser found!");

            Assert.AreEqual(500, TestProtectionSuite.Price, "Different ProtectionSuite prices!");
            Assert.AreEqual(20, TestIsolatedMask.Price, "Different IsolatedMask prices!");
            Assert.AreEqual(50, TestPoisonDiffuser.Price, "Different PoisonDiffuser prices!");
            Assert.AreEqual(60, TestPoison.Price, "Different Poison prices!");
            Assert.AreEqual(400, TestBleach.Price, "Different Bleach prices!");

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
            #endregion

            #region 
            ServiceBase TestPremiumService = TestService.BuildService("Premium") as ServiceBase;

            TestTeamLeader.AddWorker(TestWorker1);
            TestTeamLeader.AddWorker(TestWorker2);

            TestPremiumService.Team = TestTeamLeader;
            #endregion

            #region Asserts: Control vars
            var TestPoison = TestPremiumService.Poison;
            var TestAnimal = TestPremiumService.Animal;
            var TestProtectionSuites = TestPremiumService.Assets.Where(x => x.GetType() == typeof(ProtectionSuite)).ToList();
            var TestIsolatedMasks = TestPremiumService.Assets.Where(x => x.GetType() == typeof(IsolatedMask)).ToList();
            var TestPoisonDiffusers = TestPremiumService.Assets.Where(x => x.GetType() == typeof(PoisonDiffuser)).ToList();
            var TestBleach = TestPremiumService.Assets.Where(x => x.GetType() == typeof(Bleach)).Single();
            var TestFinalPrice = TestTeamLeader.Price + TestPoison.Price + TestProtectionSuites.Sum(x => x.Price) + TestIsolatedMasks.Sum(x => x.Price) 
                + TestPoisonDiffusers.Sum(x => x.Price) + TestBleach.Price;
            #endregion

            #region Asserts
            Assert.AreEqual(typeof(Flea), TestAnimal.GetType(), "Different Animal types!");
            Assert.AreEqual(typeof(Cyanide), TestPoison.GetType(), "Different Poison types!");
            Assert.AreEqual(TestPoison, TestPremiumService.Assets.Where(x => x.Equals(TestPremiumService.Poison)).SingleOrDefault(), "Different Poison instances!");
            Assert.AreEqual(2, TestProtectionSuites.Count(), "Not enough ProtectionSuites found!");
            Assert.AreEqual(2, TestIsolatedMasks.Count(), "Not enough IsolatedMasks found!");
            Assert.AreEqual(2, TestPoisonDiffusers.Count(), "Not enough PoisonDiffusers found!");

            Assert.AreEqual(500, TestProtectionSuites[0].Price, "Different ProtectionSuite prices!");
            Assert.AreEqual(500, TestProtectionSuites[1].Price, "Different ProtectionSuite prices!");
            Assert.AreEqual(20, TestIsolatedMasks[0].Price, "Different IsolatedMask prices!");
            Assert.AreEqual(20, TestIsolatedMasks[1].Price, "Different IsolatedMask prices!");
            Assert.AreEqual(50, TestPoisonDiffusers[1].Price, "Different PoisonDiffuser prices!");
            Assert.AreEqual(50, TestPoisonDiffusers[1].Price, "Different PoisonDiffuser prices!");
            Assert.AreEqual(400, TestBleach.Price, "Different Bleach prices!");
            Assert.AreEqual(240, TestPoison.Price, "Different Poison prices!");

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
            var TestProtectionSuites = TestDeluxeService.Assets.Where(x => x.GetType() == typeof(ProtectionSuite)).ToList();
            var TestIsolatedMasks = TestDeluxeService.Assets.Where(x => x.GetType() == typeof(IsolatedMask)).ToList();
            var TestPoisonDiffusers = TestDeluxeService.Assets.Where(x => x.GetType() == typeof(PoisonDiffuser)).ToList();
            var TestBleach = TestDeluxeService.Assets.Where(x => x.GetType() == typeof(Bleach)).Single();
            var TestFinalPrice = TestTeamLeader.Price + TestPoison.Price + TestProtectionSuites.Sum(x => x.Price) + TestIsolatedMasks.Sum(x => x.Price)
                + TestPoisonDiffusers.Sum(x => x.Price) + TestBleach.Price;
            #endregion

            #region Asserts
            Assert.AreEqual(typeof(Flea), TestAnimal.GetType(), "Different Animal types!");
            Assert.AreEqual(typeof(Cyanide), TestPoison.GetType(), "Different Poison types!");
            Assert.AreEqual(TestPoison, TestDeluxeService.Assets.Where(x => x.Equals(TestDeluxeService.Poison)).SingleOrDefault(), "Different Poison instances!");
            Assert.AreEqual(3, TestProtectionSuites.Count(), "Not enough ProtectionSuites found!");
            Assert.AreEqual(3, TestIsolatedMasks.Count(), "Not enough IsolatedMasks found!");
            Assert.AreEqual(3, TestPoisonDiffusers.Count(), "Not enough PoisonDiffusers found!");

            Assert.AreEqual(1000, TestProtectionSuites[0].Price, "Different ProtectionSuite prices!");
            Assert.AreEqual(1000, TestProtectionSuites[1].Price, "Different ProtectionSuite prices!");
            Assert.AreEqual(1000, TestProtectionSuites[2].Price, "Different ProtectionSuite prices!");
            Assert.AreEqual(80, TestIsolatedMasks[0].Price, "Different IsolatedMask prices!");
            Assert.AreEqual(80, TestIsolatedMasks[1].Price, "Different IsolatedMask prices!");
            Assert.AreEqual(80, TestIsolatedMasks[2].Price, "Different IsolatedMask prices!");
            Assert.AreEqual(70, TestPoisonDiffusers[1].Price, "Different PoisonDiffuser prices!");
            Assert.AreEqual(70, TestPoisonDiffusers[1].Price, "Different PoisonDiffuser prices!");
            Assert.AreEqual(70, TestPoisonDiffusers[2].Price, "Different PoisonDiffuser prices!");
            Assert.AreEqual(1000, TestBleach.Price, "Different Bleach prices!");
            Assert.AreEqual(375, TestPoison.Price, "Different Poison prices!");

            Assert.AreEqual(TestFinalPrice, TestDeluxeService.Price, "Service price is different!");
            #endregion
        }

        [TestMethod]
        public void TestNotFoundBuilder()
        {
            try
            {
                ServiceBase asdf = TestService.BuildService("Asdf") as ServiceBase;
                Assert.Fail("ServiceBase wasn't supposed to be instantiated!");
            }
            catch (ArgumentException argex)
            {
                Assert.AreEqual("FleaService builder unavailable or still not implemented.", argex.Message, "Unexpected exception message: " + argex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
        }
    }
}
