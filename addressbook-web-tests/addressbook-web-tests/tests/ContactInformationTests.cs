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
            ContactData fromTabel = app.Contacts.GetContactInformationFromTable(3);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(3);

            Assert.AreEqual(fromTabel, fromForm);
            Assert.AreEqual(fromTabel.Address, fromForm.Address);
            Assert.AreEqual(fromTabel.AllPhones, fromForm.AllPhones);
        }
        [Test]
        public void TestContactInformationFromDetailsAndEditForm()
        {
            string fromTabel = app.Contacts.GetAsStringContactInformationFromEditForm(3);
            string fromForm = app.Contacts.GetContactInformationFromDetails(3);

            Assert.AreEqual(fromTabel, fromForm);
        }
    }
}
