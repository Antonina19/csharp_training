using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
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

            List<UserData> oldUsers = app.Users.GetUserList();

            app.Users.Create(user);

            Assert.AreEqual(oldUsers.Count + 1, app.Users.GetUserCount());

            List<UserData> newUsers = app.Users.GetUserList();
            oldUsers.Add(user);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);
        }

        [Test]
        public void EmptyUserCreationTest()
        {
            UserData user = new UserData("", "");
            List<UserData> oldUsers = app.Users.GetUserList();
            app.Users.Create(user);

            Assert.AreEqual(oldUsers.Count + 1, app.Users.GetUserCount());

            List<UserData> newUsers = app.Users.GetUserList();
            oldUsers.Add(user);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);
        }
    }
}

