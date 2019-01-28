using ABugsDeath.Services;
using ABugsDeath.Services.ServiceFactories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ABugsDeathTests.ServiceFactoriesTests
{
    [TestClass]
    public class ServiceMainFactoryTest
    {
        [TestMethod]
        public void TestGetServiceFactory()
        {
            #region Service factory
            var TestServiceFactory = new ServiceMainFactory();
            #endregion

            #region Non-existing service factory
            try
            {
                var NonExistingService = TestServiceFactory.GetServiceFactory("asdf");
                Assert.Fail("GetServiceFactory() was supposed to fail with ArgumentException!");
            }
            catch (ArgumentException argex)
            {
                Assert.AreEqual("Service unavailable or still not implemented.", argex.Message, "Unexpected exception message: " + argex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
            #endregion

            #region Asserts: Control vars
            var TestCockroachServiceFactory = TestServiceFactory.GetServiceFactory("CockroachServiceFactory");
            var TestRatServiceFactory = TestServiceFactory.GetServiceFactory("RatServiceFactory");
            var TestFleaServiceFactory = TestServiceFactory.GetServiceFactory("FleaServiceFactory");
            #endregion

            #region Asserts
            Assert.AreEqual(typeof(CockroachServiceFactory), TestCockroachServiceFactory.GetType(), "Different service types!");
            Assert.AreEqual(typeof(RatServiceFactory), TestRatServiceFactory.GetType(), "Different service types!");
            Assert.AreEqual(typeof(FleaServiceFactory), TestFleaServiceFactory.GetType(), "Different service types!");
            #endregion
        }
    }
}
