using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserModificationTests : TestBase
    {
        [Test]
        public void UserModificationTest()
        {
            UserData newData = new UserData("ddd", "ggg");
            app.Users.Modify(9, newData);

        }
    }
}
