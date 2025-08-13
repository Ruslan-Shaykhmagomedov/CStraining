using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTest : TestBase
    {
        [Test]
        public void TheContactModificationTest()
        {
            ContactData newData = new ContactData("Margorita", "Shaikhmagomedova", "Arturovna");
            newData.Email = "apostaterussle@gmail.com";
            newData.NickName = "MargoSha";
            newData.Company = "VSK";
            newData.Address = "Nizhniy Novgorod";
            newData.Byear = 1997;
            newData.Bday = "26";
            newData.Bmonth = "August";

            applicationManager.Contact.Modify(2, newData);
        }
    }
}
