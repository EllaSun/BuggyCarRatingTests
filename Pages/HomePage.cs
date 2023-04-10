using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Threading;

namespace BuggyCarRating.tests
{
    public class HomePage:BasePage
    {
        private HeaderPage headerPage;
        readonly SeleniumHelper helper;
        readonly ScenarioContext _scenarioContext;

        public HomePage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            helper = new SeleniumHelper(_scenarioContext);
            headerPage = new HeaderPage(scenarioContext);
        }

        public IWebElement popularMake => helper.GetElement(LocatorTypes.XPATH, HomePageLocators.PopularMake);
        public IWebElement popularModel => helper.GetElement(LocatorTypes.XPATH, HomePageLocators.PopularModel);
        public IWebElement overallRating => helper.GetElement(LocatorTypes.XPATH, HomePageLocators.OverallRating);
        public HomePage GoToUrl()
        {
            helper.NavigateToUrl(_scenarioContext.Get<string>("BaseUrl").ToString());
            return this;
        }
        public HomePage ClickPopularMake()
        {
            popularMake.Click();
            return this;
        }
        public HomePage ClickPopularModel()
        {
            Thread.Sleep(2000);
            popularModel.Click();
            return this;
        }

        public HomePage ClickOverallRating()
        {
            overallRating.Click();
            return this;
        }

        public static class HomePageLocators
        {
            public static string PopularMake => "//h2[contains(text(),'Popular Make')]/../a";
            public static string PopularModel => "//a[contains(@href, 'model')]";
            public static string OverallRating => "//h2[contains(text(),'Overall Rating')]/../a";

        }

    }
}
