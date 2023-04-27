using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.pageObjects
{
   public class ConfirmationPage
    {
        private IWebDriver driver;

        public ConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        


        /*driver.FindElement(By.Id("country")).SendKeys("ind");
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click();

        driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
        driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
        String confirText = driver.FindElement(By.CssSelector(".alert-success")).Text;

        StringAssert.Contains("Success", confirText);
*/
        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement country;

        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement india;

        [FindsBy(How = How.CssSelector, Using = "label[for*='checkbox2")]
        private IWebElement checkBox2;

        [FindsBy(How = How.CssSelector, Using = "[value='Purchase']")]
        private IWebElement purchase;

        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
        private IWebElement Alert;


        public void selectCountry(string countryName)
        {
            country.SendKeys(countryName);
           WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
           wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            
            india.Click();

        }

        public void submit()
        {
            
            checkBox2.Click();
            purchase.Click();
        }

        public bool IsAlertVisible()

        {
            String confirText =Alert.Text;
            StringAssert.Contains("Success", confirText);

            return true;
        }

    }
}
