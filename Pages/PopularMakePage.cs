using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BuggyCarRating.tests
{
    public class PopularMakePage : BasePage
    {
        private HeaderPage headerPage;
        readonly SeleniumHelper helper;
        readonly ScenarioContext _scenarioContext;

        public PopularMakePage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            helper = new SeleniumHelper(_scenarioContext);
            headerPage = new HeaderPage(scenarioContext);
        }
    }
}
