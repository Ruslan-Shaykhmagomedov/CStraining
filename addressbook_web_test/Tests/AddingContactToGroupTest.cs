using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTest : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact =  ContactData.GetAll().Except(oldList).First();

            //Actions with data
            
            app.Contact.AddContactToGroup(contact,group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact); //add contact 
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList,newList); // check if they are the same
        }
    }
}
