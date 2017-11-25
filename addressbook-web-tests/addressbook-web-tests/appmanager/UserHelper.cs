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
            userCache = null;
            return this;
        }
        public UserHelper RemoveUser()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            userCache = null;
            return this;
        }
        public UserHelper SubmitUserModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            userCache = null;
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

        private List<UserData> userCache = null;

        public List<UserData> GetUserList()
        {
            if (userCache == null)
            {
                userCache = new List<UserData>();
                manager.Navigator.GoToHomePage();

                List<UserData> users = new List<UserData>();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> body = element.FindElements(By.TagName("td"));
                    string id = body[0].FindElement(By.Name("selected[]")).GetAttribute("value");
                    string lastName = body[1].Text;
                    string firstName = body[2].Text;

                    userCache.Add(new UserData(firstName, lastName)
                    {
                        Id = id
                    });
                }
            }
            return new List<UserData>(userCache);
        }

        public int GetUserCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }
    }
}
