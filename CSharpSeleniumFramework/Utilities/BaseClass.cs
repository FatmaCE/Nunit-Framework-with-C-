using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using System.Threading;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.DevTools.V108.Page;

namespace CSharpSeleniumFramework.Utilities
{
    public class BaseClass

    {

        public ExtentReports extent;
        public ExtentTest test;
        String browserName;
        //report file 
        [OneTimeSetUp]// this will execute once in the beginning of before executing  entire project 
        public void Setup()
        {

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Fatma Celik");

        }


       // public IWebDriver driver;
       public  ThreadLocal <IWebDriver> driver = new ThreadLocal<IWebDriver>(); //trying to keep your driver safe by creating separate instance
        [SetUp]// each and every test

        public void StartBrowser()

        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name); // you can grab the test name dynamically everytime you run the tests
          browserName=  TestContext.Parameters["browserName"]; //  if there is  any pramater from terminal 

            if (browserName == null) // if browser from terminal is null value 
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }

            InitBrowser(browserName);

            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";


        }

        public IWebDriver getDriver()
        {
            return driver.Value;
        }

        public void InitBrowser(string browserName)
        {
            switch(browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;

                case "Edge":
                    
                    driver.Value = new EdgeDriver();
                    break;




            }

        }

        public static jsonreader getDataParser()
        {
            return new jsonreader();

        }

        [TearDown]
        public void AfterTest()
        {

           var status= TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed) 
            {
                test.Fail("Test failed", CaptureScreenshot(driver.Value,fileName));// to see the screenshot 
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);// to see the logs why test got failed 
            }
            else if (status == TestStatus.Passed) 
            
            { 
            
            }
            extent.Flush(); 
            driver.Value.Quit();
        }

        public MediaEntityModelProvider CaptureScreenshot(IWebDriver driver,string screenShotName)
        {
            ITakesScreenshot ts=(ITakesScreenshot)driver;
            var screenshot=ts.GetScreenshot().AsBase64EncodedString;
           return  MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,screenShotName).Build();
        }

    }
}
