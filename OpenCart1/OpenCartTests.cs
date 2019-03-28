using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium.Interactions;


namespace OpenCartTests

{
    [TestClass]
    public class OpenCartTest

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
        }

        [TestCategory("HomePageTests")]
        [TestMethod]
        public void Test02NavigateToLogIn()

        {
            driver.Navigate().GoToUrl(@"https://www.opencart.com");

            Thread.Sleep(1000);

            
            var loginButton = driver.FindElement(By.XPath("//*[@id='navbar-collapse-header']/div/a[1]"));
            loginButton.Click();

            var email = driver.FindElement(By.Id("input-email"));
            email.Clear();
            email.SendKeys("mad17@abv.bg");
            Thread.Sleep(1000);

            var password = driver.FindElement(By.Id("input-password"));
            password.Clear();
            Thread.Sleep(1000);
            password.SendKeys("englisc");

            var loginAccountButton = driver.FindElement(By.CssSelector("button.btn"));
            loginAccountButton.Click();

            var pin = driver.FindElement(By.Id("input-pin"));
            pin.Clear();
            pin.SendKeys("1717");

            var continueButton = driver.FindElement(By.CssSelector(".btn.btn-primary.btn-lg"));
            continueButton.Click();
            Thread.Sleep(1000);

            var pageHeading = driver.FindElement(By.CssSelector("h1"));

            Assert.AreEqual("Account", pageHeading.Text);
        }

        [TestCategory("HomePageTests")]
        [TestMethod]
        public void Test02NavigateToDemo()
        {
            driver.Navigate().GoToUrl(@"https://demo.opencart.com/admin/");

            Thread.Sleep(1000);
           
            var userName = driver.FindElement(By.Id("input-username"));
            userName.Clear();
            userName.SendKeys("mad17@abv.bg");

            var password = driver.FindElement(By.Id("input-password"));
            password.Clear();
            password.SendKeys("englisc");

            var loginButton = driver.FindElement(By.XPath("//*[@id='content']/div/div/div/div/div[2]/form/div[3]/button"));
            loginButton.Click();

            Thread.Sleep(2000);

            var loggedUser = driver.FindElement(By.XPath("//*[@id='header']/div/ul/li[1]/a"));

            Assert.AreEqual("demo demo", loggedUser.Text);
            
            //var logoutButton = driver.FindElement(By.CssSelector("button.btn"));

            //logoutButton.Click();
        }

        [TestCategory("HomePageTests")]
        [TestMethod] 
        public void WriteReview()

        {
            driver.Navigate().GoToUrl(@"https://demo.opencart.com/");

            Thread.Sleep(1000);

            var product = driver.FindElement(By.XPath("//*[@id='content']/div[2]/div[2]/div/div[2]/h4/a"));
            product.Click();

            var writeReviewLink = driver.FindElement(By.XPath("//*[@id='content']/div[1]/div[2]/div[3]/p/a[2]"));
            writeReviewLink.Click();

            var yourName = driver.FindElement(By.Id("input-name"));
            yourName.Clear();
            yourName.SendKeys("Madlena");

            var yourReview = driver.FindElement(By.Id("input-review"));
            yourReview.Clear();
            yourReview.SendKeys("Very nice product! I like it!");

            var ratingButtons = driver.FindElements(By.XPath("//input[@name='rating']"));
            var goodRatingRadioButton = ratingButtons[4];
            goodRatingRadioButton.Click();

            var continueButton = driver.FindElement(By.Id("button-review"));
            continueButton.Click();

            Thread.Sleep(2000);

            var submittedReviewMessage = driver.FindElement(By.CssSelector(".alert-success"));

            Assert.AreEqual("Thank you for your review. It has been submitted to the webmaster for approval.", submittedReviewMessage.Text);
        }
    }
}
