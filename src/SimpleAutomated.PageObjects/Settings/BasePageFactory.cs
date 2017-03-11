using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
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
        TimeSpan timeout;
       
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
            this.timeout = TimeSpan.FromSeconds(timeoutElementInSeconds);            
            ElementLocator = new RetryingElementLocator(driver, this.timeout);            
            
            //SetWindowOptions(options ?? new WindowOptions());
        }

        protected void SetWindowOptions(WindowOptions options)
        {
            driver.Manage().Window.Size = options.Size;
        }

        protected void ImplicitlyWait(int seconds)
        {
            driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        /// <summary>
        /// Wait Element Disappears of the page. Normaly is a overlay during the Ajax call
        /// </summary>
        /// <param name="className"></param>
        protected void WaitForJqueryAjaxReady(string className)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.Until(driver =>
            {
                bool isAjaxFinished = (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0");
                try
                {
                    driver.FindElement(By.ClassName(className));
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return isAjaxFinished;
                }
            });
        }
        
        public string GetPageTitle()
        {
            return driver.Title;
        }
    }
}
