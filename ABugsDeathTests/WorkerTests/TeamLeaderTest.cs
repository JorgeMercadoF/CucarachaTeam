using ABugsDeath.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABugsDeathTests.WorkerTests
{
    [TestClass]
    public class TeamLeaderTest
    {
        private decimal TestWorkerSalary = 1000;
        private decimal TestLeaderSalary = 3000;
        private TeamLeader TestLeader;
        private Worker TestWorker1;
        private Worker TestWorker2;
        private Worker TestWorker3;

        [TestInitialize]
        public void TeamLeaderTestInit()
        {
            this.TestLeader = new TeamLeader(TestLeaderSalary);
            this.TestWorker1 = new Worker(this.TestWorkerSalary);
            this.TestWorker2 = new Worker(this.TestWorkerSalary);
            this.TestWorker3 = new Worker(this.TestWorkerSalary);
        }

        [TestMethod]
        public void GetPriceTest()
        {
            #region Zero or negative salary
            try
            {
                var Leader2 = new TeamLeader(-15);
                Assert.Fail("TeamLeader construction can't be with zero or negative salary!");
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
                var Leader3 = new TeamLeader(0);
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

            this.TestLeader.AddWorker(this.TestWorker1);
            this.TestLeader.AddWorker(this.TestWorker2);
            this.TestLeader.AddWorker(this.TestWorker3);

            var ExpectedPrice = this.TestWorker1.Price + this.TestWorker2.Price + this.TestWorker3.Price + this.TestLeaderSalary;
            Assert.AreEqual(ExpectedPrice, this.TestLeader.Price, "Unexpected price.");
        }

        #region WorkerBase Methods
        [TestMethod]
        public void AddWorkerTest()
        {
            #region Extra worker and another team leader
            var TeamLeader2 = new TeamLeader(this.TestLeaderSalary);
            var Worker4 = new Worker(this.TestWorkerSalary);
            #endregion

            try
            {
                this.TestLeader.AddWorker(TeamLeader2);
                Assert.Fail("AddWorker() was supposed to fail!");
            }
            catch (ArgumentException argex)
            {
                Assert.AreEqual("A Team Leader can't command another Team Leader.", argex.Message, "Unexpected exception message on AddWorker(): " + argex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception on AddWorker(): " + ex.Message);
            }

            this.TestLeader.AddWorker(this.TestWorker1);
            this.TestLeader.AddWorker(this.TestWorker2);
            this.TestLeader.AddWorker(this.TestWorker3);

            try
            {
                this.TestLeader.AddWorker(Worker4);
                Assert.Fail("AddWorker() was supposed to fail!");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("A Team Leader can't hold more than 3 workers at a time.", ex.Message, "Unexpected exception message on AddWorker(): " + ex.Message);
            }
        }

        [TestMethod]
        public void GetWorkerTest()
        {
            #region Negatives and not found index
            try
            {
                this.TestLeader.GetWorker(-15);
                Assert.Fail("GetWorker() was supposed to fail!");
            }
            catch (ArgumentException argex)
            {
                Assert.AreEqual("No negatives allowed.", argex.Message, "Unexpected exception message on GetWorker(): " + argex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception on GetWorker(): " + ex.Message);
            }

            try
            {
                this.TestLeader.GetWorker(0);
                Assert.Fail("GetWorker() was supposed to fail!");
            }
            catch (ArgumentException argex)
            {
                Assert.AreEqual("The requested worker doesn't exist yet.", argex.Message, "Unexpected exception message on GetWorker(): " + argex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception on GetWorker(): " + ex.Message);
            }
            #endregion

            this.TestLeader.AddWorker(this.TestWorker1);
            this.TestLeader.AddWorker(this.TestWorker2);
            this.TestLeader.AddWorker(this.TestWorker3);

            try
            {
                this.TestLeader.GetWorker(3);
                Assert.Fail("GetWorker() was supposed to fail!");
            }
            catch (ArgumentException argex)
            {
                Assert.AreEqual("The requested worker doesn't exist yet.", argex.Message, "Unexpected exception message on GetWorker(): " + argex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception on GetWorker(): " + ex.Message);
            }

            Assert.AreEqual(this.TestWorker2, this.TestLeader.GetWorker(1), "Different workers!");
        }

        [TestMethod]
        public void RemoveWorkerTest()
        {
            Assert.IsFalse(this.TestLeader.RemoveWorker(this.TestWorker2));

            this.TestLeader.AddWorker(this.TestWorker1);
            this.TestLeader.AddWorker(this.TestWorker2);
            this.TestLeader.AddWorker(this.TestWorker3);

            Assert.IsTrue(this.TestLeader.RemoveWorker(this.TestWorker2));
        }
        #endregion
    }
}
