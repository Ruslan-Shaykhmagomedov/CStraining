using NUnit.Framework;

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
            app.Groups.Remove(1); // Delete Group
        }
    }
}
