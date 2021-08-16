using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WikipediaTestingProject.DriverMetods
{
    class Navi 
    {

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Users\User\source\repos\WikipediaTestingProject\WikipediaTestingProject\Resources\");
            driver.Manage().Window.Position = new System.Drawing.Point(8, 30);
            driver.Manage().Window.Size = new System.Drawing.Size(700, 700);

            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(20);
        }
        
        [Test]
        public void GoToPageTest()
        {
            Uri wikipediaURL = new Uri("https://www.wikipedia.org");
            driver.Navigate().GoToUrl(wikipediaURL);
            string expectedURL = "https://www.wikipedia.org/";
            Assert.AreEqual(expectedURL, driver.Url, "URL not correct.");
        }
        
        [Test]
        public void BackTest()
        {
            string wikipediaURL = "https://www.wikipedia.org";
            string knpURL = "https://knp.org.pl";
            driver.Navigate().GoToUrl(wikipediaURL);
            driver.Navigate().GoToUrl(knpURL);
            driver.Navigate().Back();
            string expectedURL = "https://www.wikipedia.org/";
            Assert.AreEqual(expectedURL, driver.Url, "URL not correct.");
        }
        
        [Test]
        public void ForwardTest()
        {
            string wikipediaURL = "https://www.wikipedia.org";
            string knpURL = "https://knp.org.pl";
            driver.Navigate().GoToUrl(wikipediaURL);
            driver.Navigate().GoToUrl(knpURL);
            driver.Navigate().Back();
            driver.Navigate().Forward();
            string expectedURL = "https://knp.org.pl/";
            Assert.AreEqual(expectedURL, driver.Url, "URL not correct.");
        }
        
        [Test]
        public void RefreshTest()
        {
            string seleniumEasyURL = "https://www.seleniumeasy.com/test/";
            driver.Navigate().GoToUrl(seleniumEasyURL);
            driver.Navigate().Refresh();
        }

        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}