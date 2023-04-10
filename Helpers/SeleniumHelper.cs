using OpenQA.Selenium;
using System.Threading;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BuggyCarRating.tests
{
    public class SeleniumHelper
    {
        private readonly IWebDriver _driver;
        ScenarioContext _scenarioContext;

        public SeleniumHelper(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("driver");
        }

        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public IWebElement FindElement(By locator)
        {
            //Hard code: Wait for a few seconds;
            //Todo: use wait method
            Thread.Sleep(2000);
            var ele = _driver.FindElement(locator);
            return ele == null ? null : ele;
        }

        public IWebElement GetElement(LocatorTypes locatorType, string locator)
        {
            IWebElement element = null;
            try
            {
                switch (locatorType)
                {
                    case LocatorTypes.XPATH:
                        element = _driver.FindElement(By.XPath(locator));
                        break;
                    case LocatorTypes.CSS:
                        element = _driver.FindElement(By.CssSelector(locator));
                        break;
                    case LocatorTypes.ID:
                        element = _driver.FindElement(By.Id(locator));
                        break;
                    case LocatorTypes.CLASS:
                        element = _driver.FindElement(By.ClassName(locator));
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Invalid locator type: " + locatorType + "please check the corresponding page object ");
            }

            return element;
        }

        public IList<IWebElement> GetElements(LocatorTypes locatorType, string locator)
        {
            IList<IWebElement> elements = null;
            try
            {
                switch (locatorType)
                {
                    case LocatorTypes.XPATH:
                        elements = _driver.FindElements(By.XPath(locator));
                        break;
                    case LocatorTypes.CSS:
                        elements = _driver.FindElements(By.CssSelector(locator));
                        break;
                    case LocatorTypes.ID:
                        elements = _driver.FindElements(By.Id(locator));
                        break;
                    case LocatorTypes.CLASS:
                        elements = _driver.FindElements(By.ClassName(locator));
                        break;
                }
            }
            catch (Exception)
            {
                throw new Exception("Invalid locator type: " + locatorType + "please check the corresponding page object ");
            }

            return elements;
        }

        public void Quit()
        {
            _driver.Quit();
        }
    }
}

