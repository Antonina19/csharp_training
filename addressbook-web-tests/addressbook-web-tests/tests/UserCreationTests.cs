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
        public static IEnumerable<UserData> RandomUserDataProvider()
        {
            List<UserData> users = new List<UserData>();
            for (int i = 0; i < 5; i++)
            {
                users.Add(new UserData(GenerateRandomString(30), GenerateRandomString(30))
                {
                   Middlename = GenerateRandomString(100),
                   Nickname = GenerateRandomString(100),
                   Company = GenerateRandomString(100),
                   Title  = GenerateRandomString(100),
                   Address = GenerateRandomString(100),
                   HomePhone = GenerateRandomString(100),
                   MobilePhone = GenerateRandomString(100),
                   WorkPhone = GenerateRandomString(100),
                   Fax = GenerateRandomString(100),
                   Email = GenerateRandomString(100),
                   Email2 = GenerateRandomString(100),
                   Email3 = GenerateRandomString(100),
                   Homepage = GenerateRandomString(100),
                   Address2 = GenerateRandomString(100),
                   Phone2 = GenerateRandomString(100),
                   Notes = GenerateRandomString(100)
                });
            }

            return users;

        }

        [Test, TestCaseSource("RandomUserDataProvider")]
        public void UserCreationTest(UserData user)
        {
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

