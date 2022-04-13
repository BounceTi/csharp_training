using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit.Framework;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected static string mantisVersion;

        protected LoginHelper loginHelper;

        protected ManagementMenuHelper managementMenu;

        protected ProjectManagementHelper projectManagementHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            baseURL = "http://localhost";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            loginHelper = new LoginHelper(this, mantisVersion);
            mantisVersion = "/mantisbt-2.25.2";
            managementMenu = new ManagementMenuHelper(this, mantisVersion, baseURL);
            projectManagementHelper = new ProjectManagementHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost" + mantisVersion + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public RegistrationHelper Registration { get; private set; }

        public FtpHelper Ftp { get; private set; }
        public JamesHelper James { get; private set; }
        public MailHelper Mail { get; private set; }

        public LoginHelper Auth
        {
            get { return loginHelper; }
        }

        public ManagementMenuHelper ManagementMenu
        {
            get { return managementMenu;  }
        }

        public ProjectManagementHelper PMHelper
        {
            get { return projectManagementHelper; }
        }
    }
}
