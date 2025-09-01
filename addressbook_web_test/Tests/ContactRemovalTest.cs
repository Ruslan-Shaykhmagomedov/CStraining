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
                app.Contact.CreateContact();
            }

            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Remove(0);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
