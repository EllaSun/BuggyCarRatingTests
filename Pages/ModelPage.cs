using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BuggyCarRating.tests
{
    public class ModelPage:BasePage
    {
        private HeaderPage headerPage;
        readonly SeleniumHelper helper;
        readonly ScenarioContext _scenarioContext;

        public ModelPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            helper = new SeleniumHelper(_scenarioContext);
            headerPage = new HeaderPage(scenarioContext);
        }

        public IWebElement comment => helper.GetElement(LocatorTypes.ID, ModelPageLocators.Comment);
        public IWebElement vote => helper.GetElement(LocatorTypes.CSS, ModelPageLocators.Vote);


        public void InputComment(string text)
        {
            comment.Clear();
            comment.SendKeys(text);
        }

        public void ClickVote()
        {
            vote.Click();
        }

        public static class ModelPageLocators
        {
            public static string Comment => "comment";
            public static string Vote => "button.btn.btn-success";
        }


    }
}
