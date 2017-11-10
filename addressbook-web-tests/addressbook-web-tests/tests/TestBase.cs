using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests 
{
    public class TestBase
    {
        protected ApplicationManager app;
        //protected bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            //driver = new ChromeDriver();
            //baseURL = "http://localhost/";
            //verificationErrors = new StringBuilder();
            app = new ApplicationManager();

        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }     
    }
}
