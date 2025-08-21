using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            app.Contact.Remove(2);
        }
    }
}
