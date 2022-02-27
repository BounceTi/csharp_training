using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (!app.Groups.CheckGroupExist())
            {
                GroupData group = new("Name")
                {
                    Header = "Header",
                    Footer = "Footer"
                };

                app.Groups.Create(group);
            }

            GroupData newData = new("NameModified")
            {
                Header = "HeaderModified",
                Footer = "FooterModified"
            };

            app.Groups.Modify(1, newData);
        }
    }
}
