using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreation 
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToEditPage();
            ContactData contact = new ContactData("Ruslan", "Shaykhmagomedov", "Ibragimovich");
            contact.Email = "apostaterussle@gmail.com";
            contact.NickName = "Rus_Shaykh";
            contact.Company = "VSK";
            contact.Address = "Nizhniy Novgorod";
            contact.Byear = 1996;
            contact.Bday = "26";
            contact.Bmonth = "December";
            FillContactInfo(contact);
            GoToMainPageAfterContacCreation();
        }

        private void GoToMainPageAfterContacCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
            driver.FindElement(By.LinkText("home page")).Click();
        }

        private void FillContactInfo(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.MIddlename);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.NickName);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            driver.FindElement(By.XPath("//div[@id='content']/form/label[10]")).Click();
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email);
            driver.FindElement(By.Name("theform")).Click();
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            driver.FindElement(By.Name("theform")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).SendKeys(contact.Byear.ToString());
        }

        private void GoToEditPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }
        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
