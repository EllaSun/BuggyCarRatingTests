using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace BuggyCarRating.tests
{
    public class HeaderPage:BasePage
    {
        readonly SeleniumHelper helper;
        readonly ScenarioContext _scenarioContext;
       
        public HeaderPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            helper = new SeleniumHelper(_scenarioContext);
        }

        public IWebElement login => helper.GetElement(LocatorTypes.XPATH, HeaderPageLocators.Login);
        public IWebElement password => helper.GetElement(LocatorTypes.XPATH, HeaderPageLocators.Password);
        public IWebElement LoginButton => helper.GetElement(LocatorTypes.XPATH, HeaderPageLocators.LoginButton);
        public IWebElement RegisterButton => helper.GetElement(LocatorTypes.XPATH, HeaderPageLocators.RegisterButton);


        public void InputLogin(string text)
        {
            login.SendKeys(text);
        }

        public void InputPassword(string text)
        {
            password.SendKeys(text);
        }

        public void ClickLogin()
        {
            LoginButton.Click();
        }

        public void ClickRegister()
        {
            RegisterButton.Click();
        }

        public static class HeaderPageLocators
        {
            public static string Login=> "//input[@name='login']";
            public static string Password => "//input[@name='password']";
            public static string LoginButton => "//button[text()='Login']";
            public static string RegisterButton => "//a[text()='Register']";

        }

    }
}
