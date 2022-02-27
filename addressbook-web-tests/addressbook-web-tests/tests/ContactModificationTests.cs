using NUnit.Framework;

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

            app.Contacts.Modify(1, newData);
        }
    }
}
