using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_white
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";

        private GroupHelper groupHelper;
        private ContactHelper contactHelper;
        private Application app;

        public ApplicationManager()
        {
            app = Application.Launch(@"D:\AddressBook\AddressBook.exe");
            MainWindow = app.GetWindow(WINTITLE);

            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
        }

        public static Window MainWindow { get; private set; }

        public GroupHelper Groups
        {
            get { return groupHelper; }
        }
        public ContactHelper Contacts
        {
            get { return contactHelper; }
        }
    }
}
