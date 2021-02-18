using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestSettingJobId()
        {
            Job test_job = new Job();
            Job test_job2 = new Job();

            Assert.AreNotEqual(test_job2.Id, test_job.Id);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job test_job = new Job("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

            Assert.AreEqual(test_job.Name, "Product Tester");
            Assert.AreEqual(test_job.EmployerName.Value, "ACME");
            Assert.AreEqual(test_job.EmployerLocation.Value, "Desert");
            Assert.AreEqual(test_job.JobType.Value, "Quality control");
            Assert.AreEqual(test_job.JobCoreCompetency.Value, "Persistence");
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job test_job = new Job("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Job test_job2 = new Job("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

            Assert.AreNotEqual(test_job.Id, test_job2.Id);
        }



        [TestMethod]
        public void FirstStringTest()
        {
            Job test_job = new Job("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

            string newOutput = test_job.ToString();

            Assert.AreEqual(true, newOutput.EndsWith("\n"));

            Assert.AreEqual("\n", newOutput.Substring(0, 1));
        }

        [TestMethod]
        public void SecondStringTest()
        {
            Job test_job = new Job("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

            string newOutput = test_job.ToString();

            Assert.AreEqual(true, newOutput.Contains("Product Tester"));
            Assert.AreEqual(true, newOutput.Contains("ACME"));
            Assert.AreEqual(true, newOutput.Contains("Desert"));
            Assert.AreEqual(true, newOutput.Contains("Quality control"));
            Assert.AreEqual(true, newOutput.Contains("Persistence"));
        }

        [TestMethod]
        public void ThirdStringTest()
        {
            Job test_job = new Job("Product Tester", new Employer(""), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

            string newOutput = test_job.ToString();

            Assert.AreEqual(true, newOutput.Contains("Employer: Data not available"));
        }
    }
}