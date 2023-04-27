using NUnit.Framework;

namespace SeleniumLearning
{
    public class Tests
    {

        [SetUp] // pre condition logic clearing history etc
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup method execution"); // if you want to log sth from nunit tests 
        }

        [Test] // core logic 
        public void Test1()
        {
            TestContext.Progress.WriteLine("THis is test 1");
        }

        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("THis is test 2");
        }


        [TearDown] // post request  
        public void CloseBrowser()

        {
            TestContext.Progress.WriteLine(" Tear down method");
        }
    }
}