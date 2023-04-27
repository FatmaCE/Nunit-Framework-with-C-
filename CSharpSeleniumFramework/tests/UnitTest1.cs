using System;
using System.Collections.Generic;
using System.Linq;
using CSharpSeleniumFramework.pageObjects;
using CSharpSeleniumFramework.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning


{
    [Parallelizable(ParallelScope.Self)]// to run one class pararlelly with another class
    //[Parallelizable(ParallelScope.Children)]// TO RUN ALL  TEST METHODS IN CLASS PARALELLY
    public class E2ETest:BaseClass
    {

       

        
        [Test, TestCaseSource("AddTestDataConfig"),Category("Regression")]
        // 2 tests will run now - Paramaterazing with Nunit test case annotation
        //[TestCase("rahulshettyacademy", "learning")] // will passs with valid credentials 
        //[TestCase("rahulshett", "learning")] // will not pass 


        // run all data sets in parallel
        //run all test methods in one class parallel
        //run all test files in project parallel

        [Parallelizable(ParallelScope.All)]//TO RUN ALL TEST DATA PARALLELLY
        public void EndToEndFlow(String userName, String password, String[] expectedProducts)

        {

           // String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];
            LoginPage loginPage = new LoginPage(getDriver());
            ProductsPage productPage = loginPage.validLogin(userName,password);
            productPage.waitForPageDisplay();

            IList<IWebElement> products = productPage.getCards();

            foreach (IWebElement product in products)
            {

                if (expectedProducts.Contains(product.FindElement(productPage.getCardTitle()).Text))

                {
                    product.FindElement(productPage.addToCartButton()).Click();
                }

            }
            CheckoutPage checkoutPage = productPage.checkout();

            IList<IWebElement> checkoutCards = checkoutPage.getCards();

            for (int i = 0; i < checkoutCards.Count; i++)

            {
                actualProducts[i] = checkoutCards[i].Text;



            }
            Assert.AreEqual(expectedProducts, actualProducts);
            ConfirmationPage confirmationPage = checkoutPage.checkOut();



            confirmationPage.selectCountry("ind");

            confirmationPage.submit();

            confirmationPage.IsAlertVisible();


        }

        [Test,Category("Smoke")]

        public void LocatorsIdendification()
        {
            driver.Value.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.Value.FindElement(By.Id("username")).Clear();
            driver.Value.FindElement(By.Id("username")).SendKeys("Fatma");
            driver.Value.FindElement(By.Name("password")).SendKeys("1234546");
            //css selector 
            // tagname[attribute='value']

            //driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();

            // &xpath
            driver.Value.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            driver.Value.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            // Thread.Sleep(3000);

            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue((By.XPath("//input[@value='Sign In']")), "Sign In"));

            String errorMessage = driver.Value.FindElement(By.ClassName("alert-danger")).Text;

            TestContext.Progress.WriteLine(errorMessage);

          



        }






        public static IEnumerable<TestCaseData> AddTestDataConfig()// iterates over the different data sets 
        {

            yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("username_wrong"), getDataParser().extractData("password_wrong"), getDataParser().extractDataArray("products"));
        }



    }

}

