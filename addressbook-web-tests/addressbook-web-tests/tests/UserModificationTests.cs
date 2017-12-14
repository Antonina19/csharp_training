using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserModificationTests : UserTestBase
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

            List<UserData> oldUsers = UserData.GettAll();
            foreach (UserData user in oldUsers)
            {
                System.Console.Out.WriteLine("old " + user.Firstname + " " + user.Lastname);
            }
            UserData toBeModified = oldUsers[0];

            app.Users.Modify(toBeModified, newData);

            Assert.AreEqual(oldUsers.Count, app.Users.GetUserCount());

            List<UserData> newUsers = UserData.GettAll();
            foreach (UserData user in newUsers)
            {
                System.Console.Out.WriteLine("new " + user.Firstname + " " + user.Lastname);
            }
            oldUsers[0] = newData;
            foreach (UserData user in oldUsers)
            {
                System.Console.Out.WriteLine("oldmodified " + user.Firstname + " " + user.Lastname);
            }

            oldUsers.Sort();
            newUsers.Sort();

            Assert.AreEqual(oldUsers, newUsers);

            foreach (UserData user in newUsers)
            {
                if (user.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newData.Firstname, user.Firstname);
                    Assert.AreEqual(newData.Lastname, user.Lastname);
                }
            }
        }
    }
}
