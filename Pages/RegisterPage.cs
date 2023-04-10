using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BuggyCarRating.tests
{
    public class RegisterPage:HomePage
    {
        public HeaderPage headerPage;
        readonly SeleniumHelper helper;
        readonly ScenarioContext _scenarioContext;
       

        public RegisterPage(ScenarioContext scenarioContext):base(scenarioContext) 
        {
            _scenarioContext = scenarioContext;
            helper = new SeleniumHelper(_scenarioContext);
            headerPage = new HeaderPage(scenarioContext);
        }

        public IWebElement Login => helper.GetElement(LocatorTypes.XPATH, RegisterPageLocators.Login);
        public IWebElement FirstName => helper.GetElement(LocatorTypes.XPATH, RegisterPageLocators.FirstName);
        public IWebElement LastName => helper.GetElement(LocatorTypes.XPATH, RegisterPageLocators.LastName);
        public IWebElement Password => helper.GetElement(LocatorTypes.XPATH, RegisterPageLocators.Password);
        public IWebElement ConfirmPassword => helper.GetElement(LocatorTypes.XPATH, RegisterPageLocators.ConfirmPassword);
        public IWebElement Register => helper.GetElement(LocatorTypes.XPATH, RegisterPageLocators.Register);
        public IWebElement Cancel => helper.GetElement(LocatorTypes.XPATH, RegisterPageLocators.Cancel);

        public RegisterPage GoToUrl()
        {
            helper.NavigateToUrl(_scenarioContext.Get<string>("BaseUrl").ToString() + "/register");
            return this;
        }
        public RegisterPage InputLogin(string value)
        {
            Login.Clear();
            Login.SendKeys(value);
            return this;
        }

        public RegisterPage InputFirstName(string value)
        {
            FirstName.Clear();
            FirstName.SendKeys(value);
            return this;
        }

        public RegisterPage InputLastName(string value)
        {
            LastName.Clear();
            LastName.SendKeys(value);
            return this;
        }

        public RegisterPage InputPassword(string value)
        {
            Password.Clear();
            Password.SendKeys(value);
            return this;
        }

        public RegisterPage InputConfirmPassword(string value)
        {
            ConfirmPassword.Clear();
            ConfirmPassword.SendKeys(value);
            return this;
        }

        public RegisterPage ClickRegister()
        {
            Register.Click();
            return this;
        }

        public RegisterPage ClickCancel()
        {
            Cancel.Click();
            return this;
        }

        public static class RegisterPageLocators
        {
            public static string Login => "//input[@id='username']";
            public static string FirstName => "//input[@name='firstName']";
            public static string LastName => "//input[@name='lastName']";
            public static string Password => "//input[@id='password']";
            public static string ConfirmPassword => "//input[@id='confirmPassword']";
            public static string Register => "//button[contains(text(), 'Register')]";
            public static string Cancel => "//a[contains(text(), 'Cancel')]";
        }
    }
}
