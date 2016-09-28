using NUnit.Framework;
using OpenQA.Selenium;
using SimpleAutomated.Drivers;
using SimpleAutomated.PageObjects.Pages;

namespace SimpleAutomated.NUnit
{
    [TestFixture]
    public class ExampleNUnit
    {
        private readonly string URL = "http://google.com";

        public IWebDriver Driver { get; set; }        
        public ExamplePage Page { get; set; }

        #region Setup and TearDown - Refactoring this to BaseTestClass
        [OneTimeSetUp]
        public void Setup()
        {
            Driver = FactoryDriver.GetInstance(AvailableDrivers.chrome);            
            Page = new ExamplePage(Driver, 10000);
            Driver.Navigate().GoToUrl(URL);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        } 
        #endregion

        [Test]
        public void FindAutomatedTestOnGoogle()
        {
            string q = "Automated Test";
            Page.SetTextOnSearchField(q);
            Assert.That(Page.GetPageTitle(), Does.Contain(q));
        }
    }
}
