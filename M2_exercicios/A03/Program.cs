using System;

namespace A3
{
    class Program
    {
        static void Main(string[] args)
        {
            //ex 1
            Console.Write("Digite a nota 1: ");
            double grade1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Digite a nota 2: ");
            double grade2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Digite a nota 3: ");
            double grade3 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Deseja arredondar? ");
            string? needRound = Console.ReadLine();

            if (needRound == "s")
            {
                bool round = true;
                Console.WriteLine(Grades.CalculateAverageGrade(grade1, grade2, grade3, round));

            }
            else
            {
                Console.WriteLine(Grades.CalculateAverageGrade(grade1, grade2, grade3));
            }

            // ex 2
            Console.Write("Qual o número de dias? ");
            int numberOfDays = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{numberOfDays} dia(s) tem {Converter.DayToHours(numberOfDays)} horas.");
            Console.WriteLine($"{numberOfDays} dia(s) tem {Converter.DayToMinutes(numberOfDays)} minutos.");
            Console.WriteLine($"{numberOfDays} dia(s) tem {Converter.DayToSeconds(numberOfDays)} segundos.");

            // ex 3
            Rectangle rect = new Rectangle();
            Console.WriteLine(rect.Base);
            Console.WriteLine(rect.Height);
            rect.CalculateArea();

            rect.Base = 4;
            rect.Height = 5;
            Console.WriteLine(rect.Base);
            Console.WriteLine(rect.Height);
            rect.CalculateArea();

            Rectangle rect2 = new Rectangle(2, 3);
            rect2.CalculateArea();

            // ex 4
            Person person = new Person();
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Weight);
            Console.WriteLine(person.Height);
            Console.WriteLine(person.Gender);
            person.CalculateImc();

            person.Name = "Miguel";
            person.Weight = 82;
            person.Height = 1.84;
            person.Gender = "Male";

            Console.WriteLine(person.Name);
            Console.WriteLine(person.Weight);
            Console.WriteLine(person.Height);
            Console.WriteLine(person.Gender);
            person.CalculateImc();

            Person person2 = new Person("Miguel", 82.0, 1.84, "Male");
            person2.CalculateImc();
        }
    }
}