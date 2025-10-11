using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreation : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30)));
            }
            return contact;
        }
        [Test, TestCaseSource("RandomContactDataProvider")]
        public void TheContactCreationTest(ContactData contact)
        {
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