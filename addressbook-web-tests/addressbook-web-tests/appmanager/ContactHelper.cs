using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
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
            Type(By.Name("mobile"), contact.MobilePhone);
            return this;
        }
        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        private List<ContactData> contactCache = null;

        internal List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                manager.Navigator.GoToHomePage();
                contactCache = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    var firstName = element.FindElement(By.XPath(".//td[3]")).Text;
                    var lastName = element.FindElement(By.XPath(".//td[2]")).Text;

                    contactCache.Add(new ContactData(firstName, lastName)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return contactCache;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            contactCache = null;
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
            contactCache = null;
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
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int contactNumber)
        {
            driver.FindElement(By.XPath("//tr[@name='entry'][" + (contactNumber + 1) + "]//img[@title='Edit']")).Click();
            return this;
        }
        public ContactHelper OpenContactInformation(int contactNumber)
        {
            driver.FindElement(By.XPath("//tr[@name='entry'][" + (contactNumber + 1) + "]//img[@title='Details']")).Click();
            return this;
        }
        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
            };
        }
        public string GetAsStringContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            firstName = AddTextIfStringIsNotNull(firstName, "", " ");

            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            middleName = AddTextIfStringIsNotNull(middleName, "", " ");

            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");

            string nameBlock = (firstName + middleName + lastName).Trim();
            nameBlock = AddTextIfStringIsNotNull(nameBlock, "", "\r\n");


            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            nickName = AddTextIfStringIsNotNull(nickName, "", "\r\n");

            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            title = AddTextIfStringIsNotNull(title, "", "\r\n");

            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            company = AddTextIfStringIsNotNull(company, "", "\r\n");

            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            address = AddTextIfStringIsNotNull(address, "", "\r\n");

            string generalBlock = (nickName + title + company + address).Trim();
            generalBlock = AddTextIfStringIsNotNull(generalBlock, "", "\r\n");


            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            email = AddTextIfStringIsNotNull(email, "", "\r\n");

            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            email2 = AddTextIfStringIsNotNull(email2, "", "\r\n");

            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            email3 = AddTextIfStringIsNotNull(email3, "", "\r\n");

            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            homepage = AddTextIfStringIsNotNull(homepage, "Homepage:" + "\r\n", "");

            string linksBlock = (email + email2 + email3 + homepage).Trim();
            linksBlock = AddTextIfStringIsNotNull(linksBlock, "\r\n", "\r\n");


            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            homePhone = AddTextIfStringIsNotNull(homePhone, "\r\n" + "H: ", "\r\n");

            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            mobilePhone = AddTextIfStringIsNotNull(mobilePhone, "M: ", "\r\n");

            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            workPhone = AddTextIfStringIsNotNull(workPhone, "W: ", "\r\n");

            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            fax = AddTextIfStringIsNotNull(fax, "F: ", "\r\n");

            string phonesBlock = (homePhone + mobilePhone + workPhone + fax).Trim();
            phonesBlock = AddTextIfStringIsNotNull(phonesBlock, "\r\n", "\r\n");


            return (nameBlock + generalBlock + phonesBlock + linksBlock).Trim();
        }
        public static string AddTextIfStringIsNotNull(string str, string before, string after)
        {
            if (str.Equals("") || str.Equals(null))
            {
                return "";
            }
            return before + str + after;
        }
        public string GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            OpenContactInformation(index);
            return driver.FindElement(By.Id("content")).Text;
        }
        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones,
            };
        }
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.Id("search_count")).Text;
            return Int32.Parse(text);
        }
    }
}
