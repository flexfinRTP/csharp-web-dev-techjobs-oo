using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechJobsOO;
namespace TechJobTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestSettingJobId()
        {

            Job testObject1 = new Job();
            Job testObject2 = new Job();

            Assert.IsTrue(testObject1.Id != testObject2.Id && (testObject1.Id + 1) == testObject2.Id);

        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job testObject = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality"), new CoreCompetency("Persistence"));

            {
                Assert.IsTrue(testObject.Name == "Product tester");
                Assert.IsTrue(testObject.EmployerName.Value == "ACME");
                Assert.IsTrue(testObject.JobLocation.Value == "Desert");
                Assert.IsTrue(testObject.JobType.Value == "Quality");
                Assert.IsTrue(testObject.JobCoreCompetency.Value == "Persistence");
            }

        }
        [TestMethod]
        public void TestJobsForEquality()
        {

            Job testObject1 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"))
            {
                //testObject1.Id = 1;


            };
            Job testObject2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"))
            {
                //testObject.Id = 2;
            };

            Assert.IsFalse(testObject1.Equals(testObject2));
        }

        [TestMethod]
        public void TestForToString()
        {
            Job testObject = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            {
                string expectedOutput = $"ID: {testObject.Id} \n Name: {testObject.Name} \n Employer: {testObject.EmployerName} \n Location: {testObject.JobLocation} \n Position Type: {testObject.JobType} \n Core Compentency: {testObject.JobCoreCompetency}";
                Assert.AreEqual(expectedOutput, testObject.ToString());
            }
        }

    }
}