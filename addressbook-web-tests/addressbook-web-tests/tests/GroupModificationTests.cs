using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [SetUp]
        public void Init()
        {
            app.Groups.CreateIfNotExist();
        }

        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("rr");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = GroupData.GettAll();

            GroupData toBeModified = oldGroups[0];
            app.Groups.Modify(toBeModified, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GettAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
