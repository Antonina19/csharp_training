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

            Assert.AreEqual(oldUsers.Count - 1, app.Users.GetUserCount());

            List<UserData> newUsers = app.Users.GetUserList();

            UserData toBeRemoved = oldUsers[0];
            oldUsers.RemoveAt(0);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);

            foreach (UserData user in newUsers)
            {
                Assert.AreNotEqual(user.Id, toBeRemoved.Id);
            }
        }
    }
}
