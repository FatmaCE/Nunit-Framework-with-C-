using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class Locators
    {
        //xpath, css,  id, clasname, name, tagname, linktext 



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

        public void LocatorsIdendification()
        {
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("Fatma");
            driver.FindElement(By.Name("password")).SendKeys("1234546");
            //css selector 
            // tagname[attribute='value']

            //driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();

            // &xpath
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            // Thread.Sleep(3000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue((By.XPath("//input[@value='Sign In']")), "Sign In"));

           String errorMessage=driver.FindElement(By.ClassName("alert-danger")).Text;

            TestContext.Progress.WriteLine(errorMessage);

           IWebElement link= driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String hrefAttr = link.GetAttribute("href");
            //validate url of the link text 
           String expectedUrl= "https://rahulshettyacademy.com/documents-request";
            Assert.AreEqual(expectedUrl, hrefAttr);

           

        }
    }

}
