using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
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
            app.Auth.Logout();
        }
    }
}
