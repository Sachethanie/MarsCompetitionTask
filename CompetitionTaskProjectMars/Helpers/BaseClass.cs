using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Chrome;
using ProjectMars.Utils;


namespace ProjectMars.Helpers
{
    public class BaseClass : Driver
    {
        protected ExtentReports extent;
        protected ExtentTest test;

        [SetUp]
        public void Setup()
        {
            // Start logging the setup in the report
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Setup Started");
            test.Log(Status.Info, "Navigating to Sign in Page");
            Start.SignInAndNavigate();
        }

        [TearDown]
        public void TearDown()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            if (outcome == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Log(Status.Fail, $"Test Failed: {message}");
            }
            else if (outcome == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                test.Log(Status.Pass, "Test Passed");
            }
            else
            {
                test.Log(Status.Skip, "Test Skipped or Inconclusive");
            }

            driver.Quit();
        }

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            var spark = new ExtentSparkReporter(ConstantHelpers.ReportHTMLPath);
            extent = new ExtentReports();
            extent.AttachReporter(spark);
     
            // WebDriver setup
            driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        protected void GlobalTearDown()
        {
            extent.Flush();
        }

    }
}







