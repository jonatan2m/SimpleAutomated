using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAutomated.PageObjects
{
    public static class WebDriverExtensions
    {
        public static IWebElement WaitForElement(this IWebDriver driver, By by, int timeoutInSeconds = 30)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));                
                var element = wait.Until(drv => drv.FindElement(by));
                return element;
            }
            return driver.FindElement(by);
        }
    }
}
