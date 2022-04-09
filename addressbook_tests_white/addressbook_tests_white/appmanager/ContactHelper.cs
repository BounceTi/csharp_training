using System;
using System.Collections.Generic;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TableItems;

namespace addressbook_tests_white
{
    public class ContactHelper : HelperBase
    {

        public static string WINMAINPAGE = "Free Address Book";
        public static string CONTACTWINEDITOR = "Contact Editor";
        public static string WINQUESTION = "Question";

        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public ContactHelper Add(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            SelectContact(contact);
            InitContactRemoval();

            SubmitContactRemoval();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            MainWindow.ModalWindow(CONTACTWINEDITOR);
            MainWindow.Get<TextBox>("ueFirstNameAddressTextBox").SetValue(contact.FirstName);
            MainWindow.Get<TextBox>("ueLastNameAddressTextBox").SetValue(contact.LastName);
            MainWindow.Get<TextBox>("uePhone1AddressTextBox").SetValue(contact.Phone1);
            MainWindow.Get<TextBox>("ueEmail1AddressTextBox").SetValue(contact.Email1);
            return this;
        }

        public ContactHelper SelectContact(ContactData contact)
        {
            int count = GetContactsCount();
            Table contacts = MainWindow.Get<Table>("uxAddressGrid");
            for (int i = 0; i < count; i++)
            {
                if(contact.FirstName == contacts.Rows[i].Cells[0].Value.ToString() &&
                    contact.LastName == contacts.Rows[i].Cells[1].Value.ToString())
                {
                    contacts.Rows[i].Click();
                    break;
                }
            }
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();
            int count = GetContactsCount();
            Table contacts = MainWindow.Get<Table>("uxAddressGrid");
            for(int i = 0; i < count; i++)
            {
                list.Add(new ContactData()
                {
                    FirstName = contacts.Rows[i].Cells[0].Value.ToString(),
                    LastName = contacts.Rows[i].Cells[1].Value.ToString(),
                });
            }
            return list;
        }

        public bool CheckContactExist()
        {
            int count = GetContactsCount();
            if (count == 0)
            {
                return false;
            }
            return true;
        }

        private ContactHelper InitContactCreation()
        {
            MainWindow.Get<Button>("uxNewAddressButton").Click();
            return this;
        }

        private ContactHelper SubmitContactCreation()
        {
            MainWindow.Get<Button>("uxSaveAddressButton").Click();
            return this;
        }

        private ContactHelper InitContactRemoval()
        {
            MainWindow.Get<Button>("uxDeleteAddressButton").Click();
            return this;
        }

        private ContactHelper SubmitContactRemoval()
        {
            MainWindow.MessageBox(WINQUESTION);
            MainWindow.Get<Button>(SearchCriteria.ByText("Yes")).Click();
            return this;
        }

        public int GetContactsCount()
        {
            return MainWindow.Get<Table>("uxAddressGrid").Rows.Count;
        }
    }
}
