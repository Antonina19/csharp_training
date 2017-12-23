using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUPWINTITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemColunt", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
               string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetTex", "#0|#"+i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsDialogue();
            return list;
        }

        public void CheckGroupExist()
        {
            if (GetGroupCount() <= 1)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "GroupTestIT"
                };

                Add(newGroup);
            }
        }



        public int GetGroupCount()
        {
            OpenGroupsDialogue();
            int count = int.Parse(aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51", 
                "GetItemCount", "#0", ""));
            CloseGroupsDialogue();

            return count;
        }
        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();

        }

        public void Remove(int index)
        {
            OpenGroupsDialogue();
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView.app.0.2c908d51",
                "Select", "#0|#0", "");
            OpenDeleteGroupDialog();
            CloseDeleteGroupDialog();

            CloseGroupsDialogue();
        }

        private void CloseDeleteGroupDialog()
        {
            aux.ControlClick(DELETEGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
        }

        private void OpenDeleteGroupDialog()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(DELETEGROUPWINTITLE);
        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }
    }
}