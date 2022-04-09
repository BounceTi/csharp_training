using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class ContactHelper : HelperBase
    {

        public static string WINMAINPAGE = "Free Address Book";
        public static string CONTACTWINEDITOR = "Contact Editor";
        public static string WINQUESTION = "Question";

        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public ContactHelper Add(ContactData contact)
        {
            aux.WinWait(WINMAINPAGE);
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            aux.WinWait(WINMAINPAGE);
            SelectContact(contact);
            InitContactRemoval();
            SubmitContactRemoval();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            aux.WinWait(CONTACTWINEDITOR);
            aux.ControlSetText(CONTACTWINEDITOR, "", "WindowsForms10.EDIT.app.0.2c908d516", contact.FirstName);
            aux.ControlSetText(CONTACTWINEDITOR, "", "WindowsForms10.EDIT.app.0.2c908d513", contact.LastName);
            aux.ControlSetText(CONTACTWINEDITOR, "", "WindowsForms10.EDIT.app.0.2c908d520", contact.Phone1);
            aux.ControlSetText(CONTACTWINEDITOR, "", "WindowsForms10.EDIT.app.0.2c908d518", contact.Email1);
            return this;
        }

        public ContactHelper SelectContact(ContactData contact)
        {
            aux.WinWait(WINMAINPAGE);
            string count = GetContactsCount();
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlListView(WINMAINPAGE, "", "WindowsForms10.Window.8.app.0.2c908d510",
                "GetText", "#" + i, "");
                // посмотреть что возвращается
                Console.Out.WriteLine("SelectContact method " + item);
                if (item.Equals(contact.FirstName))
                {
                    aux.ControlListView(WINMAINPAGE, "", "WindowsForms10.Window.8.app.0.2c908d510",
                "Select", "#" + i, "");
                    break;
                }
            }
            return this;
        }

        public List<ContactData> GetContactList()
        {
            aux.WinWait(WINMAINPAGE);
            List<ContactData> list = new List<ContactData>();
            string count = GetContactsCount();
            Console.Out.WriteLine("GetContactsCount method " + count);
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlListView(WINMAINPAGE, "", "WindowsForms10.Window.8.app.0.2c908d510",
                "GetText", "#0|#" + i, "");
                Console.Out.WriteLine("GetContactList method " + item);
                list.Add(new ContactData()
                {
                    // надо посмотреть, что возвращается
                    FirstName = item
                });
            }
            return list;
        }

        public bool CheckContactExist()
        {
            aux.WinWait(WINMAINPAGE);
            string count = GetContactsCount();
            if (int.Parse(count) == 0)
            {
                return false;
            }
            return true;
        }

        private ContactHelper InitContactCreation()
        {
            aux.WinWait(WINMAINPAGE);
            aux.ControlClick(WINMAINPAGE, "", "WindowsForms10.BUTTON.app.0.2c908d58");
            aux.WinWait(CONTACTWINEDITOR);
            return this;
        }

        private ContactHelper SubmitContactCreation()
        {
            aux.ControlClick(CONTACTWINEDITOR, "", "WindowsForms10.BUTTON.app.0.2c908d58");
            return this;
        }

        private ContactHelper InitContactRemoval()
        {
            aux.ControlClick(WINMAINPAGE, "", "WindowsForms10.BUTTON.app.0.2c908d59");
            aux.WinWait(WINQUESTION);
            return this;
        }

        private ContactHelper SubmitContactRemoval()
        {
            aux.ControlClick(WINQUESTION, "", "WindowsForms10.BUTTON.app.0.2c908d52");
            return this;
        }

        private string GetContactsCount()
        {
            var s = aux.ControlListView(WINMAINPAGE, "", "WindowsForms10.Window.8.app.0.2c908d510",
                "GetItemCount", "", "");
            Console.Out.WriteLine("smth " + s);
            return aux.ControlListView(WINMAINPAGE, "", "WindowsForms10.Window.8.app.0.2c908d510",
                "GetItemCount", "", "");
        }
    }
}
