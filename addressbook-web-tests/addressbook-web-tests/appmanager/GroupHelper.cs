﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) 
            : base(manager) { }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            manager.Navigator.GoToGroupsPage();
            List<GroupData> groupList = new();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach(IWebElement element in elements)
            {
                Console.WriteLine(element.Text);
                groupList.Add(new GroupData(element.Text));
            }
            return groupList;
        }

        public GroupHelper Modify(int groupNumber, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(groupNumber);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int groupNumber)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(groupNumber);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public bool CheckGroupExist()
        {
            manager.Navigator.GoToGroupsPage();
            return IsElementPresent(By.XPath("//span[@class='group']"));
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
