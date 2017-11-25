using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests 
{
    [TestFixture]
    public class UserRemovalTests : AuthTestBase
    {
        [SetUp]
        public void Init()
        {
            app.Users.CreateIfNotExist();
        }

        [Test]
        public void UserRemovalTest()
        {
            List<UserData> oldUsers = app.Users.GetUserList();
            app.Users.Remove(0);

            List<UserData> newUsers = app.Users.GetUserList();
            oldUsers.RemoveAt(0);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);
        }
    }
}
