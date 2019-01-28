using ABugsDeath.Services;
using ABugsDeath.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABugsDeathTests.DemoTests
{
    [TestClass]
    public class DemoTest
    {
        [TestInitialize]
        public void StartDemoTest()
        {
            var Catalog = new ServiceMainFactory();

            var Service = Catalog.GetServiceFactory("CockroachServiceFactory").BuildService("Premium");

            var TeamLeader = new TeamLeader(3000) { Name = "Alfonso Beltrán" };
            TeamLeader.AddWorker(new Worker(1000) { Name = "Desiderio Martínez" });
            TeamLeader.AddWorker(new Worker(1000) { Name = "Manuel Castillejo" });

            Service.Team = TeamLeader;
            Service.MediumStrategy();
            Service.PerformService();
        }
    }
}
