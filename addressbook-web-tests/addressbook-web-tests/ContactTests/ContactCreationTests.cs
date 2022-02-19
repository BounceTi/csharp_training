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
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();

            ContactData contact = new("Ivan", "Ivanov");
            contact.MiddleName = "Ivanovich";
            contact.TelephoneMobile = "89131234567";
            FillContactForm(contact);

            SubmitContactCreation();
            ReturnToHomePage();
            Logout();
        }
    }
}
