using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class UserCreationTests : TestBase
    {
 
        [Test]
        public void UserCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddNew();
            UserData user = new UserData("test1", "test1");
            AddNewUser(user);
            // ERROR: Caught exception [Error: Dom locators are not implemented yet!]
            //driver.FindElement(By.LinkText("home page")).Click();
            // driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}

