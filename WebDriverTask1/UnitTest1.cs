using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace WebDriverTask1
{
    public class PasterbinTest
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
        }

        [Test]
        public void CreateNewPaste()
        {
            driver.Url = "https://pastebin.com";

            IWebElement textField = driver.FindElement(By.Id("postform-text"));
            textField.SendKeys("Hello from WebDriver");

            IWebElement expirationTime = driver.FindElement(By.Id("select2-postform-expiration-container"));
            expirationTime.Click();
            driver.FindElement(By.XPath("//li[contains(text(),'10 Minutes')]")).Click();

            IWebElement titleField = driver.FindElement(By.Id("postform-name"));
            textField.SendKeys("helloweb");

            IWebElement createPasteButton = driver.FindElement(By.XPath("//button[contains(text(),'Create New Paste')]"));
            createPasteButton.Click();
        }

        [TearDown]
        public void CloseBrowser()
        {
                driver.Quit();
                driver.Dispose();
        }
    }
}