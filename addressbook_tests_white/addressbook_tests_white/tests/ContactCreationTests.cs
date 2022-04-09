using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_white
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void TestContactCreation()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData newContact = new ContactData()
            {
                FirstName = "Adding",
                LastName = "Test",
                Phone1 = "89131234567",
                Email1 = "test@adding.com"
            };

            app.Contacts.Add(newContact);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
