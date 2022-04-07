using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTest : AuthTestBase
    {
        [Test]
        public void TestRemoveContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            if (group == null)
            {
                GroupData g = new("test");
                app.Groups.Create(g);
                group = GroupData.GetAll()[0];
            }

            List<ContactData> oldList = group.GetContacts();
            if (oldList == null)
            {
                ContactData c = new("testRemoveCG", "testRemoveCG");
                app.Contacts.Create(c);
                oldList = group.GetContacts();
            }

            ContactData contact = ContactData.GetAll().First();

            if (!app.Groups.CheckContactExistInGroup(contact, group))
            {
                app.Contacts.AddContactToGroup(contact, group);
            }

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
        
    }
}
