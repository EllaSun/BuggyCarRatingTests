using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Threading;

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


        public ModelPage InputComment(string text)
        {
            comment.Clear();
            comment.SendKeys(text);
            return this;
        }

        public ModelPage ClickVote()
        {
            Thread.Sleep(2000);
            vote.Click();
            return this;
        }

        public static class ModelPageLocators
        {
            public static string Comment => "comment";
            public static string Vote => "button.btn.btn-success";
        }


    }
}
