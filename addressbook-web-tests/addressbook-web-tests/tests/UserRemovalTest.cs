using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests 
{
    [TestFixture]
    public class UserRemovalTests : TestBase
    {
        [Test]
        public void UserRemovalTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Users.SelectUser();
            app.Users.RemoveUser();
        }
    }
}
