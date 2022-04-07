using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];

            if (group == null)
            {
                GroupData g = new("testAddCtoG");
                app.Groups.Create(g);
                group = GroupData.GetAll()[0];
            }

            List<ContactData> oldList = group.GetContacts();

            ContactData contact = ContactData.GetAll().Except(oldList).FirstOrDefault();

            if (contact == null)
            {
                ContactData c = new("testAddCtoG", "testAddCtoG");
                app.Contacts.Create(c);
                contact = ContactData.GetAll().Except(group.GetContacts()).First();
            }

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
