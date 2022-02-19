using NUnit.Framework;

namespace WebAddressbookTests
{
    internal class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new("NewIvan", "NewIvanov")
            {
                MiddleName = "NewIvanovich",
                TelephoneMobile = "89137654321"
            };

            app.Contacts.Modify(3, newData);
            app.Auth.Logout();
        }
    }
}
