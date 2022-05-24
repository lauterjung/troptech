using System;

namespace A21
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ex 1
            int nPeople = 10 + 1;
            int nColumns = 3;
            string[,] agenda = new string[nPeople, nColumns];
            agenda[0, 0] = "Nome";
            agenda[0, 1] = "Endereço";
            agenda[0, 2] = "Profissao";

            for (int i = 1; i < nPeople; i++)
            {
                Console.Write($"Insira o nome da pessoa {i}: ");
                agenda[i, 0] = Console.ReadLine();
                Console.Write($"Insira o endereço da pessoa {i}: ");
                agenda[i, 1] = Console.ReadLine();
                Console.Write($"Insira a profissão da pessoa {i}: ");
                agenda[i, 2] = Console.ReadLine();
            }

            for (int i = 0; i < nPeople; i++)
            {
                int posCursor = 0;
                for (int j = 0; j < nColumns; j++)
                { 
                    Console.CursorLeft = posCursor;
                    Console.Write($"{agenda[i, j]}");
                    posCursor += 20;
                }
                Console.WriteLine();
            }

            // Ex 2
            int nLinesEx2 = 3;
            int nColumnsEx2 = 6;
            int[,] matrixEx2 = new int[nLinesEx2, nColumnsEx2];

            for (int i = 0; i < nLinesEx2; i++)
            {
                for (int j = 0; j < nColumnsEx2; j++)
                {
                    Console.Write($"Insira o número da linha {i + 1} coluna {j + 1}: ");
                    matrixEx2[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < nLinesEx2; i++)
            {
                for (int j = 0; j < nColumnsEx2; j++)
                {
                    Console.Write($"{matrixEx2[i, j]}\t");
                }
                Console.WriteLine();
            }

            // a)
            int sumOdds = 0;
            for (int i = 0; i < nLinesEx2; i++)
            {
                for (int j = 0; j < nColumnsEx2; j += 2)
                {
                    sumOdds += matrixEx2[i, j];
                }
            }
            Console.WriteLine($"A soma dos elementos das colunas ímpares é {sumOdds}.");

            // b)
            int countCol1and3 = 0;
            int sumCol1and3 = 0;

            for (int j = 1; j < 4; j += 2)
            {
                for (int i = 0; i < nLinesEx2; i++)
                {
                    sumCol1and3 += matrixEx2[i, j];
                    countCol1and3 += 1;
                }
            }
            Console.WriteLine($"A média dos elementos das colunas 1 e 3 é {sumOdds / countCol1and3}.");

            // c)
            int[] vectorSum = new int[3];
            int countEx2c = 0;

            for (int j = 0; j < nColumnsEx2; j++)
            {
                for (int i = 0; i < nLinesEx2; i++)
                {
                    if ((j == 0) || (j == 2))
                    {
                        vectorSum[i] += matrixEx2[i, j];
                        countEx2c++;
                    }

                    if (j == 5)
                    {
                        matrixEx2[i, j] = vectorSum[i];
                    }
                }
            }

            // d)
            for (int i = 0; i < nLinesEx2; i++)
            {
                for (int j = 0; j < nColumnsEx2; j++)
                {
                    Console.Write($"{matrixEx2[i, j]}\t");
                }
                Console.WriteLine();
            }

            // Ex 3
            int nLinesEx3 = 4;
            int nColumnsEx3 = 4;
            int somaEx3 = 0;
            int[,] matrix1Ex3 = new int[nLinesEx3, nColumnsEx3];
            int[,] matrix2Ex3 = new int[nLinesEx3, nColumnsEx3];

            for (int i = 0; i < nLinesEx3; i++)
            {
                for (int j = 0; j < nColumnsEx3; j++)
                {
                    Console.Write($"MATRIZ 1 - Insira o número da linha {i + 1} coluna {j + 1}: ");
                    matrix1Ex3[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < nLinesEx3; i++)
            {
                for (int j = 0; j < nColumnsEx3; j++)
                {
                    Console.Write($"MATRIZ 2 - Insira o número da linha {i + 1} coluna {j + 1}: ");
                    matrix2Ex3[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < nLinesEx3; i++)
            {
                for (int j = 0; j < nColumnsEx3; j++)
                {
                    somaEx3 = matrix1Ex3[i,j] + matrix2Ex3[i,j];
                    Console.Write($"{matrix1Ex3[i,j]} + {matrix2Ex3[i,j]} = {somaEx3}\t");
                }
                Console.WriteLine();
            }

            // Ex 4
            int nLinesEx4 = 4;
            int nColumnsEx4 = 4;
            int minEx4 = 0;
            int maxEx4 = 0;
            int[,] matrixEx4 = new int[nLinesEx4, nColumnsEx4];

            for (int i = 0; i < nLinesEx4; i++)
            {
                for (int j = 0; j < nColumnsEx4; j++)
                {
                    Console.Write($"Insira o número da linha {i + 1} coluna {j + 1}: ");
                    matrixEx4[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < nLinesEx4; i++)
            {
                for (int j = 0; j < nColumnsEx4; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        minEx4 = matrixEx4[i, j];
                        maxEx4 = matrixEx4[i, j];
                    }

                    if (matrixEx4[i, j] < minEx4)
                    {
                        minEx4 = matrixEx4[i, j];
                    }

                    if (matrixEx4[i, j] > maxEx4)
                    {
                        maxEx4 = matrixEx4[i, j];
                    }
                }
            }

            Console.WriteLine($"O menor número foi {minEx4}.");
            Console.WriteLine($"O maior número foi {maxEx4}.");

        }
    }
}
