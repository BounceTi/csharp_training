using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_white
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected Window MainWindow;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            MainWindow = ApplicationManager.MainWindow;
        }
    }
}