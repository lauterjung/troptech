namespace A13E5
{
    public class Course
    {
        private ulong _registration;
        public ulong Registration
        {
            get { return _registration; }
            set { _registration = value; }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private List<Student> _students;
        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }
        public Course(string title)
        {
            _title = title;
            _students = new List<Student>();
        }

        public void RegisterStudent(Student student)
        {
            _students.Add(student);
        }

    }
}