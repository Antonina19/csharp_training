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
            UserData user = new UserData("test1", "test1")
            {
                Address = "г.Москва, ул. Ленина, д.56",
                HomePhone = "85664-5666",
                WorkPhone = "666-558-6",
                MobilePhone = "479-5556-885",
                Email = "sa@mail.ru",
                Email2 = "gvb@bk.ru",
                Email3 = "fh@ya.ru"
            };

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

