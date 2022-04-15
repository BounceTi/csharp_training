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

        protected AccountData adminAccount;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            mantisVersion = "/mantisbt-2.25.2";
            baseURL = "http://localhost" + mantisVersion;
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Auth = new LoginHelper(this);
            ManagementMenu = new ManagementMenuHelper(this, mantisVersion, baseURL);
            PMHelper = new ProjectManagementHelper(this);
            Admin = new AdminHelper(this, baseURL);
            API = new APIHelper(this);

            adminAccount = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
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
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
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

        public LoginHelper Auth { get; private set; }

        public ManagementMenuHelper ManagementMenu { get; private set; }

        public ProjectManagementHelper PMHelper { get; private set; }

        public AdminHelper Admin { get; private set; }
        public APIHelper API { get; private set; }
        public AccountData AdminAccount { get { return adminAccount; } }
    }
}
