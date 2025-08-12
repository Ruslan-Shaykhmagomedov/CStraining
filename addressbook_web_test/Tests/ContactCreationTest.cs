using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreation : TestBase
    {
        [Test]
        public void TheContactCreationTest()
        {
            ContactData contact = new ContactData("Ruslan", "Shaikhmagomedov", "Ibragimovich");
            contact.Email = "apostaterussle@gmail.com";
            contact.NickName = "Rus_Shaykh";
            contact.Company = "VSK";
            contact.Address = "Nizhniy Novgorod";
            contact.Byear = 1996;
            contact.Bday = "26";
            contact.Bmonth = "December";

            applicationManager.Contact.Create(contact);
        }
    }
}