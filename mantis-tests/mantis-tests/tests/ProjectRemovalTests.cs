using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void TestProjectRemoval()
        {
            List<ProjectData> oldProjects = app.API.GetAllProjects(app.AdminAccount);

            if (oldProjects.Count == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = GenerateRandomString(10),
                    Description = "This project was created by autotests",
                };
                app.API.AddNewProject(app.AdminAccount, project);
                oldProjects = app.API.GetAllProjects(app.AdminAccount);
            }

            ProjectData toBeRemoved = oldProjects[0];

            app.PMHelper.Remove(toBeRemoved);

            List<ProjectData> newProjects = app.API.GetAllProjects(app.AdminAccount);

            oldProjects.RemoveAt(0);

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
