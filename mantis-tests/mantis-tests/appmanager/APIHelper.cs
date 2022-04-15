using mantis_tests.Mantis;
using System.Collections.Generic;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            MantisConnectPortTypeClient client = GetClient();
            Mantis.IssueData issue = new Mantis.IssueData
            {
                summary = issueData.Summary,
                description = issueData.Description,
                category = issueData.Category,
                project = new ObjectRef
                {
                    id = project.Id,
                }
            };
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetAllProjects(AccountData account)
        {
            List<ProjectData> projectsData = new List<ProjectData>();
            MantisConnectPortTypeClient client = GetClient();

            var projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach (var project in projects)
            {
                projectsData.Add(new ProjectData()
                {
                    Name = project.name,
                    Description = project.description,
                });
            }

            return projectsData;
        }

        public void AddNewProject(AccountData account, ProjectData project)
        {
            MantisConnectPortTypeClient client = GetClient();
            Mantis.ProjectData mantisProject = new Mantis.ProjectData()
            {
                name = project.Name,
                description = project.Description,
            };
            client.mc_project_add(account.Name, account.Password, mantisProject);
        }

        public MantisConnectPortTypeClient GetClient()
        {
            return new MantisConnectPortTypeClient();
        }
    }
}
