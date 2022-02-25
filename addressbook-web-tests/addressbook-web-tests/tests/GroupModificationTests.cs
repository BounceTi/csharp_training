using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new("NameModified")
            {
                Header = "HeaderModified",
                Footer = "FooterModified"
            };

            app.Groups.Modify(1, newData);
        }
    }
}
