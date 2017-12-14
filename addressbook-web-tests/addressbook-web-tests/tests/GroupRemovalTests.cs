using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [SetUp]
        public void Init()
        {
            app.Groups.CreateIfNotExist();
        }

        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = GroupData.GettAll();
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GettAll();

            // GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
