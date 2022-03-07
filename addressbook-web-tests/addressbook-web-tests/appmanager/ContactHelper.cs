using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager)
            : base(manager) { }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper Modify(int contactNumber, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(contactNumber);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToContactsPage();
            return this;
        }

        internal List<ContactData> GetContactList()
        {
            manager.Navigator.GoToHomePage();
            List<ContactData> contactList = new();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            foreach (IWebElement element in elements)
            {
                var firstName = element.FindElement(By.XPath(".//td[3]")).Text;
                var lastName = element.FindElement(By.XPath(".//td[2]")).Text;
                contactList.Add(new ContactData(firstName, lastName));
            }
            return contactList;
        }

        public ContactHelper Remove(int contactNumber)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(contactNumber);
            RemoveContact();
            ReturnToContactsPage();
            return this;
        }
        public bool CheckContactExist()
        {
            manager.Navigator.GoToHomePage();
            return IsElementPresent(By.Name("entry"));
        }
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("mobile"), contact.TelephoneMobile);
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return this;
        }
        private ContactHelper SelectContact(int contactNumber)
        {
            driver.FindElement(By.XPath("//tr[@name='entry'][" + (contactNumber + 1) + "]/td/input")).Click();
            return this;
        }

        private ContactHelper RemoveContact()
        {
            driver.FindElement(By.CssSelector("input[value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int contactNumber)
        {
            driver.FindElement(By.XPath("//tr[@name='entry'][" + (contactNumber + 1) + "]//img[@title='Edit']")).Click();
            return this;
        }
    }
}
