using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests.tests
{
    [TestFixture]
    public class ProjectCreationsTests : AuthTestBase
    {
        [Test]
        public void ProjectCreateonTest()
        {
            ProjectData project = new ProjectData()
            {
                Name = "Progect1",
                Description = ""
            };

            //app.Projects.DeleteIfSuchProjectExist(project);
            app.Projects.DeleteIfSuchProjectExist(account, project);
            
            //List<ProjectData> oldProjects = app.Projects.GetProjectList();
            List<ProjectData> oldProjects = app.Projects.GetProjectList(account);
            app.Projects.Create(project);
            Assert.AreEqual(oldProjects.Count + 1, app.Projects.GetProjectCount());

            //List<ProjectData> newProjects = app.Projects.GetProjectList();
            List<ProjectData> newProjects = app.Projects.GetProjectList(account);
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
