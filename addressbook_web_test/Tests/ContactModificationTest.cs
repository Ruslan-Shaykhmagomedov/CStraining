using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTest : ContactTestBase
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
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0]; // Save string by Id

            app.Contact.Modify(newData, oldData); // modify contact

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if(contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.FirstName, contact.FirstName); 
                }
            }
        }
    }
}
