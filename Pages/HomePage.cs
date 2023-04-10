using OpenQA.Selenium;
using TechTalk.SpecFlow;

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

        public void ClickPopularMake()
        {
            popularMake.Click();
        }
        public void ClickPopularModel()
        {
            popularModel.Click();
        }

        public void ClickOverallRating()
        {
            overallRating.Click();
        }

        public static class HomePageLocators
        {
            public static string PopularMake => "//h2[contains(text(),'Popular Make')]/../a";
            public static string PopularModel => "//h2[contains(text(),'Popular Model')]/../a";
            public static string OverallRating => "//h2[contains(text(),'Overall Rating')]/../a";

        }

    }
}
