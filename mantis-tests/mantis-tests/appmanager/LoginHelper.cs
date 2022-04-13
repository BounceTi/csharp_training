using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {

        private string mantisVersion;

        public LoginHelper(ApplicationManager manager, string mantisVersion) : base(manager) 
        {
            this.mantisVersion = mantisVersion;
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("username"), account.Name);
            driver.FindElement(By.ClassName("btn-success")).Click();
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.ClassName("btn-success")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("//div[2]/ul/li[3]/a")).Click();
                driver.FindElement(By.LinkText(mantisVersion + "/logout_page.php")).Click();
            }
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Name;
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.ClassName("user-info"));
        }

        private string GetLoggetUserName()
        {
            return driver.FindElement(By.ClassName("user-info")).Text;
        }
    }
}
