using TechTalk.SpecFlow;

namespace BuggyCarRating.tests
{
    public class BasePage
    {
        private ScenarioContext _scenarioContext;
        
        public string BaseUrl { get; }
        public BasePage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
           
            BaseUrl = ConfigHelper.GetAppSetting("BaseUrl");
            if(!(_scenarioContext.ContainsKey("BaseUrl")))
                _scenarioContext.Add("BaseUrl", BaseUrl);
           
        }

         ~BasePage()
        { 
        }
    }
}
