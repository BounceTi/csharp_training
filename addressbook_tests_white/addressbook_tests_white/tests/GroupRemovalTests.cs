using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            if (!app.Groups.CheckGroupExist())
            {
                GroupData group = new GroupData()
                {
                    Name = "Name"
                };

                app.Groups.Add(group);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupList().Count());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
