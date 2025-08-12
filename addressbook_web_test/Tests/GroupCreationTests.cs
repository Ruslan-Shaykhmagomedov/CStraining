using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
      
        [Test]
        public void GroupCreateTest()
        {
            GroupData group = new GroupData("TestName");
            group.Header = "TestHeader";
            group.Footer = "TestFooter";

            applicationManager.Groups.Create(group);
        }
        [Test]
        public void EmptyGroupCreateTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            applicationManager.Groups.Create(group);
        }
    }
}
