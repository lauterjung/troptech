using System;
using System.Collections;
using System.Collections.Generic;

namespace A23
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ex 1
            // Poderia ter usado int direto que facilitaria, conforme gabarito
            Console.Write("Insira um número: ");
            double inputNumber = Convert.ToDouble(Console.ReadLine());
            Stack pile = new Stack();

            while (true)
            {
                pile.Push(inputNumber % 2);
                inputNumber /= 2;
                if (inputNumber == 0.5)
                {
                    break;
                }

                Convert.ToInt32(inputNumber);
                inputNumber = Convert.ToInt32(inputNumber);
            }

            foreach (double value in pile)
            {
                Console.Write(value);
            }

            // Ex 2
            Stack pileEx2 = new Stack();
            pileEx2.Push('T');
            pileEx2.Push(false);
            pileEx2.Push(true);
            pileEx2.Push("Trop");
            pileEx2.Push(7.6);
            pileEx2.Push(1);

            pileEx2.Pop();
            pileEx2.Pop();
            pileEx2.Pop();
            pileEx2.Push(1);
            pileEx2.Push(7.6);

            pileEx2.Push("Trop");
            foreach (var value in pileEx2)
            {
                Console.WriteLine(value);
            }

            // Ex 3
            string[] senhasBanco = { "P01", "S01", "S02", "P02", "S03", "S04", "S05", "P03" };
            Array.Sort(senhasBanco);

            Queue fila = new Queue();

            foreach (string value in senhasBanco)
            {
                if (value.StartsWith("P"))
                {
                    fila.Enqueue(value);
                }
            }

            foreach (string value in senhasBanco)
            {
                if (value.StartsWith("S"))
                {
                    fila.Enqueue(value);
                }
            }

            foreach (var value in fila)
            {
                Console.WriteLine(value);
            }

            // Ex 4
            Queue filaEx4 = new Queue();
            filaEx4.Enqueue('T');
            filaEx4.Enqueue(true);
            filaEx4.Enqueue(false);
            filaEx4.Enqueue("Trop");
            filaEx4.Enqueue(1);
            filaEx4.Enqueue(7.6);

            filaEx4.Dequeue();
            filaEx4.Dequeue();
            filaEx4.Dequeue();
            filaEx4.Enqueue(false);
            filaEx4.Enqueue('T');
            filaEx4.Enqueue(true);

            foreach (var value in filaEx4)
            {
                Console.WriteLine(value);
            }

            // Ex 5
            Queue passengersQueue = new Queue();
            Queue driversQueue = new Queue();
            Stack courseStack = new Stack();
            string answer = "";

            passengersQueue.Enqueue("A");
            passengersQueue.Enqueue("B");
            passengersQueue.Enqueue("C");
            passengersQueue.Enqueue("D");
            passengersQueue.Enqueue("E");

            driversQueue.Enqueue("A");
            driversQueue.Enqueue("B");
            driversQueue.Enqueue("C");
            driversQueue.Enqueue("D");
            driversQueue.Enqueue("E");

            foreach (var value in passengersQueue)
            {
                while (true)
                {
                    Console.WriteLine($"Motorista {driversQueue.Peek()}");
                    Console.WriteLine($"Você deseja levar o passageiro {value}?");
                    answer = Console.ReadLine();
                    if (answer == "S")
                    {
                        courseStack.Push($"Motorista {driversQueue.Peek()} -> Passageiro {value}");
                        driversQueue.Dequeue();
                        break;
                    }
                    else
                    {
                        driversQueue.Enqueue(driversQueue.Peek());
                        driversQueue.Dequeue();
                    }
                }

            }

            foreach (var value in courseStack)
            {
                Console.WriteLine(value);
            }
        }
    }
}

