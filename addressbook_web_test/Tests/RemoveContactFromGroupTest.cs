using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTest : AuthTestBase
    {
        [Test]
        public void ContactRemoveFromGroup()
        {
            List<GroupData> allGroups = GroupData.GetAll();
            if (allGroups.Count == 0) // If there was no group, than create new 
            {
                GroupData newGroup = new GroupData("GroupTest");
                app.Groups.Create(newGroup);
                allGroups = GroupData.GetAll();
            }

            List<ContactData> allContacts = ContactData.GetAll();
            if (allContacts.Count == 0) // If there was no contact, than create new 
            {
                ContactData newContact = new ContactData("ContactTestName", "ContactTestLastName");
                app.Contact.Create(newContact);
                allContacts = ContactData.GetAll();
            }

            // Trying to find a couple between contact and group, where contact not in group
            GroupData groupCheck = null;
            ContactData contactCheck = null;

            foreach (GroupData group in allGroups)
            {
                List<ContactData> contactInGroup = group.GetContacts();
                List<ContactData> contactNotInGroup = allContacts.Except(contactInGroup).ToList();

                if (contactNotInGroup.Count > 0)
                {
                    groupCheck = group;
                    contactCheck = contactNotInGroup.First();
                    break;
                }
            }

            if (groupCheck == null) // if every contacts in groups, create new group
            {
                GroupData newGroup = new GroupData("NewGroupTest");
                app.Groups.Create(newGroup);
                groupCheck = GroupData.GetAll().First(g => g.Name == newGroup.Name);
                contactCheck = allContacts.First();
            }

            List<ContactData> oldList = groupCheck.GetContacts(); // Get contact List for this group

            app.Contact.AddContactToGroup(contactCheck, groupCheck); // add contact to group

            List<ContactData> newList = groupCheck.GetContacts(); // Get new contact List
            oldList.Add(contactCheck);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList,newList);
        }
    }
}
