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
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void CreateIfNoProjectsPresent()
        {
            manager.Navigator.GoToProgectTab();
            if (!IsElementPresent(By.XPath("//table[1]/tbody/tr")))
            {
                ProjectData project = new ProjectData()
                {
                    Name = "Project1",
                    Description = ""
                };

                Create(project);
            }
        }

        public void Create(ProjectData project)
        {
            manager.Navigator.GoToProgectTab();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("div.widget-toolbox input.btn-primary")).Click();
            driver.FindElement(By.LinkText("Продолжить")).Click();
        }

        private void FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            Type(By.Id("project-description"), project.Description);
        }

        private void InitProjectCreation()
        {
            driver.FindElements(By.CssSelector("div.widget-body"))[0]
            .FindElements(By.CssSelector("input.btn-primary"))[0].Click();
        }

        public void Remove(ProjectData project)
        {
            manager.Navigator.GoToProgectTab();
            OpenEditPage(project.Name);
            RemoveProject();
            SubmitProjectRemove();
        }

        private void SubmitProjectRemove()
        {
            driver.FindElement(By.CssSelector("div.alert-warning.btn")).Click();
        }

        private void RemoveProject()
        {
            driver.FindElement(By.CssSelector("form#project-delete-form input.btn")).Click();
        }

        private void OpenEditPage(string name)
        {
            driver.FindElement(By.LinkText(name)).Click();
        }

        public void DeleteIfSuchProjectExist(ProjectData project)
        {
            manager.Navigator.GoToProgectTab();
            if (IsElementPresent(By.XPath("//table[1]/tbody/tr/td[1]/a[.='"+project.Name + "']")))
            {
                Remove(project);
            }
        }


        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> list = new List<ProjectData>();
            manager.Navigator.GoToProgectTab();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector(".table"))[0]
                .FindElements(By.CssSelector("tbody>tr"));
            foreach (IWebElement element in elements)
            {
                list.Add(new ProjectData()
                {
                    Name = element.FindElements(By.CssSelector("td"))[0].Text,
                    Description = element.FindElements(By.CssSelector("td"))[4].Text
                });
            }
            return list;
        }
        public int GetProjectCount()
        {
            manager.Navigator.GoToProgectTab();
            return driver.FindElements(By.CssSelector(".table"))[0]
                .FindElements(By.CssSelector("tbody>tr"))
                .Count();
        }
    }
}
