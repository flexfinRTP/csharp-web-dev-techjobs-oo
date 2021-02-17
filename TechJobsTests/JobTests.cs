using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechJobsOO;
namespace TechJobsTest
{
    [TestClass]
    public class JobTests
    {
        static Employer acme = new Employer("ACME");
        static Location desert = new Location("Desert");
        static CoreCompetency persistence = new CoreCompetency("Persistance");
        static PositionType quality = new PositionType("Quality Control");

        Job test1 = new Job("Product Tester", acme, desert, quality, persistence);
        Job test2 = new Job("Product Tester", acme, desert, quality, persistence);
        Job test3 = new Job();
        Job test4 = new Job(null, acme, desert, quality, persistence);

        [TestMethod]
        public void TestSettingJobId()
        {
            Assert.IsTrue((test1.Id < test2.Id) && ((test1.Id + 1) == test2.Id));
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.IsTrue(test1.Name == "Product Tester");
            Assert.AreEqual("Quality Control", test1.JobType.ToString());
            Assert.AreEqual(persistence.ToString(), test1.JobCoreCompetency.ToString());
            Assert.AreEqual(test1.EmployerLocation, desert);
            Assert.IsTrue(test1.EmployerName.Value == "ACME");
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(test1.Id == test2.Id);
        }

        [TestMethod]
        public void TestJobsToString()
        {
            StringAssert.StartsWith(test1.ToString(), "\n");
            StringAssert.Contains(test1.ToString(), "ID:   " + test1.Id);
            StringAssert.Contains(test1.ToString(), "Name:   Product Tester");
            StringAssert.Contains(test1.ToString(), "Employer:   ACME");
            StringAssert.Contains(test1.ToString(), "Location:   Desert");
            StringAssert.Contains(test1.ToString(), "Position Type:   Quality Control");
            StringAssert.Contains(test1.ToString(), "Core Competency:   Persistance");
            StringAssert.EndsWith(test1.ToString(), "\n");

            StringAssert.Contains(test3.ToString(), "OOPS! This job does not seem to exist.");

            StringAssert.Contains(test4.ToString(), "Data not available");
        }
    }
}