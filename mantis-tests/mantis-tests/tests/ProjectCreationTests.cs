using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void TestProjectCreation()
        {
            List<ProjectData> oldProjects = app.PMHelper.GetAllProjects();

            ProjectData project = new ProjectData()
            {
                Name = GenerateRandomString(10),
                Description = "This project was created by autotests",
                Status = ProjectData.ProjectStatus.Released
            };

            foreach (ProjectData p in oldProjects)
            {
                if (p.Name == project.Name)
                {
                    project.Name = GenerateRandomString(10);
                } 
            }

            app.PMHelper.CreateNewProject(project);

            Assert.IsTrue(app.PMHelper.CheckSuccessAlert());

            List<ProjectData> newProjects = app.PMHelper.GetAllProjects();

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
