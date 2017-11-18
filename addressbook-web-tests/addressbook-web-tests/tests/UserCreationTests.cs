using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class UserCreationTests : AuthTestBase
    {
        [Test]
        public void UserCreationTest()
        {
            UserData user = new UserData("test1", "test1");
            app.Users.Create(user);
            // ERROR: Caught exception [Error: Dom locators are not implemented yet!]
            //driver.FindElement(By.LinkText("home page")).Click();
            // driver.FindElement(By.LinkText("Logout")).Click();
        }

        [Test]
        public void EmptyUserCreationTest()
        {
            UserData user = new UserData("", "");
            app.Users.Create(user);
            // ERROR: Caught exception [Error: Dom locators are not implemented yet!]
            //driver.FindElement(By.LinkText("home page")).Click();
            // driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}

