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

            app.Contacts.Modify(1, newData);
        }
    }
}
