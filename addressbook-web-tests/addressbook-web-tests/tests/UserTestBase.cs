using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class UserTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareUsersUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<UserData> fromUI = app.Users.GetUserList();
                List<UserData> fromDB = UserData.GettAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }

        }
    }
}
