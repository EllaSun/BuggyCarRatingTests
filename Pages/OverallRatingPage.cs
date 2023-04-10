using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace BuggyCarRating.tests
{
    public class OverallRatingPage:BasePage
    {
        private HeaderPage headerPage;
        readonly SeleniumHelper helper;
        readonly ScenarioContext _scenarioContext;

        public OverallRatingPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            helper = new SeleniumHelper(_scenarioContext);
            headerPage = new HeaderPage(scenarioContext);
        }

        public IList<IWebElement> MakeList => helper.GetElements(LocatorTypes.XPATH, OveralRatingPageLocators.MakeCol);
        public IList<IWebElement> ModelList => helper.GetElements(LocatorTypes.XPATH, OveralRatingPageLocators.ModelCol);
        public IList<IWebElement> RankList => helper.GetElements(LocatorTypes.XPATH, OveralRatingPageLocators.RankCol);
        public IList<IWebElement> VotesList => helper.GetElements(LocatorTypes.XPATH, OveralRatingPageLocators.VotesCol);

        public string GetMakeName(int index)
        {
            return MakeList[index].Text;
        }

        public string GetModelName(int index)
        {
            return ModelList[index].Text;
        }

        public string GetRank(int index)
        {
            return RankList[index].Text;
        }

        public string GetVotes(int index)
        {
            return VotesList[index].Text;
        }


        public static class OveralRatingPageLocators
        {
            public static string MakeCol => "//tbody/tr/td[2]";
            public static string ModelCol => "//tbody/tr/td[3]";
            public static string RankCol => "//tbody/tr/td[4]";
            public static string VotesCol => "//tbody/tr/td[5]";
           

        }

    }
}
