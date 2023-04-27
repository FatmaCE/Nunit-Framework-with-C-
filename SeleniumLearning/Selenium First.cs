using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class Selenium_First
    {

        IWebDriver driver;
        [SetUp]

        public void StartBrowser()
        {

            //interface declare the methods but do not have the implementations 
            //methods- getUrl , click
            //selenium can not directly communicate with the browser
            //chromedriver.exe on chrome browser to invoke browser 
            //WebDriverManager is checking your browser , approppriate browser version and putting in you project file 

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver= new ChromeDriver();
            //driver = new FirefoxDriver(); // to invoke firefox driver we need geckodriver
            //driver = new EdgeDriver();

            
             

        }
        [Test]
        public void goToUrl()
        {
            driver.Manage().Window.Maximize();

            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            
             
        }

        [TearDown]
        public  void afterTest()
        {
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
            driver.Close(); //if there are 2 windows  open by automation, it will only close which got open by the chromedriver
                            // driver.Quit();
                            //string pageSource = driver.PageSource; TO GET THE ALL THE HTML CODE OF YOUR PAGE


        }


    }
}
