using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests 
{
    [TestFixture]
    public class UserRemovalTests : UserTestBase
    {
        [SetUp]
        public void Init()
        {
            app.Users.CreateIfNotExist();
        }

        [Test]
        public void UserRemovalTest()
        {
            List<UserData> oldUsers = UserData.GettAll();
            UserData toBeRemoved = oldUsers[0];

            app.Users.Remove(toBeRemoved);

            Assert.AreEqual(oldUsers.Count - 1, app.Users.GetUserCount());
            List<UserData> newUsers = UserData.GettAll();

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
