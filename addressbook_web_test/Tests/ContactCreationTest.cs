using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreation : AuthTestBase
    {
        [Test]
        public void TheContactCreationTest()
        {
            ContactData contact = new ContactData("Check", "Count");
            //contact.Email = "apostaterussle@gmail.com";
            //contact.NickName = "Rus_Shaykh";
            //contact.Company = "VSK";
            //contact.Address = "Nizhniy Novgorod";
            //contact.Byear = 1996;
            //contact.Bday = "26";
            //contact.Bmonth = "December";

            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Create(contact);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}