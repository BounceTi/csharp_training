using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void TestContactCreation()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            System.Console.Out.WriteLine("Old");
            foreach (ContactData contact in oldContacts)
            {
                System.Console.Out.WriteLine(contact.ToString());
            }

            ContactData newContact = new ContactData()
            {
                FirstName = "Adding",
                LastName = "Test",
                Phone1 = "89131234567",
                Email1 = "test@adding.com"
            };

            app.Contacts.Add(newContact);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            System.Console.Out.WriteLine("New");
            foreach (ContactData c in newContacts)
            {
                System.Console.Out.WriteLine(c.ToString());
            }

            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
