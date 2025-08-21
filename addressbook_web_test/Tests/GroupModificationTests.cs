using NUnit.Framework;


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
            app.Groups.Modify(1, newData); // Modify Group

        }
    }
}
