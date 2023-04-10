using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NUnit.Framework;

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
        public IWebElement LoggedInSign => helper.GetElement(LocatorTypes.XPATH, HeaderPageLocators.LoggedInSign);

        public HeaderPage InputLogin(string text)
        {
            login.SendKeys(text);
            return this;
        }

        public HeaderPage InputPassword(string text)
        {
            password.SendKeys(text);
            return this;
        }

        public HeaderPage ClickLogin()
        {
            LoginButton.Click();
            return this;

        }

        public HeaderPage ClickRegister()
        {
            RegisterButton.Click();
            return this;
        }

        public HeaderPage IsLogged()
        {
            var result = helper.FindElement(By.XPath(HeaderPageLocators.LoggedInSign));
            Assert.IsNotNull(result, "Can not find logout msg!");
            return this;
        }

        public static class HeaderPageLocators
        {
            public static string Login=> "//input[@name='login']";
            public static string Password => "//input[@name='password']";
            public static string LoginButton => "//button[text()='Login']";
            public static string RegisterButton => "//a[text()='Register']";
            public static string LoggedInSign => "//a[contains(text(), 'Logout')]";

        }

    }
}
