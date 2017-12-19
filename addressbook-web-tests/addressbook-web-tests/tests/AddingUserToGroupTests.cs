using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingUserToGroupTests : AuthTestBase
    {
        [SetUp]
        public void SetupAppGroupRemovalTest()
        {
            app.Groups.CreateIfNotExist();
            app.Users.CreateIfNotExist();
        }

        [Test]
        public void TestAddingUserToGroup()
        {
            GroupData group = GroupData.GettAll()[0];
            app.Users.CheckAllUsersExist(group);
            List<UserData> oldList = group.GetUsers();
            UserData user =  UserData.GettAll().Except(oldList).First();

            app.Users.AddUserToGroup(user, group);

            List<UserData> newList = group.GetUsers();
            oldList.Add(user);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void TestRemovigUserFromGroup()
        {
            GroupData group = GroupData.GettAll()[0];
            app.Users.CheckNoUsersExist(group);
            List<UserData> oldList = group.GetUsers();
            UserData user = UserData.GettAll().Except(oldList).First();

            app.Users.RemoveUserFromGroup(user, group);

            List<UserData> newList = group.GetUsers();
            oldList.Add(user);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
