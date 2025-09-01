using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupsPage();

            if (!app.Groups.IsGroupExist()) // If there is no Group, Create new one. Than delete it
            {
                app.Groups.CreateGroup();
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0); // Delete Group
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
