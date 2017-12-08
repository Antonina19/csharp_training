using System;
using System.IO;
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

        public static IEnumerable<UserData> UserDataFromFile()
        {
            List<UserData> users = new List<UserData>();
            string[] lines = File.ReadAllLines(@"users.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                users.Add(new UserData(parts[0], parts[1])
                {
                    Middlename = parts[2],
                    Nickname = parts[3],
                    Company = parts[4],
                    Title = parts[5],
                    Address = parts[6],
                    HomePhone = parts[7],
                    MobilePhone = parts[8],
                    WorkPhone = parts[9],
                    Fax = parts[10],
                    Email = parts[11],
                    Email2 = parts[12],
                    Email3 = parts[13],
                    Homepage = parts[14],
                    Address2 = parts[15],
                    Phone2 = parts[16],
                    Notes = parts[17]
                });
            }
            return users;
        }

        [Test, TestCaseSource("RandomUserDataProvider")] //UserDataFromFile
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

