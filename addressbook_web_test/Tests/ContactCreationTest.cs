using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreation : AuthTestBase
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

            app.Contact.Create(contact);
        }
    }
}