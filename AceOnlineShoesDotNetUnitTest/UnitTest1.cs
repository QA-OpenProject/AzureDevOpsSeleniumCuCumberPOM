using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.Threading;


namespace AceOnlineShoesDotNetUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public static IWebDriver driver = new ChromeDriver();

        [TestMethod]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["url"]);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }

}
