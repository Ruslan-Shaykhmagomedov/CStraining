using System;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;
        //private string lastname;
        private string nickname = "";
        private string company = "";
        private string address = "";
        private string email = "";
        private string bday = "";
        private string bmonth = "";  
        private int byear;  

        public ContactData (string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            //this.lastname = lastname;
        }
        public string FirstName
        {
            get
            { return firstname; }
            set
            { firstname = value; }
        }
        public string LastName
        {
            get 
            { return lastname; }
            set 
            { lastname = value; }
        }
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
            return FirstName + LastName;
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
        //public string Lastname
        //{
        //    get
        //    { return lastname; }
        //    set 
        //    { lastname = value; }
        //}
        public string NickName
        {
            get
                { return nickname; }
            set
                { nickname = value; }
        }
        public string Company
        {
            get 
            { return company; }
            set 
            { company = value; }
        }
        public string Address
        {
            get 
            { return address; }
            set 
            { address = value; }    
        }
        public string Email
        {
            get 
            { return email; }
            set 
            { email = value; }
        }
        public string Bday
        {
            get 
            { return bday; }
            set 
            { bday = value; }
        }
        public string Bmonth
        {
            get
            { return bmonth; }
            set
            { bmonth = value; }
        }
        public int Byear
        {
            get
            { return byear; }
            set
            { byear = value; }
        }
    }
}
