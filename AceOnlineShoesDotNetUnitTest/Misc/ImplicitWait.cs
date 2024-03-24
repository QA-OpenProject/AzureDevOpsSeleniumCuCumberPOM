using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AceOnlineShoesDotNetUnitTest.Misc
{
    [TestClass]
    internal class ImplicitWait
    {
        [TestMethod]
        public void ImplicitWaitTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.aceonlineshoes.com/");
            // Implicit wait for 2 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }
    }
}
