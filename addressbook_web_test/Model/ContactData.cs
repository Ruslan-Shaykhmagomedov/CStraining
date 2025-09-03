using System;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData (string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
            //MiddleName = middlename;
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
        //public string MiddleName {get; set;}
        public string NickName {  get; set; }
        public string Company {  get; set; }
        public string Address {  get; set; }
        public string Email {  get; set; }
        public string Bday {  get; set; }
        public string Bmonth {  get; set; }
        public int Byear { get; set; }
    }
}
