
namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname = "";
        private string company = "";
        private string address = "";
        private string email = "";
        private string bday = "";
        private string bmonth = "";  
        private int byear;  

        public ContactData (string firstname, string middlename, string lastname)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
        }
        public string FirstName
        {
            get
            { return firstname; }
            set
            { firstname = value; }
        }
        public string MIddlename
        {
            get 
            { return middlename; }
            set 
            { middlename = value; }
        }
        public string Lastname
        {
            get
            { return lastname; }
            set 
            { lastname = value; }
        }
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
