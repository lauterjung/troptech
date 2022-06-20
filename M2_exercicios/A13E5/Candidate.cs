namespace A13E5
{
    public class Candidate
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private byte _score;
        public byte Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public Candidate(string name)
        {
            _name = name;
        }

        public bool Enroll(Course course)
        {
            Student student = new Student(_name);
            course.RegisterStudent(student);
            return true;
        }

    }
}