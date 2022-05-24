using System;
using System.Collections;

namespace A24
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ex 1
            DateTime dateInput = DateTime.Now;
            Console.WriteLine(dateInput.Day);
            Console.WriteLine(dateInput.Month);
            Console.WriteLine(dateInput.Year);
            Console.WriteLine(dateInput.ToShortDateString());
            Console.WriteLine(dateInput.ToLongDateString());

            Console.WriteLine(dateInput.Hour);
            Console.WriteLine(dateInput.Minute);
            Console.WriteLine(dateInput.Second);
            Console.WriteLine(dateInput.ToShortTimeString());
            Console.WriteLine(dateInput.ToLongTimeString());

            // Ex 2
            string dateInputEx2 = "";
            string[] strlist = new string[3];
            int[] intlist = new int[3];

            Console.Write("Entre com a data: ");
            dateInputEx2 = Console.ReadLine();
            strlist = dateInputEx2.Split("/");

            for (int i = 0; i < strlist.Length; i++)
            {
                intlist[i] = Convert.ToInt32(strlist[i]);
                Console.WriteLine(intlist[i]);
            }

            DateTime dateResultEx2 = new DateTime(intlist[2], intlist[1], intlist[0]);

            Console.WriteLine(dateResultEx2.AddDays(7));
            Console.WriteLine(dateResultEx2.AddDays(-15));
            Console.WriteLine(dateResultEx2.AddMonths(2));
            Console.WriteLine(dateResultEx2.AddYears(-40));

            // Ex 3
            string[] strlistEx3 = new string[7];

            DateTime dateInputEx3 = DateTime.Now;

            for (int i = 0; i < strlistEx3.Length; i++)
            {
                strlistEx3[i] = dateInputEx3.AddDays(i).ToLongDateString();
                Console.WriteLine(strlistEx3[i]);
            }

            // Ex 4
            DateTime dateInputEx4 = DateTime.Now;

            if (dateInputEx4.Hour < 12)
                Console.WriteLine($"Bom dia -> Data: {dateInputEx4.ToShortDateString()}" +
                $"Hora {dateInputEx4.ToShortTimeString()}!");
            else if (dateInputEx4.Hour < 18)
                Console.WriteLine($"Boa tarde -> Data: {dateInputEx4.ToShortDateString()}" +
                $"Hora {dateInputEx4.ToShortTimeString()}!");
            else
                Console.WriteLine($"Boa noite -> Data: {dateInputEx4.ToShortDateString()}" +
                $"Hora {dateInputEx4.ToShortTimeString()}!");

            // Ex 5
            string userInput = "";
            bool running = true;
            DateTime dateInputEx5 = DateTime.Now;
            Queue timeRegister = new Queue();

            while (running)
            {
                Console.WriteLine("Digite (E) para registrar a entrada e (S) para registrar a saída:");
                userInput = Console.ReadLine();



                switch (userInput)
                {
                    case "E":
                        dateInputEx5 = DateTime.Now;
                        timeRegister.Enqueue($"Entrada registrada: {dateInputEx5.ToShortTimeString()}");
                        break;
                    case "S":
                        dateInputEx5 = DateTime.Now;
                        timeRegister.Enqueue($"Entrada registrada: {dateInputEx5.ToShortTimeString()}");
                        break;
                    case "Q":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Não entendi o comando.");
                        break;
                }
            }

            foreach (var element in timeRegister)
            {
                Console.WriteLine(element);
            }


        }
    }
}
