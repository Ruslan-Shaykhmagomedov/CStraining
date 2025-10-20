using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        string allPhones;
        private string allNames;
        private string textInDetails;
        public ContactData()
        {
        }
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
        [Column(Name ="firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "id"),PrimaryKey,Identity]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }
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
            // List for not empty phones
            var phones = new List<string>();

            // Check and add home phone
            if (!string.IsNullOrEmpty(homePhone))
            {
                phones.Add("H: " + homePhone);
            }

            // Check and add mobile phone
            if (!string.IsNullOrEmpty(mobilePhone))
            {
                phones.Add("M: " + mobilePhone);
            }

            // Check and add workphone
            if (!string.IsNullOrEmpty(workPhone))
            {
                phones.Add("W: " + workPhone);
            }

            // If there are phones, return with actions (\r\n)
            if (phones.Count > 0)
            {
                return string.Join("\r\n", phones) + "\r\n\r\n";
            }

            // If there is no phone, return empty string
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
        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts/*.Where(x => x.Deprecated == "0000-00-00 00:00:00")*/ select c).ToList(); // if there was this condition
            }

        }
    }
}

