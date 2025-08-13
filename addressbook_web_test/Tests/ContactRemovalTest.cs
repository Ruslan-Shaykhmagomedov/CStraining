using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactRemovalTest : TestBase
    {
        [Test]
        public void TheContactRemovalTest()
        {
            applicationManager.Contact.Remove(2);
        }
    }
}
