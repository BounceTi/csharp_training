using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewProject(ProjectData project)
        {
            manager.ManagementMenu.OpenProjectManagementPage();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
        }

        public void FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            SelectElement select = new SelectElement(driver.FindElement(By.Id("project-status")));
            select.SelectByValue(((int)project.Status).ToString());
            driver.FindElement(By.ClassName("lbl")).Click();
            Type(By.Id("project-description"), project.Description);
        }

        internal void Remove(ProjectData toBeRemoved)
        {
            manager.ManagementMenu.OpenProjectManagementPage();
            SelectProject(toBeRemoved);
            InitProjectRemoval();
            SubmitProjectRemoval();
        }

        private void SelectProject(ProjectData toBeRemoved)
        {
            driver.FindElement(By.XPath("(//a[text()='" + toBeRemoved.Name + "'])[2]")).Click();
        }

        private void InitProjectRemoval()
        {
            IWebElement deleteForm = driver.FindElement(By.Id("project-delete-form"));
            deleteForm.FindElement(By.ClassName("btn")).Click();
        }

        private void SubmitProjectRemoval()
        {
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public void InitProjectCreation()
        {
            driver.FindElement(By.XPath("//div/div/div[2]/div[2]//button")).Click();
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public bool CheckSuccessAlert()
        {
            if (driver.FindElement(By.ClassName("alert-success")).Displayed)
            {
                return true;
            }
            return false;
        }

        public List<ProjectData> GetAllProjects()
        {
            manager.ManagementMenu.OpenProjectManagementPage();

            List<ProjectData> projectsList = new List<ProjectData>();

            ICollection<IWebElement> projects = driver.FindElements(By.XPath("//div[2]/table/tbody/tr"));

            foreach (IWebElement project in projects)
            {
                var name = project.FindElement(By.XPath("./td[1]")).Text;
                var description = project.FindElement(By.XPath("./td[5]")).Text;

                projectsList.Add(new ProjectData
                {
                    Name = name,
                    Description = description
                });
            }

            return projectsList;
        }
    }
}
