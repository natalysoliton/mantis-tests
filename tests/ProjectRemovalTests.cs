using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void TestProjectRemoval()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "password"
            };
            ProjectData projectToRemove = new ProjectData("Test Project for Removal");
            List<ProjectData> oldProjects = app.Project.GetProjectList(account);

            if (oldProjects.Count == 0)
            {

                Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
                Mantis.ProjectData projectData = new Mantis.ProjectData();
                projectData.name = "projectToRemove";

                client.mc_project_add("administrator", "password", projectData);
                oldProjects = app.Project.GetProjectList(account);
            }

            app.Project.Remove(projectToRemove);
            List<ProjectData> newProjects = app.Project.GetProjectList(account);

            Assert.That(newProjects.Count, Is.EqualTo(oldProjects.Count - 1));

            CollectionAssert.DoesNotContain(newProjects, projectToRemove);
        }
    }
}
