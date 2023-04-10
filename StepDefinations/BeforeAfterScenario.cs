using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BuggyCarRating.tests.StepDefinations
{
    [Binding]
    public sealed class BeforeAfterScenario
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario(Order = 1)]
        public void BeforeScenario()
        {
           var driver = new ChromeDriver();
           ScenarioContext.Current.Add("driver",driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = ScenarioContext.Current.Get<ChromeDriver>("driver");
            driver.Quit();
        }
    }
}