using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDetailsTests : AuthTestBase
    {
        [Test]
        public void ContactDetailsTest()
        {
            ContactData fromDetails = app.Contact.GetContactInformationFromDetails(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            // verification
            Assert.AreEqual(fromDetails.AllNames, fromForm.AllNames);
            Assert.AreEqual(fromDetails.TextInDetails, fromForm.TextInDetails);
        }
    }
}