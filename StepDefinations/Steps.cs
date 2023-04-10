using TechTalk.SpecFlow;
using System;

namespace BuggyCarRating.tests.StepDefinations
{
    [Binding]
    public sealed class Steps
    {
      
        readonly ScenarioContext _scenarioContext;
        public RegisterPage registerPage;

        public Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            registerPage = new RegisterPage(_scenarioContext);
        }

         [Given(@"new visitor open register page")]
        public void GivenNewVisitorOpenRegisterPage()
        {
            registerPage.GoToUrl();
        }

        [When(@"they fill in First Name '([^']*)'")]
        public void WhenTheyFillInFirstName(string firstName)
        {
            registerPage.InputFirstName(firstName);
        }

        [When(@"they fill in Last Name '([^']*)'")]
        public void WhenTheyFillInLastName(string lastName)
        {
            registerPage.InputLastName(lastName);
        }

        [When(@"they fill in unique Login")]
        public void WhenTheyFillInUniqueLogin()
        {
            string timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
            string username = $"Test_{timestamp}";
            Console.WriteLine("Registering:" + username);
            registerPage.InputLogin(username);
        }

        [When(@"they fill in Password '([^']*)'")]
        public void WhenTheyFillInPassword(string password)
        {
            ScenarioContext.Current["password"] = password;
            registerPage.InputPassword(password);
        }

        [When(@"they fill same Confirm Password")]
        public void WhenTheyFillSameConfirmPassword()
        {
            string confirmPassword = ScenarioContext.Current["password"].ToString();
            registerPage.InputConfirmPassword(confirmPassword);
        }

        [When(@"they click Register button")]
        public void WhenTheyClickRegisterButton()
        {
            registerPage.ClickRegister();
        }

        [Then(@"a message should be displayed Registration is successful'")]
        public void ThenAMessageShouldBeDisplayedRegistrationIsSuccessful()
        {
            
        }



    }
}