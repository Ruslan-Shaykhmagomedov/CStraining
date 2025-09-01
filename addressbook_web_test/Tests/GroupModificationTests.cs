using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("NewName");
            newData.Header = "NewHeader";
            newData.Footer = "NewFooter";
            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsGroupExist()) // If there is no Group, Create new one. 
            {
                app.Groups.CreateGroup();
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newData); // Modify Group
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
