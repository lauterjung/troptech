using System;

namespace Aula20
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ex 1
            Console.Write("Informe o número de trabalhadores: ");
            int nWorkers = Convert.ToInt32(Console.ReadLine());

            string[] names = new string[nWorkers];
            int[] age = new int[nWorkers];
            double[] timeWorked = new double[nWorkers];
            string[] retirementStatus = new string[nWorkers];
            Console.WriteLine("");

            for (int i = 0; i < nWorkers; i++)
            {
                Console.Clear();
                Console.Write($"Informe o nome do trabalhador {i + 1}: ");
                names[i] = Console.ReadLine();
                Console.Write($"Informe a idade do trabalhador {i + 1}: ");
                age[i] = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Informe o tempo trabalhado do trabalhador {i + 1}: ");
                timeWorked[i] = Convert.ToDouble(Console.ReadLine());

                if (age[i] >= 65 || timeWorked[i] >= 30 || (age[i] >= 60 && timeWorked[i] >= 25))
                {
                    retirementStatus[i] = "Sim";
                }
                else
                {
                    retirementStatus[i] = "Não";
                }
            }

            Console.Clear();
            Console.WriteLine("Nome\tIdade\tTempo\tSituação");
            Console.WriteLine("------\t------\t------\t------");
            for (int i = 0; i < nWorkers; i++)
            {
                Console.WriteLine($"{names[i]}\t{age[i]}\t{timeWorked[i]}\t{retirementStatus[i]}");
            }

            // Ex 2
            Console.Write("Informe o número de produtos: ");
            int nProducts = Convert.ToInt32(Console.ReadLine());

            string[] productNames = new string[nProducts];
            int[] productCodes = new int[nProducts];
            string[] productClassification = new string[nProducts];

            Console.WriteLine("");

            for (int i = 0; i < nProducts; i++)
            {
                Console.Clear();
                Console.Write($"Informe o nome do produto {i + 1}: ");
                productNames[i] = Console.ReadLine();
                Console.Write($"Informe o código do produto {i + 1}: ");
                productCodes[i] = Convert.ToInt32(Console.ReadLine());

                switch (productCodes[i])
                {
                    case 1:
                    productClassification[i] = "Alimento não-perecível";
                        break;
                    case 2:
                    case 3:
                    case 4:
                    productClassification[i] = "Alimento perecível";
                        break;
                    case 5:
                    case 6:
                    productClassification[i] = "Vestuário";
                        break;
                    case 7:
                    productClassification[i] = "Higiene pessoal";
                        break;
                    case 8:
                    case 9:
                    case 10:
                    productClassification[i] = "Utensílios domésticos";
                        break;
                    default:
                    productClassification[i] = "Código inválido";
                        break;
                }
            }

            Console.Clear();
            Console.Write("Nome do produto");
            Console.CursorLeft = 20;
            Console.WriteLine("Classificação");

            Console.Write("---------");
            Console.CursorLeft = 20;
            Console.WriteLine("---------");

            for (int i = 0; i < nProducts; i++)
            {
                Console.Write($"{productNames[i]}");
                Console.CursorLeft = 20;
                Console.WriteLine($"{productClassification[i]}");
            }

            // Ex 3
            Console.Write("Informe o número de produtos: ");
            int nProductsEx3 = Convert.ToInt32(Console.ReadLine());

            string[] productNamesEx3 = new string[nProductsEx3];
            double[] productPricesEx3 = new double[nProductsEx3];
            double[] paymentOption1 = new double[nProductsEx3];
            double[] paymentOption2 = new double[nProductsEx3];
            double[] paymentOption3 = new double[nProductsEx3];
            double[] paymentOption4 = new double[nProductsEx3];

            Console.WriteLine("");

            for (int i = 0; i < nProductsEx3; i++)
            {
                Console.Clear();
                Console.Write($"Informe o nome do produto {i + 1}: ");
                productNamesEx3[i] = Console.ReadLine();
                Console.Write($"Informe o preço do produto {i + 1}: ");
                productPricesEx3[i] = Convert.ToInt32(Console.ReadLine());
                paymentOption1[i] = productPricesEx3[i] * 0.9;
                paymentOption2[i] = productPricesEx3[i] * 0.95;
                paymentOption3[i] = productPricesEx3[i];
                paymentOption4[i] = productPricesEx3[i] * 1.1;
            }

            Console.Clear();
            Console.Write("Produto");
            Console.CursorLeft = 20;
            Console.Write("Preço");
            Console.CursorLeft = 30;
            Console.Write("Opção 1");
            Console.CursorLeft = 40;
            Console.Write("Opção 2");
            Console.CursorLeft = 50;
            Console.Write("Opção 3");
            Console.CursorLeft = 60;
            Console.WriteLine("Opção 4");

            Console.Write("--------");
            Console.CursorLeft = 20;
            Console.Write("--------");
            Console.CursorLeft = 30;
            Console.Write("--------");
            Console.CursorLeft = 40;
            Console.Write("--------");
            Console.CursorLeft = 50;
            Console.Write("--------");
            Console.CursorLeft = 60;
            Console.WriteLine("--------");

            for (int i = 0; i < nProductsEx3; i++)
            {
                Console.Write($"{productNamesEx3[i]}");
                Console.CursorLeft = 20;
                Console.Write(String.Format("R${0:0.00}", productPricesEx3[i]));
                Console.CursorLeft = 30;
                Console.Write(String.Format("R${0:0.00}", paymentOption1[i]));
                Console.CursorLeft = 40;
                Console.Write(String.Format("R${0:0.00}", paymentOption2[i]));
                Console.CursorLeft = 50;
                Console.Write(String.Format("R${0:0.00}", paymentOption3[i]));
                Console.CursorLeft = 60;
                Console.WriteLine(String.Format("R${0:0.00}", paymentOption4[i]));
            }

            // Ex 4
            int[] vector = new int[1];
            int size = 1;
            int number = 0;

            while (true)
            {
                Console.WriteLine("Informe um número: ");
                number = Convert.ToInt32(Console.ReadLine());

                if (size == vector.Length)
                {
                    int[] aux = new int[vector.Length * 2];

                    for (int i = 0; i < vector.Length; i++)
                        aux[i] = vector[i];

                    vector = aux;
                }

                vector[size] = number;
                size++;

                Console.WriteLine($"Tamanho: {vector.Length} - Números: {size}");
            }

        }
    }
}
