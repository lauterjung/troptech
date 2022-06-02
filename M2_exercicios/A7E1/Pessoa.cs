namespace A7
{
    public class Pessoa
    {
        private string _name;
        private string _title;
        private int _yearOfBirth;
        private int _age;
        private string _cellphone;

        public string Name
        {
            get
            {
                if (String.IsNullOrEmpty(_name))
                {
                    return "";
                }
                return (_title + " " + _name);
            }
            set
            {
                if (value.Split(" ").Length >= 2)
                {
                    _name = value;
                }
            }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public int YearOfBirth
        {
            get { return _yearOfBirth; }
            set { _yearOfBirth = value; }
        }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - _yearOfBirth;
            }
        }
        public string Cellphone
        {
            get { return _cellphone; }
            set { _cellphone = value; }
        }

        public Pessoa()
        {

        }
        public void PrintData()
        {
            Console.WriteLine($"{Name}, idade {Age} anos. Contato: {Cellphone}");
        }
    }
}