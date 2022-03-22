using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SwaggerAPITesting;
using SwaggerAPITesting.APISteps;
using SwaggerAPITesting.Utilities;
using System;

namespace BaseTest{

    // NUnit Framework driver class. SetUp and TearDown methods Setup here
    public abstract class TestBase{

        protected ExtentReportsHelper extent;

        internal readonly UserUtility userHelper = new UserUtility();
        internal readonly PetUtility petHelper = new PetUtility();
        internal readonly OrderUtility orderHelper = new OrderUtility();

        // Initializing steps for all three actor types.
        internal readonly OrderSteps OrderSteps = new OrderSteps();
        internal readonly UserSteps UserSteps = new UserSteps();
        internal readonly PetSteps PetSteps = new PetSteps();

        [OneTimeSetUp]
        public void SetUpReporter(){

            extent = new ExtentReportsHelper();
        }
        [SetUp]
        public void StartUpTest(){

            extent.CreateTest(TestContext.CurrentContext.Test.Name);
         }
        [TearDown]
        public void AfterTest(){

            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                switch (status)
                {
                    case TestStatus.Failed:
                        extent.SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        break;
                    case TestStatus.Skipped:
                        extent.SetTestStatusSkipped();
                        break;
                    default:
                        extent.SetTestStatusPass();
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }

        }
        [OneTimeTearDown]
        public void CloseAll(){

            try
            {
                extent.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}