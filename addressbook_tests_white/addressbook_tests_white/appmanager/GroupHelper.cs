using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUPWINTITLE = "Delete group";
        public static string QUESTIONTITLE = "Question";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach(TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
            
            CloseGroupsDialogue(dialogue);
            return list;
        }
        public bool CheckGroupExist()
        {
            if (GetGroupList().Count() <= 1)
            {
                return false;
            }
            return true;
        }

        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();
            MainWindow.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox)dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialogue(dialogue);
        }

        public void Remove(GroupData toBeRemoved)
        {
            Window dialogue = OpenGroupsDialogue();

            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                if (item.Text.Equals(toBeRemoved.Name))
                {
                    item.Select();
                    break;
                }
            }

            MainWindow.Get<Button>("uxDeleteAddressButton").Click();
            dialogue.ModalWindow(DELETEGROUPWINTITLE);
            MainWindow.Get<Button>("uxOKAddressButton").Click();
            CloseGroupsDialogue(dialogue);
        }

        private void CloseGroupsDialogue(Window dialogue)
        {
            MainWindow.Get<Button>("uxCloseAddressButton").Click();
        }

        private Window OpenGroupsDialogue()
        {
            MainWindow.Get<Button>("groupButton").Click();
            return MainWindow.ModalWindow(GROUPWINTITLE);
        }
    }
}