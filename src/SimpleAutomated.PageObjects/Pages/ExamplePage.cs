using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SimpleAutomated.PageObjects.Settings;
using System.Collections.Generic;

namespace SimpleAutomated.PageObjects.Pages
{
    /// <summary>
    /// This example uses a Google Search Page.
    /// </summary>
    public class ExamplePage : BasePageFactory
    {
        public ExamplePage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public ExamplePage(IWebDriver driver, int timeoutElementInSeconds)
            : base(driver, timeoutElementInSeconds)
        {            
            PageFactory.InitElements(base.ElementLocator.SearchContext, this);
        }

        [FindsBy(How = How.Name, Using = "q")]
        IWebElement SearchField { get; set; }

        public void SetTextOnSearchField(string textToSearch)
        {
            SearchField.SendKeys(textToSearch);
            SearchField.Submit();
            ElementLocator.LocateElement(new List<By> { By.Id("search") });            
        }

        public string GetTextOnSearchField()
        {
            return SearchField.GetAttribute("value");
        }

    }
}
