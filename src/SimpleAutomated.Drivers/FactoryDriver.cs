using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using System.IO;
using System.Reflection;

namespace SimpleAutomated.Drivers
{
    public static class FactoryDriver
    {
        public static IWebDriver GetInstance(AvailableDrivers driveType)
        {
            IWebDriver instance = null;
            var fileInfo = new FileInfo(Assembly.GetExecutingAssembly().Location);

            switch (driveType)
            {
                case AvailableDrivers.chrome :
                    instance = new ChromeDriver(fileInfo.Directory.FullName);
                    break;
                case AvailableDrivers.phantomjs:
                    instance = new PhantomJSDriver(fileInfo.Directory.FullName);
                    break;
                case AvailableDrivers.firefox:
                    instance = new FirefoxDriver();
                    break;                
            }

            return instance;
        }
    }
}
