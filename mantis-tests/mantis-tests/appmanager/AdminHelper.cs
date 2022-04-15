using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class AdminHelper : HelperBase
    {
        private string baseUrl;
        public AdminHelper(ApplicationManager manager, String baseUrl) : base(manager) 
        {
            this.baseUrl = baseUrl;
        }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();

            OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_page.php";

            System.Threading.Thread.Sleep(5000);

            IList<IWebElement> rows = driver.FindElements(By.XPath("//table/tbody/tr"));
            foreach(IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;
                accounts.Add(new AccountData()
                {
                    Name = name,
                    Id = id
                });
            }
            return accounts;
        }

        public void DeleteAccount(AccountData account)
        {
            OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.Id("manage-user-delete-form")).Click();
            driver.FindElement(By.ClassName("alert")).FindElement(By.ClassName("btn")).Click();
        }

        public void OpenAppAndLogin()
        {
            //IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseUrl + "/login_page.php";
            manager.Auth.Login(new AccountData()
            {
                Name = "administrator",
                Password = "root"
            });
        }
    }
}
