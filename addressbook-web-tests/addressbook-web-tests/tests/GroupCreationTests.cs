using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new("Name")
            {
                Header = "Header",
                Footer = "Footer"
            };

            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new("")
            {
                Header = "",
                Footer = ""
            };

            app.Groups.Create(group);
        }
    }
}

