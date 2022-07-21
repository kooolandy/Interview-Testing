using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Testing
{
    [Binding]
    public class StartupHooks
    {
        private static ChromeDriver driver;

        [BeforeFeature]
        public static void OneTime()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--ignore-ssl-errors=yes");
            options.AddArgument("--ignore-certificate-errors");
            driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [BeforeScenario]
        public void SetUp()
        {
        }

        [AfterFeature]
        public static void FeatureTearDown()
        {
            if (driver == null)
                return;

            driver.Close();
            driver.Dispose();
        }


        public static string Url
        {
            get { return driver.Url; }
            set { driver.Url = value; }
        }

        public static IWebDriver Webdriver
        { 
            get { return driver; }
        }
    }
}