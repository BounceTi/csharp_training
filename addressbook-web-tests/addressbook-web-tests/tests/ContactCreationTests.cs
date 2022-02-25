using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest() 
        {
            ContactData contact = new("Ivan", "Ivanov")
            {
                MiddleName = "Ivanovich",
                TelephoneMobile = "89131234567"
            };

            app.Contacts.Create(contact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new("", "")
            {
                MiddleName = "",
            };

            app.Contacts.Create(contact);
        }
    }
}
