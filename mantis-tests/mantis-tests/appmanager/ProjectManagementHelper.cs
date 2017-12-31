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

        public void CreateIfNoProjectsPresent(ProjectData project)
        {
            manager.Navigator.GoToProjectTab();
            if (!IsElementPresent(By.XPath("//table[1]/tbody/tr")))
            {
                Create(project);
            }
        }

        public void CreateIfNoProjectsPresent(AccountData account, ProjectData project)
        {
            if (GetProjectList(account).Count == 0)
            {
                Create(account, project);
            }
        }

        public List<ProjectData> GetProjectList(AccountData account)
        {
            List<ProjectData> list = new List<ProjectData>();

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach (Mantis.ProjectData project in projects)
            {
                list.Add(new ProjectData()
                {
                    Name = project.name,
                    Description = project.description

                });
            }

            return list;

        }

        private void Create(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;
            client.mc_project_add(account.Name, account.Password, project);
        }

        public void Create(ProjectData project)
        {
            manager.Navigator.GoToProjectTab();
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
            manager.Navigator.GoToProjectTab();
            OpenEditPage(project.Name);
            RemoveProject();
            SubmitProjectRemove();
        }

        public void Remove(AccountData account, String projectId)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            client.mc_project_delete(account.Name, account.Password, projectId);
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
            manager.Navigator.GoToProjectTab();
            if (IsElementPresent(By.XPath("//table[1]/tbody/tr/td[1]/a[.='"+project.Name + "']")))
            {
                Remove(project);
            }
        }

        public void DeleteIfSuchProjectExist(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            string projectId = client.mc_project_get_id_from_name(account.Name, account.Password, project.Name);

            if (projectId !=null && projectId != "0")
            {
                Remove(account, projectId);
            }
        }

        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> list = new List<ProjectData>();
            manager.Navigator.GoToProjectTab();
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
            manager.Navigator.GoToProjectTab();
            return driver.FindElements(By.CssSelector(".table"))[0]
                .FindElements(By.CssSelector("tbody>tr"))
                .Count();
        }
    }
}
