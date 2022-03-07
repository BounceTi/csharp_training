using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    internal class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {

            ContactData newData = new("NewIvan", "NewIvanov")
            {
                MiddleName = "NewIvanovich",
                TelephoneMobile = "89137654321"
            };

            if (!app.Contacts.CheckContactExist())
            {
                ContactData contact = new("Ivan", "Ivanov")
                {
                    MiddleName = "Ivanovich",
                    TelephoneMobile = "89131234567"
                };

                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(0, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                    Assert.AreEqual(newData.LastName, contact.LastName);
                }
            }

        }
    }
}
