using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class UserHelper : HelperBase
    {
        protected bool acceptNextAlert = true;

        public UserHelper Modify(int v, UserData newData)
        {
            manager.Navigator.GoToHomePage();

            SelectUser();
            InitUserModification();
            AddNewUser(newData);
            SubmitUserModification();
            return this;
        }



        public UserHelper(ApplicationManager manager) : base(manager)
        {
        }

        public UserHelper Create(UserData user)
        {
            manager.Navigator.GoToAddNew();
            AddNewUser(user);
            return this;
        }

        public UserHelper Remove(int v)
        {
            SelectUser();
            RemoveUser();
            return this;
        }

        public UserHelper AddNewUser(UserData user)
        {
            Type(By.Name("firstname"), user.Firstname);
            Type(By.Name("lastname"), user.Lastname);
            return this;
        }

        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
        public UserHelper SelectUser()
        {
            driver.FindElement(By.Id("9")).Click();
            return this;
        }
        public UserHelper RemoveUser()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }
        public UserHelper SubmitUserModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        public UserHelper InitUserModification()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public bool IsUserExist()
        {
            return IsElementPresent(By.Name("entry"));
        }
        public UserHelper CreateIfNotExist()
        {
            manager.Navigator.GoToHomePage();
            if (IsUserExist() == false)
            {
                UserData user = new UserData("Nata", "Smit");
                Create(user);
            }
            return this;
        }

    }
}
