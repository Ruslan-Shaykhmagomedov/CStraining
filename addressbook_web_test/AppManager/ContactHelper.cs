using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Create(ContactData contact)
        {
            GoToEditPage();
            FillContactInfo(contact);
            EnterButtonClick();
            GoToMainPage();
            return this;
        }
        public ContactHelper Remove(int number)
        {
            SelectContact(number);
            RemoveContact();
            return this;
        }
        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHomePage();

            SelectContact(contact.Id);
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;

        }
        public ContactHelper Modify(int number, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(number);
            ClearFields();
            FillContactInfo(newData);
            SubmitButtonClick();
            GoToMainPage();
            return this;
        }
        public ContactHelper Modify (ContactData newData, ContactData oldData)
        {
            manager.Navigator.GoToHomePage();
            InitContactEdit(oldData.Id);
            FillContactInfo(newData);
            SubmitButtonClick();
            GoToMainPage();
            return this;
        }
        public ContactHelper InitContactEdit (string Id)
        {
            driver.FindElement(By.XPath("//tr[.//input[@value='" + Id + "']]//img[@title='Edit']")).Click(); // Contact editing button click
            return this;
        }
        public ContactHelper CreateContact()
        {
            GoToEditPage();
            FillContactInfo(new ContactData("Testov", "Test"));
            EnterButtonClick();
            GoToMainPage();
            return this;
        }
        public ContactHelper ClearFields()
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("byear")).Clear();
            return this;
        }
        public ContactHelper EnterButtonClick()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
            return this;
        }
        public ContactHelper SubmitButtonClick()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            GoToMainPage();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 2) + "]/td/input")).Click(); ;
            return this;
        }
        public ContactHelper GoToMainPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
        public ContactHelper FillContactInfo(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            //driver.FindElement(By.Name("firstname")).Click();
            //driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            //driver.FindElement(By.Name("lastname")).Click();
            //driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            //driver.FindElement(By.Name("middlename")).Click();
            //driver.FindElement(By.Name("middlename")).SendKeys(contact.Lastname);
            //driver.FindElement(By.Name("nickname")).Click();
            //driver.FindElement(By.Name("nickname")).SendKeys(contact.NickName);
            //driver.FindElement(By.Name("company")).Click();
            //driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            //driver.FindElement(By.Name("address")).Click();
            //driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            //driver.FindElement(By.XPath("//div[@id='content']/form/label[10]")).Click();
            //driver.FindElement(By.Name("email")).Click();
            //driver.FindElement(By.Name("email")).SendKeys(contact.Email);
            //driver.FindElement(By.Name("bday")).Click();
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            //driver.FindElement(By.Name("byear")).Click();
            //driver.FindElement(By.Name("byear")).SendKeys(contact.Byear.ToString());
            return this;
        }
        public ContactHelper GoToEditPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public bool IsContactExist()
        {
            return IsElementPresent(By.Name("entry"));
        }
        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            List<ContactData> contactCache = null;
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    // Находим все колонки в строке
                    IList<IWebElement> column = element.FindElements(By.TagName("td"));

                    // Извлекаем фамилию (2я колонка) и имя (3я колонка)
                    string lastname = column[1].Text;
                    string firstname = column[2].Text;

                    contactCache.Add(new ContactData(firstname, lastname));
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            InitDetails(index);

            string allnames = driver.FindElement(By.Id("content"))
                   .FindElement(By.TagName("b"))
                   .Text;
            string textInDetails = driver.FindElement(By.Id("content")).Text;
            return new ContactData()
            {
                AllNames = allnames,
                TextInDetails = textInDetails
            };
        }
        public void InitDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
        }
        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();

            SelectGroupFilter(group.Name);
            SelectContact(contact.Id);
            CommitContactRemovalFromGroup();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
               .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CommitContactRemovalFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void SelectGroupFilter(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        //Add contact to group
        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count() > 0); // Waiter for 10 sec with lyambda function
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void ClearFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }
        public void SelectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }
    }
}