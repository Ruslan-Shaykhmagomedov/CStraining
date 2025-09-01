using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTest : AuthTestBase
    {
        [Test]
        public void TheContactModificationTest()
        {
            ContactData newData = new ContactData("Margorita", "Shaikhmagomedova");
            //newData.Email = "apostaterussle@gmail.com";
            //newData.NickName = "MargoSha";
            //newData.Company = "VSK";
            //newData.Address = "Nizhniy Novgorod";
            //newData.Byear = 1997;
            //newData.Bday = "26";
            //newData.Bmonth = "August";

            if (!app.Contact.IsContactExist())
            {
                app.Contact.CreateContact();
            }
            app.Contact.Modify(2, newData);
        }
    }
}
