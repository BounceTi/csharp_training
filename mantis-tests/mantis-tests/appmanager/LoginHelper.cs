using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

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
                driver.FindElement(By.XPath("//div[2]/ul/li[3]")).Click();
                IWebElement dropdownMenu = driver.FindElement(By.ClassName("user-menu"));
                dropdownMenu.FindElement(By.XPath("//li[4]/a/i")).Click();
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
