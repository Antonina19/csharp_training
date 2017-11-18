using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests 
{
    [TestFixture]
    public class UserRemovalTests : AuthTestBase
    {
        [Test]
        public void UserRemovalTest()
        {
            app.Users.Remove(9);
        }
    }
}
