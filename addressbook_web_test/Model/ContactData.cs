using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        string allPhones;
        private string allNames;
        private string textInDetails;

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
            //MiddleName = middlename;
        }
        public ContactData(string firstname)
        {
            FirstName = firstname;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() & LastName.GetHashCode();
        }
        public override string ToString()
        {
            return "firstname=" + FirstName
                + "\nlastname=" + LastName;
        }
        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int LastNameCompare = LastName.CompareTo(other.LastName);
            if (LastNameCompare != 0)
            {
                return LastNameCompare;
            }
            return FirstName.CompareTo(other.FirstName);
        }
        //public string MiddleName {get; set;}
        public string NickName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                { return allPhones; }
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        private string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ \\-()]", "") + "\r\n";
        }
        public string Email { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public int Byear { get; set; }
        public ContactData()
        {
        }
        public string AllNames
        {
            get
            {
                if (allNames != null)
                { return allNames; }
                else
                {
                    return (FirstName + " " + LastName).Trim();
                }
            }
            set
            {
                allNames = value;
            }
        }
        public string TextInDetails
        {
            get
            {
                if (textInDetails != null)
                {
                    return textInDetails;
                }
                else
                {
                    return (
                        (CleanUpNameInDetails(FirstName) + " " + CleanUpNameInDetails(LastName)).Trim() + "\r\n" 
                        + CleanUpAddressInDetails(Address)
                        + CleanUpPhoneInDetails(HomePhone, MobilePhone, WorkPhone)).Trim();
                }
            }
            set
            {
                textInDetails = value;
            }
        }
        private string CleanUpPhoneInDetails(string homePhone, string mobilePhone, string workPhone)
        {
            // Cписок для хранения непустых телефонов
            var phones = new List<string>();

            // Проверяем и добавляем домашний телефон
            if (!string.IsNullOrEmpty(homePhone))
            {
                phones.Add("H: " + homePhone);
            }

            // Проверяем и добавляем мобильный телефон
            if (!string.IsNullOrEmpty(mobilePhone))
            {
                phones.Add("M: " + mobilePhone);
            }

            // Проверяем и добавляем рабочий телефон
            if (!string.IsNullOrEmpty(workPhone))
            {
                phones.Add("W: " + workPhone);
            }

            // Если есть телефоны, возвращаем их с переносами строк
            if (phones.Count > 0)
            {
                return string.Join("\r\n", phones) + "\r\n\r\n";
            }

            // Если телефонов нет, возвращаем пустую строку
            return string.Empty;
        }
        private string CleanUpAddressInDetails(string address)
        {
            if (address == null || address == "")
            {
                return "" + "\r\n";
            }
            return address + "\r\n\r\n";
        }

        private string CleanUpNameInDetails(string name)
        {
            if (name == null || name == "")
            {
                return "";
            }
            return name;
        }

        private string CleanUpTextInDetails(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text + "\r\n";
        }

        //private string CleanUpWorkPhoneInDetails(string workPhone)
        //{
        //    if (workPhone == null || workPhone == "")
        //    {
        //        return "";
        //    }
        //    return "W: " + workPhone + "\r\n";
        //}

        //private string CleanUpMobilePhoneInDetails(string mobilePhone)
        //{
        //    if (mobilePhone == null || mobilePhone == "")
        //    {
        //        return "";
        //    }
        //    return "M: " + mobilePhone + "\r\n";
        //}

        //private string CleanUpHomePhoneInDetails(string homePhone)
        //{
        //    if (homePhone == null || homePhone == "")
        //    {
        //        return "";
        //    }
        //    return "H: " + homePhone + "\r\n";
        //}
    }
}

