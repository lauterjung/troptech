namespace A7
{
    public class Contact
    {
        private string _name;
        private string _phoneNumber;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public Contact(string name, string phoneNumber)
        {
            _name = name;
            _phoneNumber = phoneNumber;
        }
        public Contact()
        {
            
        }
    }
}