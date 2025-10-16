using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTest : GroupTestBase
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
            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Modify(0, newData);
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
