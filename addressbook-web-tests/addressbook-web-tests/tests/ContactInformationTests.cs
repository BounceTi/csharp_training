using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformationFromTableAndEditForm()
        {
            int contactNumber = 3;
            ContactData fromTabel = app.Contacts.GetContactInformationFromTable(contactNumber);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(contactNumber);

            Assert.AreEqual(fromTabel, fromForm);
            Assert.AreEqual(fromTabel.Address, fromForm.Address);
            Assert.AreEqual(fromTabel.AllPhones, fromForm.AllPhones);
        }
        [Test]
        public void TestContactInformationFromDetailsAndEditForm()
        {
            int contactNumber = 3;
            string fromTabel = app.Contacts.GetAsStringContactInformationFromEditForm(contactNumber);

            string fromForm = app.Contacts.GetContactInformationFromDetails(contactNumber);

            Assert.AreEqual(fromTabel, fromForm);
        }
    }
}
