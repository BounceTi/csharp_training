using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    internal class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {

            ContactData newData = new("NewIvan", "NewIvanov")
            {
                MiddleName = "NewIvanovich",
                MobilePhone = "89137654321"
            };

            if (!app.Contacts.CheckContactExist())
            {
                ContactData contact = new("Ivan", "Ivanov")
                {
                    MiddleName = "Ivanovich",
                    MobilePhone = "89131234567"
                };

                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModified = oldContacts[0];

            app.Contacts.Modify(toBeModified, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            toBeModified.FirstName = newData.FirstName;
            toBeModified.LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                    Assert.AreEqual(newData.LastName, contact.LastName);
                }
            }

        }
    }
}
