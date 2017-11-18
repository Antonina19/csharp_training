﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            // подготовка тестовой ситуации prepare
            app.Auth.Logout();
            // действие action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            // проверка verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            // подготовка тестовой ситуации prepare
            app.Auth.Logout();
            // действие action
            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);
            // проверка verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}