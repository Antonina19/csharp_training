using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class UserInformationTests : AuthTestBase
    {
        [Test]
        public void TestUserInformation()
        {
            UserData fromTable = app.Users.GetUserInformationFromTable(9);
            UserData fromForm = app.Users.GetUserInformationFromEditForm(9);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestUserInformationDetail()
        {
            UserData fromDetailForm = app.Users.GetUserInformationFromDetailForm(9);
            UserData fromForm = app.Users.GetUserInformationFromEditForm(9);

            Assert.AreEqual(fromForm.UserInfo, fromDetailForm.UserInfo);
        }
    }
}
