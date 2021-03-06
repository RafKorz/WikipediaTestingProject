using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WikipediaTestingProject
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Users\User\source\repos\WikipediaTestingProject\WikipediaTestingProject\Resources\");
            driver.Manage().Window.Position = new System.Drawing.Point(8, 30);
            driver.Manage().Window.Size = new System.Drawing.Size(700, 700);

            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(30);
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            IWebElement searchField = driver.FindElement(By.Id("searchInput"));
            string searchEntry = "Częstochowa";
            searchField.SendKeys(searchEntry);
            searchField.Submit();

            //string title = "Częstochowa – Wikipedia, wolna encyklopedia";
            driver.FindElement(By.CssSelector("#mw-content-text > div.mw-parser-output > p:nth-child(3) > a:nth-child(5)")).Click();

            string entryURL = "https://pl.wikipedia.org/wiki/Powiat_cz%C4%99stochowski";
            Assert.AreEqual(entryURL, driver.Url, "URL id not correct.");

            //Assert.AreEqual(driver.Title, "Częstochowa – Wikipedia, wolna encyklopedia");
        }

        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}