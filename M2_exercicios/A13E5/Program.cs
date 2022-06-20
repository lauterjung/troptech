using System;
using System.Collections.Generic;

namespace A13E5
{
    class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course("Troptech");
            Candidate candidate1 = new Candidate ("Miguel");
            Candidate candidate2 = new Candidate ("Miguel2");
            candidate1.Enroll(course);
            candidate2.Enroll(course);

            foreach (Student item in course.Students)
            {
                System.Console.WriteLine($"Registro: {item.Registration} - Nome: {item.Name}.");
            }
        }
    }
}

