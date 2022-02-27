using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
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
            app.Groups.Remove(1);
        }
    }
}
