namespace A13E5
{
    public class Student
    {
        private ulong _registration;
        public ulong Registration
        {
            get { return _registration; }
            set { _registration = value; }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private static ulong _counter = 1;

        public Student(string name)
        {
            _name = name;
            _registration = _counter++;
        }



    }
}