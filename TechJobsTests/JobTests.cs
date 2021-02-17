using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechJobsOO;
namespace TechJobTests
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

            Job testObject1 = new Job();
            Job testObject2 = new Job();

            Assert.IsTrue(testObject1.Id != testObject2.Id && (testObject1.Id + 1) == testObject2.Id);

            Assert.IsTrue((test1.Id < test2.Id) && ((test1.Id + 1) == test2.Id));

        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job testObject = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality"), new CoreCompetency("Persistence"));

            {
                Assert.IsTrue(testObject.Name == "Product tester");
                Assert.IsTrue(testObject.EmployerName.Value == "ACME");
                Assert.IsTrue(testObject.EmployerLocation.Value == "Desert");
                Assert.IsTrue(testObject.JobType.Value == "Quality");
                Assert.IsTrue(testObject.JobCoreCompetency.Value == "Persistence");

                Assert.IsTrue(test1.Name == "Product Tester");
                Assert.AreEqual("Quality Control", test1.JobType.ToString());
                Assert.AreEqual(persistence.ToString(), test1.JobCoreCompetency.ToString());
                Assert.AreEqual(test1.EmployerLocation, desert);
                Assert.IsTrue(test1.EmployerName.Value == "ACME");
            }

        }
        [TestMethod]
        public void TestJobsForEquality()
        {

            Job testObject1 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"))
            {
            };
            Job testObject2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"))
            {
            };
            Assert.IsFalse(testObject1.Equals(testObject2));

            Assert.IsFalse(test1.Id == test2.Id);
        }

        [TestMethod]
        public void TestForToString()
        {
            Job testObject = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            {
                string expectedOutput = $"ID: {testObject.Id} \n Name: {testObject.Name} \n Employer: {testObject.EmployerName} \n Location: {testObject.EmployerLocation} \n Position Type: {testObject.JobType} \n Core Compentency: {testObject.JobCoreCompetency}";
                Assert.AreEqual(expectedOutput, testObject.ToString());

                StringAssert.StartsWith(test1.ToString(), "\n");
                StringAssert.EndsWith(test1.ToString(), "\n");
            }
        }

        [TestMethod]
        public void TestForOutput()
        {
            Job testObject = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            {
                string expectedOutput = $"ID: {testObject.Id} \n Name: {testObject.Name} \n Employer: Data Not Available \n Location: {testObject.EmployerLocation} \n Position Type: {testObject.JobType} \n Core Compentency: {testObject.JobCoreCompetency}";
                Assert.AreEqual(expectedOutput, "Data Not Available");
            }
        }
        public void TestJobsToStringAlt()
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