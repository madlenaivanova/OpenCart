using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace OpenCartTests
{

    namespace OpenCartTests
    {
        [TestClass]
        public class HomePageTests
        {
            IWebDriver driver;

            [TestInitialize]
            public void TestSetup()
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
        

            [TestCleanup]
            public void TestTeardown()
            {
                driver.Quit();
            }

            [TestCategory("HomePageTests")]
            [TestMethod]
            public void Test01NavigateToHomePage()
            {
                driver.Navigate().GoToUrl(@"https://www.opencart.com");

                Thread.Sleep(1000);

                var homePageHeading = driver.FindElement(By.CssSelector("h1"));

                var expectedHeadingText = "The best FREE and open-source eCommerce platform";

                var actualHeadingText = homePageHeading.Text;

                Assert.AreEqual(expectedHeadingText, actualHeadingText);


        [TestCategory("HomePageTests")]
            [TestMethod]
            public void Test02NavigateToLogIn()
            {
                driver.Navigate().GoToUrl(@"https://www.opencart.com/index.php?route=account/login");

                Thread.Sleep(3000);

                var email = driver.FindElement(By.Id("input-email"));

                var password = driver.FindElement(By.Id("input-password"));


                var loginButton = driver.FindElement(By.CssSelector("button.btn"));
                var continueButton = driver.FindElement(By.CssSelector("button.btn"));

                email.Clear();
                email.SendKeys("mad17@abv.bg");

                password.Clear();
                password.SendKeys("englisc");

                loginButton.Click();
                Thread.Sleep(5000);

                var loggedUserName = driver.FindElement(By.XPath("//a[contains(text(),'PIN')]"));

                Thread.Sleep(6000);

                Assert.AreEqual("PIN", loggedUserName.Text);

                var pin = driver.FindElement(By.Id("input-pin"));

                pin.Clear();
                pin.SendKeys("1717");

                continueButton.Click();

            }

            [TestCategory("HomePageTests")]
            [TestMethod]
            public void Test02NavigateToDemo()
            {
                driver.Navigate().GoToUrl(@"https://demo.opencart.com/admin/");

                Thread.Sleep(1000);

                var userName = driver.FindElement(By.Id("input-username"));

                var password = driver.FindElement(By.Id("input-password"));

                var loginButton = driver.FindElement(By.CssSelector("button.btn"));

                userName.Clear();
                userName.SendKeys("mad17@abv.bg");

                password.Clear();
                password.SendKeys("englisc");

                loginButton.Click();
                Thread.Sleep(6000);

                var loggedUserName = driver.FindElement(By.XPath("//a[contains(text(),'PIN]"));

                Assert.AreEqual("PIN", loggedUserName.Text);
                var logoutButton = driver.FindElement(By.CssSelector("button.btn"));
                logoutButton.Click();

            }

        }
    }
}




