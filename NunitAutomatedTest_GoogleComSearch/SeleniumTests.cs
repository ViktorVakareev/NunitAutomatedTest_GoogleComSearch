using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace NunitAutomatedTest_GoogleComSearch
{
    public class SeleniumTests
    {
        IWebDriver driver;
       
        [SetUp]
        public void Setup()
        {
            
            driver = new ChromeDriver();
        }

        [Test]
        public void GoogleSearchClickFirstResultAndCheckPageTitle()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://google.com";
            // click Agree Button
            var button = driver.FindElement(By.CssSelector("#zV9nZe > div"));
            button.Click();
            // Click Search field and type "selenium", hit Enter
            driver.FindElement(By
                .XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input"))
                .SendKeys("selenium");
            driver.FindElement(By
               .XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input"))
               .SendKeys(Keys.Enter);

            // select first result from top-down and click it
            driver.FindElement(By.CssSelector("h3.LC20lb.DKV0Md")).Click();

            var url = driver.Url;
            Assert.AreEqual("https://www.selenium.dev/", url);
            Assert.AreEqual("SeleniumHQ Browser Automation", driver.Title);
        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}