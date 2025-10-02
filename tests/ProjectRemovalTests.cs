using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void TestProjectRemoval()
        {
            ProjectData projectToRemove = new ProjectData("Test Project for Removal");
            List<ProjectData> oldProjects = app.Project.GetProjectList();

            if (oldProjects.Count == 0)
            {
                app.Project.Create(projectToRemove);
                oldProjects = app.Project.GetProjectList();
            }

            app.Project.Remove(projectToRemove);

            List<ProjectData> newProjects = app.Project.GetProjectList();
            Assert.That(newProjects.Count, Is.EqualTo(oldProjects.Count - 1));
            CollectionAssert.DoesNotContain(newProjects, projectToRemove);
        }
    }
}
