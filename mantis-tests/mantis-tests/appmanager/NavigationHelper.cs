using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager) : base(manager) { }

        public void OpenManagmentMenu()
        {
            if (!IsElementPresent(By.XPath("//div[@id='sidebar']/ul/li[@class='active']/a" +
                "/span[contains(text(),'управление']")))
            {
                driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[@class='active']/a" +
                "/span[contains(text(),'управление']")).Click();
            }
        }

        public void GoToProgectTab()
        {
            OpenManagmentMenu();
            if (!IsElementPresent(By.XPath("//div[@id='main-container']/div[2]/div[2]/div" + 
                "/ul/li[@class='active']/a[contains(text(),'Управление проектами']")))
            {
                driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div" +
                "/ul/li[@class='active']/a[contains(text(),'Управление проектами']")).Click();
            }
        }

        public void OpenMainPage()
        {
            if(driver.Url != "http://localhost/mantisbt-2.9.0/login_page.php")
            {
                manager.Driver.Url = "http://localhost/mantisbt-2.9.0/login_page.php";
            }
        }
    }
}
