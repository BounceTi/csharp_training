﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
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
            CreateIfNotExist();
            manager.Navigator.GoToHomePage();
            InitContactModification(contactNumber);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper Remove(int contactNumber)
        {
            CreateIfNotExist();
            manager.Navigator.GoToHomePage();
            SelectContact(contactNumber);
            RemoveContact();
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper CreateIfNotExist()
        {
            if (!IsElementPresent(By.Name("entry")))
            {
                ContactData contact = new("Ivan", "Ivanov")
                {
                    MiddleName = "Ivanovich",
                    TelephoneMobile = "89131234567"
                };

                Create(contact);
            }
            return this;
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
            driver.FindElement(By.XPath("//tr[@name='entry'][" + contactNumber + "]/td/input")).Click();
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
            driver.FindElement(By.XPath("//tr[@name='entry'][" + contactNumber + "]//img[@title='Edit']")).Click();
            return this;
        }
    }
}
