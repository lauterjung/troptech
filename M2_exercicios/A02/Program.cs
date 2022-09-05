using System;

namespace A2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Informe a base: ");
            // double userBase = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Informe a altura: ");
            // double userHeight = Convert.ToDouble(Console.ReadLine());
            // Rectangle rect = new Rectangle(userBase, userHeight);
            // Console.WriteLine($"Area: {rect.Area}");

            Console.Write("Informe o dia: ");
            int userDay = Convert.ToInt32(Console.ReadLine());
            Console.Write("Informe o mês: ");
            int userMonth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Informe o ano: ");
            int userYear = Convert.ToInt32(Console.ReadLine());

            Data date = new Data(userDay, userMonth, userYear);

            Console.Write("Informe o nº de dias a serem adicionados: ");
            date.DaysToAdd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Informe o nº de meses a serem adicionados: ");
            date.MonthsToAdd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Informe o nº de anos a serem adicionados: ");
            date.YearsToAdd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{date.CompleteDate}");


        }
    }
}
