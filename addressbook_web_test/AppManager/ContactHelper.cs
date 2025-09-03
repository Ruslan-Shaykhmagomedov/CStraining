using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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
        public ContactHelper Modify(int number, ContactData newData)
        {
            SelectContact(number);
            ClickEditButton();
            ClearFields();
            FillContactInfo(newData);
            SubmitButtonClick();
            GoToMainPage();
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
        public ContactHelper ClickEditButton()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
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
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index+2) + "]/td/input")).Click(); ;
            return this;
        }
        public ContactHelper GoToMainPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
        public ContactHelper FillContactInfo(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
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
            if(contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
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
    }
}
