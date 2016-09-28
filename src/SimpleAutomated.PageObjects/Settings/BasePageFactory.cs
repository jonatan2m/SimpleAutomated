using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAutomated.PageObjects.Settings
{
    public abstract class BasePageFactory
    {
        protected IWebDriver driver;
       
        /// <summary>
        /// AjaxElementLocatorFactory 
        /// </summary>
        protected RetryingElementLocator ElementLocator { get; private set; }

        public BasePageFactory(IWebDriver driver, WindowOptions options = null)            
        {
            this.driver = driver;
            SetWindowOptions(options ?? new WindowOptions());
        }

        public BasePageFactory(IWebDriver driver, 
            int timeoutElementInSeconds, WindowOptions options = null)
        {
            this.driver = driver;
            var timeout = TimeSpan.FromSeconds(timeoutElementInSeconds);            
            ElementLocator = new RetryingElementLocator(driver, timeout);            
            SetWindowOptions(options ?? new WindowOptions());
        }

        protected void SetWindowOptions(WindowOptions options)
        {
            driver.Manage().Window.Size = options.Size;
        }

        protected void ImplicitlyWait(int seconds)
        {
            driver.Manage()
                .Timeouts()
                .ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }
        
        public string GetPageTitle()
        {
            return driver.Title;
        }
    }
}
