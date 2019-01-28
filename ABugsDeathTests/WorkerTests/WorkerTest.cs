using ABugsDeath.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ABugsDeathTests.WorkerTests
{
    [TestClass]
    public class WorkerTest
    {
        private decimal TestSalary = 1500;
        private Worker TestWorker;

        [TestInitialize]
        public void Init()
        {
            this.TestWorker = new Worker(TestSalary);
        }

        [TestMethod]
        public void GetPriceTest()
        {
            #region Zero or negative salary
            try
            {
                var Worker2 = new Worker(-15);
                Assert.Fail("Worker construction can't be with zero or negative salary!");
            }
            catch (ArgumentException argex)
            {
                Assert.AreEqual("A worker must have a higher-than-zero salary!", argex.Message, "Unexpected exception message on new Worker(): " + argex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception on new Worker(): " + ex.Message);
            }

            try
            {
                var Worker3 = new Worker(0);
                Assert.Fail("Worker construction can't be with zero or negative salary!");
            }
            catch (ArgumentException argex)
            {
                Assert.AreEqual("A worker must have a higher-than-zero salary!", argex.Message, "Unexpected exception message on new Worker(): " + argex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception on new Worker(): " + ex.Message);
            }
            #endregion

            Assert.AreEqual(TestSalary, this.TestWorker.Price, "Unexpected price.");
        }

        #region WorkerBase Methods
        [TestMethod]
        public void AddWorkerTest()
        {
            try
            {
                this.TestWorker.AddWorker(new Worker(TestSalary));
                Assert.Fail("AddWorker() was supposed to fail!");
            }
            catch (NotSupportedException ns)
            {
                Assert.AreEqual("This worker can't have workers.", ns.Message, "Unexpected exception message on AddWorker(): " + ns.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception on AddWorker(): " + ex.Message);
            }
        }

        [TestMethod]
        public void GetWorkerTest()
        {
            try
            {
                this.TestWorker.GetWorker(0);
                Assert.Fail("GetWorker() was supposed to fail!");
            }
            catch (NotSupportedException ns)
            {
                Assert.AreEqual("This worker can't have workers.", ns.Message, "Unexpected exception message on GetWorker(): " + ns.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception on GetWorker(): " + ex.Message);
            }
        }

        [TestMethod]
        public void RemoveWorkerTest()
        {
            try
            {
                this.TestWorker.RemoveWorker(new Worker(TestSalary));
                Assert.Fail("RemoveWorker() was supposed to fail!");
            }
            catch (NotSupportedException ns)
            {
                Assert.AreEqual("This worker can't have workers.", ns.Message, "Unexpected exception message on RemoveWorker(): " + ns.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception on RemoveWorker(): " + ex.Message);
            }
        }
        #endregion
    }
}
