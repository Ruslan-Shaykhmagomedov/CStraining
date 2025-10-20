using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    public class ContactRemovalTest : AuthTestBase
    {
        [Test]
        public void TheContactRemovalTest()
        {
            if (!app.Contact.IsContactExist())
            {
                app.Contact.CreateContact(); // If there is no Contact, Create new one. Than delete it
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contact.Remove(toBeRemoved);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
