using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SwaggerAPITesting{

    public class ExtentReportsHelper{

        static ExtentReports extent { get; set; }
        static ExtentV3HtmlReporter reporter { get; set; }
        static ExtentTest test { get; set; }

        static ExtentReportsHelper(){

            extent = new ExtentReports();

            // Using this particular Reporter because the output file name is fixed to index for ExtentHtmlReporter
            reporter = new ExtentV3HtmlReporter("../../Reports/ExtentReports.html");
            reporter.Config.DocumentTitle = "Automation Testing Report";
            reporter.Config.ReportName = "Regression Testing";
            reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent.AddSystemInfo("Application Under Test", "Sawgger API Testing");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Machine", Environment.MachineName);
            extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
            extent.AttachReporter(reporter);

        }
        public void CreateTest(string testName){

            test = extent.CreateTest(testName);
        }
        public void SetStepStatusPass(string stepDescription){

            test.Log(Status.Pass, stepDescription);
        }
        public void SetStepStatusWarning(string stepDescription){

            test.Log(Status.Warning, stepDescription);
        }
        public void SetTestStatusPass(){

            test.Pass("Test Executed Sucessfully!");
        }
        public void SetTestStatusFail(string message = null){

            var printMessage = "<p><b>Test FAILED!</b></p>";
            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }
            test.Fail(printMessage);
        }
        public void SetTestStatusSkipped(){

            test.Skip("Test skipped!");
        }
        public void Close(){

            extent.Flush();
        }
    }
}