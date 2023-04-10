using TechTalk.SpecFlow;
using System;
using System.Threading;

namespace BuggyCarRating.tests.StepDefinations
{
    [Binding]
    public sealed class Steps
    {
      
        readonly ScenarioContext _scenarioContext;
        public RegisterPage registerPage;
        public HomePage homePage;
        public ModelPage modelPage;

        public Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            registerPage = new RegisterPage(_scenarioContext);
            homePage = new HomePage(_scenarioContext);
            modelPage = new ModelPage(_scenarioContext);
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
            _scenarioContext.Add("Username", username);
        }

        [When(@"they fill in Password '([^']*)'")]
        public void WhenTheyFillInPassword(string password)
        {
            _scenarioContext.Add("Password", password);
            registerPage.InputPassword(password);
        }

        [When(@"they fill same Confirm Password")]
        public void WhenTheyFillSameConfirmPassword()
        {
            string confirmPassword = _scenarioContext.Get<string>("Password").ToString();
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

        [Given(@"the user has successfully registered")]
        public void GivenTheUserHasSuccessfullyRegistered()
        {
            string firstName = "Test";
            string lastName = "Automation";
            string password = "Auto1234!";
            registerPage.GoToUrl();
            registerPage.InputFirstName(firstName);
            registerPage.InputLastName(lastName);
            WhenTheyFillInUniqueLogin();
            WhenTheyFillInPassword(password);
            WhenTheyFillSameConfirmPassword();
            WhenTheyClickRegisterButton();
            ThenAMessageShouldBeDisplayedRegistrationIsSuccessful();
        }

        [When(@"they fill in login credentials")]
        public void WhenTheyGoToLoginPage()
        {
            string username = _scenarioContext.Get<string>("Username").ToString();
            string password = _scenarioContext.Get<string>("Password").ToString();
            registerPage.headerPage.InputLogin(username);
            Thread.Sleep(1000);
            registerPage.headerPage.InputPassword(password)
                .ClickLogin();
        }


        [Then(@"they should be able to login")]
        public void ThenTheyShouldBeAbleToLogin()
        {
            registerPage.headerPage.IsLogged();
        }

        [Given(@"the user logged in")]
        public void GivenTheUserLoggedIn()
        {
            //There is no un vote func and can not vote twice on website
            //To avoid using same use and voting same model, everytime we 
            //register a new user.
            GivenTheUserHasSuccessfullyRegistered();
            WhenTheyGoToLoginPage();
            ThenTheyShouldBeAbleToLogin();
            //Due to website issue, manually jump back to home page
            homePage.GoToUrl();
            
        }

        [When(@"they choose their favourite car")]
        public void WhenTheyChooseTheirFavouriteCar()
        {
            //To make it easier, only vote the most popular model
            homePage.ClickPopularModel();
        }

        [Then(@"they should be able to vote it")]
        public void ThenTheyShouldBeAbleToVoteIt()
        {
            modelPage.ClickVote();
        }

        [Then(@"a message should be displayed like: You have voted!")]
        public void ThenAMessageShouldBeDisplayedLikeYouHaveVoted()
        {
           
        }



    }
}