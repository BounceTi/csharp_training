using NUnit.Framework;

namespace addressbook_tests_autoit
{
    public class TestBase
    {
        public ApplicationManager app;

        [OneTimeSetUp]
        public void InitApplication()
        {
            app = new ApplicationManager();
        }

        [OneTimeTearDown]
        public void StopApplication()
        {
            app.Stop();
        }
    }
}
