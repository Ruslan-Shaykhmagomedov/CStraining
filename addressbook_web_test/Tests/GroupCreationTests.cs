using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
      
        [Test]
        public void GroupCreateTest()
        {
            GroupData group = new GroupData("TestName");
            group.Header = "TestHeader";
            group.Footer = "TestFooter";

            app.Groups.Create(group);
        }
        [Test]
        public void EmptyGroupCreateTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
        }
    }
}
