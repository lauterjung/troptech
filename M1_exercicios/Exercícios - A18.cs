using System;

namespace Aula18
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ex 1
            int higherIndex = 0;
            int higherNumber = 0;

            Console.WriteLine("Qual o tamanho do vetor?");
            int vectorSizeEx1 = Convert.ToInt32(Console.ReadLine());
            int[] vectorInt = new int[vectorSizeEx1];

            for (int i = 0; i < vectorSizeEx1; i++)
            {
                Console.Write($"Digite o número {i + 1}: ");
                vectorInt[i] = Convert.ToInt32(Console.ReadLine());

                if (i == 0)
                {
                    higherNumber = vectorInt[i];
                }
                else
                {
                    if (vectorInt[i] > higherNumber)
                    {
                        higherNumber = vectorInt[i];
                        higherIndex = i;
                    }
                }
            }
            Console.WriteLine($"O maior número é {higherNumber} e está no índice {higherIndex}.");

            // Ex 2
            Console.WriteLine("Qual o tamanho do vetor?");
            int vectorSizeEx2 = Convert.ToInt32(Console.ReadLine());
            int[] vectorIntEx2 = new int[vectorSizeEx2];
            int count = 0;

            for (int i = 0; i < vectorSizeEx2; i++)
            {
                Console.Write($"Digite o número {i + 1}: ");
                vectorIntEx2[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine($"\nOs números pares são:");
            for (int i = 0; i < vectorSizeEx2; i++)
            {
                if(vectorIntEx2[i] % 2 == 0)
                {
                    Console.Write($"{vectorIntEx2[i]} ");
                    count++;
                }
            }
            Console.WriteLine($"\nA quantidade é: {count}");

            // Ex 3
            Console.WriteLine("Qual o tamanho do vetor?");
            int vectorSizeEx3 = Convert.ToInt32(Console.ReadLine());
            int[] vectorIntA = new int[vectorSizeEx3];
            int[] vectorIntB = new int[vectorSizeEx3];
            int[] vectorIntC = new int[vectorSizeEx3];

            for (int i = 0; i < vectorSizeEx3; i++)
            {
                Console.Write($"Digite o número {i + 1} do vetor A: ");
                vectorIntA[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < vectorSizeEx3; i++)
            {
                Console.Write($"Digite o número {i + 1} do vetor B: ");
                vectorIntB[i] = Convert.ToInt32(Console.ReadLine());
                vectorIntC[i] = vectorIntA[i] + vectorIntB[i];
            }

            Console.WriteLine("Os números do vetor C: ");
            for (int i = 0; i < vectorSizeEx3; i++)
            {
                Console.Write($"{vectorIntC[i]} ");
            }

            // Ex 4
            Console.WriteLine("Qual o tamanho do vetor?");
            int vectorSizeEx4 = Convert.ToInt32(Console.ReadLine());
            int[] vectorIntEx4 = new int[vectorSizeEx4];
            int sumElements = 0;
            double meanElements;

            for (int i = 0; i < vectorSizeEx4; i++)
            {
                Console.Write($"Digite o número {i + 1} do vetor A: ");
                vectorIntEx4[i] = Convert.ToInt32(Console.ReadLine());
                sumElements += vectorIntEx4[i];
            }

            meanElements = sumElements / vectorSizeEx4;
            Console.WriteLine($"A média aritimética é: {meanElements}");

            Console.WriteLine("Os números abaixo da média são: ");
            for (int i = 0; i < vectorSizeEx4; i++)
            {
                if (vectorIntEx4[i] < meanElements)
                {
                    Console.Write($"{vectorIntEx4[i]} ");
                }
            }

            // Ex 5
            Console.WriteLine("Qual o tamanho do vetor?");
            int vectorSize = Convert.ToInt32(Console.ReadLine());
            int[] vectorIntEx5 = new int[vectorSize];
            int sumEvenElements = 0;
            int countEven = 0;
            double meanEvenElements;

            for (int i = 0; i < vectorSize; i++)
            {
                Console.Write($"Digite o número {i + 1} do vetor A: ");
                vectorIntEx5[i] = Convert.ToInt32(Console.ReadLine());
                if (vectorIntEx5[i] % 2 == 0)
                {
                    sumEvenElements += vectorIntEx5[i];
                    countEven++;
                }
            }

            if (countEven > 0)
            {
                meanEvenElements = sumEvenElements / countEven;
                Console.WriteLine($"A média aritimética dos números pares é: {meanEvenElements}");
            }
            else
            {
                Console.WriteLine($"Sem números pares!");
            }
            
        }
    }
}
