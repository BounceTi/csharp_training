using NUnit.Framework;

namespace mantis_tests
{
    public class AddNewIssueTests : TestBase
    {
        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData()
            {
                Id = "13"
            };

            IssueData issue = new IssueData()
            {
                Summary = "some short text",
                Description = "some short text",
                Category = "General"
            };

            app.API.CreateNewIssue(account, project, issue);
        }
    }
}
