using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;



namespace AceOnlineShoesDotNetUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public static IWebDriver driver = new ChromeDriver();

        [TestMethod]
        public void LaunchPage()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
            driver.Manage().Window.Maximize();

            // Explicit wait and click on the checkbox
            WebDriverWait waitCheckBox = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(driver => driver.FindElement(By.XPath("//input[@type='checkbox']")));
            waitCheckBox.Until(driver => driver.FindElement(By.XPath("//input[@type='checkbox']"))).Click();

            // Navigate to the Sign In Portal
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            WebDriverWait waitLogin = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitLogin.Until(driver => driver.FindElement(By.XPath("//li[normalize-space()='Sign In Portal']"))).Click();
            Console.WriteLine("Navigated to Sign In Portal");
            //driver.FindElement(By.XPath("//li[normalize-space()='Sign In Portal']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var userlength = driver.FindElements(By.Id("usr")).Count;
            Assert.AreEqual(1, userlength);
            Console.WriteLine("User length Assert");

            var passlength = driver.FindElements(By.Id("pwd")).Count;
            Assert.AreEqual(1, passlength);
            Console.WriteLine("Password length Assert");

            driver.FindElement(By.XPath("//input[@type='checkbox']")).Click();
            WebDriverWait waitRegisterBtn = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitRegisterBtn.Until(ExpectedConditions.ElementToBeClickable(By.Id("NewRegistration"))).Click();
            Console.WriteLine("Clicked on Register Button");

            // Implicit wait for 2 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);


            driver.Quit();
        }

    }

}
