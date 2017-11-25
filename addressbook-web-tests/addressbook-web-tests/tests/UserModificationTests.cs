using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserModificationTests : AuthTestBase
    {
        [SetUp]
        public void Init()
        {
            app.Users.CreateIfNotExist();
        }

        [Test]
        public void UserModificationTest()
        {
            UserData newData = new UserData("ddаа", "ggg");

            List<UserData> oldUsers = app.Users.GetUserList();

            app.Users.Modify(9, newData);
            List<UserData> newUsers = app.Users.GetUserList();
            oldUsers[0].Firstname = "df";
            oldUsers[0].Lastname = "df";
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);

        }
    }
}
