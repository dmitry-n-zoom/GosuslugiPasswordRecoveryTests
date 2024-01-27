using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace GosuslugiPasswordRecoveryTests
{
    public class Tests
    {
        public IWebDriver driver;
        private readonly By _signInButton = By.XPath("//button[text()='Войти']");
        private readonly By _loginTroubleButton = By.XPath("//button[contains(text(), 'Не удаётся войти?')]");
        private readonly By _passwordRecoveryButton = By.XPath("//button[contains(text(), 'восстановления пароля')]");

        private const string BaseUrl = "https://www.gosuslugi.ru/";
        private const string RecoveryUrl = "https://esia.gosuslugi.ru/login/recovery";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(BaseUrl);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(_signInButton)).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(_loginTroubleButton)).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(_passwordRecoveryButton)).Click();

            wait.Until(driver => driver.Url.Contains(RecoveryUrl));
            Assert.IsTrue(driver.Url.Contains(RecoveryUrl), "The password recovery form is not open");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
