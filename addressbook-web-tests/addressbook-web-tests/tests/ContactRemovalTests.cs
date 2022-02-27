using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {

            if (!app.Contacts.CheckContactExist())
            {
                ContactData contact = new("Ivan", "Ivanov")
                {
                    MiddleName = "Ivanovich",
                    TelephoneMobile = "89131234567"
                };

                app.Contacts.Create(contact);
            }

            app.Contacts.Remove(1);
        }
    }
}
