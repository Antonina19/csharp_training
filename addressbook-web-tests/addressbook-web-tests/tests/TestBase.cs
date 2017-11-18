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
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }   
    }
}
