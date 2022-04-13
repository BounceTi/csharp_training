using OpenQA.Selenium;
using System.Collections.Generic;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        private string mantisVersion;

        public ManagementMenuHelper(ApplicationManager manager, string mantisVersion, string baseURL) : base(manager) 
        {
            this.mantisVersion = mantisVersion;
        }

        public void OpenProjectManagementPage()
        {
            SidebarNavigate("/manage_overview_page.php");
            TabsNavigation("/manage_proj_page.php");
        }

        public void SidebarNavigate(string href)
        {
            IWebElement sidebar = driver.FindElement(By.Id("sidebar"));
            ICollection<IWebElement> elements = sidebar.FindElements(By.TagName("a"));

            foreach (IWebElement element in elements)
            {
                if (element.GetAttribute("href").EndsWith(mantisVersion + href))
                {
                    if(element.FindElement(By.XPath("./..")).GetAttribute("class") == "active")
                    {
                        return;
                    } 
                    else
                    {
                        element.Click();
                    }
                }
            }
        }

        public void TabsNavigation(string href)
        {
            IWebElement tabPanel = driver.FindElement(By.ClassName("nav-tabs"));
            ICollection<IWebElement> allTabs = tabPanel.FindElements(By.TagName("a"));

            foreach(IWebElement tab in allTabs)
            {
                try
                {
                    if (tab.GetAttribute("href").EndsWith(mantisVersion + href))
                    {
                        if (tab.FindElement(By.XPath("./..")).GetAttribute("class") == "active")
                        {
                            return;
                        }
                        else
                        {
                            tab.Click();
                        }
                    }
                } 
                catch (StaleElementReferenceException ex)
                {
                }
            }
        }
    }
}
