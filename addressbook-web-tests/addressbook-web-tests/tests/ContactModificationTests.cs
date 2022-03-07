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

            app.Contacts.Modify(0, newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
