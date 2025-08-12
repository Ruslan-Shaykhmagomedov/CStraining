using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("NewName");
            newData.Header = "newHeader";
            newData.Footer = "newFooter";

            applicationManager.Groups.Modify(1, newData);

        }
    }
}
