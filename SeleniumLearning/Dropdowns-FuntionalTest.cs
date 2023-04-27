using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
   public class Dropdowns_FuntionalTest
    {
        IWebDriver driver;

        [SetUp]

        public void StartBrowser()

        {

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            //implicit wait 5 seconds  can be declared globally
            // driver.Manage().Timeouts().ImplicitWait =TimeSpan.FromSeconds(5);



            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

        }

        [Test]
     public void dropDown()
        {
        IWebElement dropdown=  driver.FindElement(By.CssSelector("select.form-control"));

            SelectElement s = new SelectElement(dropdown);
            //SelectElement class take webelement as an input, has the capability to selecet the options from dropdown

            s.SelectByText("Teacher");

            s.SelectByValue("stud");
            s.SelectByIndex(2);

        }

        [Test]

        public void radioButtons()
        {


          IList <IWebElement> radios = driver.FindElements(By.CssSelector("input[type='radio']"));

            //radios[1].Click(); 

            //if developers add another radio button 

            foreach( IWebElement radioButton in radios) { 
                if ( radioButton.GetAttribute("value").Equals("user"))
                {

                    radioButton.Click();
                }
                    
                    
                    }
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));

            driver.FindElement(By.Id("okayBtn")).Click();

            Boolean result = driver.FindElement(By.Id("usertype")).Selected; // as there is not selected tag in their webpage so the result is false 

           Assert.That(result, Is.True);
            
;

        }


    }
}
