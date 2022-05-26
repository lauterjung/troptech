namespace A3
{
    public class Person
    {
        private string _name = "";
        private double _weight;
        private double _height;
        private string _gender = "";

        public string Name
        {
            get
            {
                return (_name);
            }
            set
            {
                _name = value;
            }
        }
        public double Weight
        {
            get
            {
                return (_weight);
            }
            set
            {
                _weight = value;
            }
        }
        public double Height
        {
            get
            {
                return (_height);
            }
            set
            {
                _height = value;
            }
        }
        public string Gender
        {
            get
            {
                return (_gender);
            }
            set
            {
                _gender = value;
            }
        }

        public Person(string name, double weight, double height, string gender)
        {
            _name = name;
            _weight = weight;
            _height = height;
            _gender = gender;
        }
        public Person()
        {

        }

        public void CalculateImc()
        {
            Console.WriteLine($"IMC = {_weight / (_height * _height)}");
        }
    }
}