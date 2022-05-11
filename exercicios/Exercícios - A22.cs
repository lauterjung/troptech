using System;
using System.Collections.Generic;

namespace A22
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ex 1
            LinkedList<string> listaVinculadaEx1;
            listaVinculadaEx1 = new LinkedList<string>();

            listaVinculadaEx1.AddLast("João");
            listaVinculadaEx1.AddLast("Pedro");
            listaVinculadaEx1.AddLast("Maria");
            listaVinculadaEx1.AddLast("Lucas");
            listaVinculadaEx1.AddLast("Marcia");

            listaVinculadaEx1.RemoveFirst();
            listaVinculadaEx1.RemoveLast();

            for (var node = listaVinculadaEx1.Last; node != null; node = node.Previous)
            {
                Console.WriteLine(node.Value);
            }
            Console.WriteLine($"Total de nomes = {listaVinculadaEx1.Count}");

            // Ex 2
            // Nota: a solução do gabarito é mais interessante.
            LinkedList<string> listaVinculadaEx2;
            listaVinculadaEx2 = new LinkedList<string>();
            LinkedList<string> listaVinculadaOrdenadaEx2;
            listaVinculadaOrdenadaEx2 = new LinkedList<string>();

            listaVinculadaEx2.AddLast("Quarta");
            listaVinculadaEx2.AddLast("Segunda");
            listaVinculadaEx2.AddLast("Sábado");
            listaVinculadaEx2.AddLast("Quinta");
            listaVinculadaEx2.AddLast("Terça");
            listaVinculadaEx2.AddLast("Domingo");
            listaVinculadaEx2.AddLast("Sexta");

            for (int i = 0; i < listaVinculadaEx2.Count; i++)
            {
                for (var node = listaVinculadaEx2.First; node != null; node = node.Next)
                {
                    if (i == 0 && node.Value == "Domingo")
                    {
                        listaVinculadaOrdenadaEx2.AddLast(node.Value);
                        Console.WriteLine(node.Value);
                    }
                    if (i == 1 && node.Value == "Segunda")
                    {
                        listaVinculadaOrdenadaEx2.AddLast(node.Value);
                        Console.WriteLine(node.Value);
                    }
                    if (i == 2 && node.Value == "Terça")
                    {
                        listaVinculadaOrdenadaEx2.AddLast(node.Value);
                        Console.WriteLine(node.Value);
                    }
                    if (i == 3 && node.Value == "Quarta")
                    {
                        listaVinculadaOrdenadaEx2.AddLast(node.Value);
                        Console.WriteLine(node.Value);
                    }
                    if (i == 4 && node.Value == "Quinta")
                    {
                        listaVinculadaOrdenadaEx2.AddLast(node.Value);
                        Console.WriteLine(node.Value);
                    }
                    if (i == 5 && node.Value == "Sexta")
                    {
                        listaVinculadaOrdenadaEx2.AddLast(node.Value);
                        Console.WriteLine(node.Value);
                    }
                    if (i == 6 && node.Value == "Sábado")
                    {
                        listaVinculadaOrdenadaEx2.AddLast(node.Value);
                        Console.WriteLine(node.Value);
                    }

                }
            }

            // Ex 3
            LinkedList<int> listaVinculadaEx3;
            listaVinculadaEx3 = new LinkedList<int>();
            LinkedList<int> listaVinculadaOrdenadaEx3;
            listaVinculadaOrdenadaEx3 = new LinkedList<int>();
            int number = 0;
            int auxNumber = 0;

            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Insira o número {i}: ");
                number = Convert.ToInt32(Console.ReadLine());
                listaVinculadaEx3.AddLast(number);
            }

            for (var node = listaVinculadaEx3.First; node != null; node = node.Next)
            {
                if (node.Previous == null)
                {
                    listaVinculadaOrdenadaEx3.AddLast(node.Value);
                    auxNumber = node.Value;
                    continue;
                }

                LinkedListNode<int> referenceNode = listaVinculadaOrdenadaEx3.Find(auxNumber);
                if (node.Value <= referenceNode.Value)
                {
                    listaVinculadaOrdenadaEx3.AddBefore(referenceNode, node.Value);
                }
                else
                {
                    listaVinculadaOrdenadaEx3.AddAfter(referenceNode, node.Value);
                }
                auxNumber = node.Value;
            }
            for (var node = listaVinculadaOrdenadaEx3.First; node != null; node = node.Next)
            {
                Console.WriteLine(node.Value);
            }

            // Ex 4
            const string errorMsg = "Erro! Lista vazia.";
            const string menu =
                "MENU\n" + 
                "0- Sair\n" +
                "1- Cadastrar um produto no início\n" +
                "2- Cadastrar um produto no final\n" +
                "3- Cadastrar um produto no meio\n" +
                "4- Remover o primeiro produto\n" +
                "5- Remover o último produto\n" +
                "6- Remover um produto pelo seu nome\n" +
                "7- Limpar a lista de produtos";

            string menuOption = "";
            LinkedList<string> listaVinculadaEx4;
            listaVinculadaEx4 = new LinkedList<string>();
            string product = "";

            while (true)
            {
                Console.WriteLine(menu);
                menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "0":
                        Console.WriteLine("Até a próxima!");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                        break;

                    case "1":
                        Console.WriteLine("Qual o nome do produto?");
                        product = Console.ReadLine();
                        listaVinculadaEx4.AddFirst(product);
                        break;

                    case "2":
                        Console.WriteLine("Qual o nome do produto?");
                        product = Console.ReadLine();
                        listaVinculadaEx4.AddLast(product);
                        break;

                    case "3":
                        if (listaVinculadaEx4.Count == 0)
                        {
                            Console.WriteLine(errorMsg);
                            break;
                        }
                        Console.WriteLine("Qual o nome do produto?");
                        product = Console.ReadLine();
                        LinkedListNode<string> firstItem = listaVinculadaEx4.First;
                        listaVinculadaEx4.AddAfter(firstItem, product);
                        break;

                    case "4":
                        if (listaVinculadaEx4.Count == 0)
                        {
                            Console.WriteLine(errorMsg);
                            break;
                        }
                        listaVinculadaEx4.RemoveFirst();
                        break;

                    case "5":
                        if (listaVinculadaEx4.Count == 0)
                        {
                            Console.WriteLine(errorMsg);
                            break;
                        }
                        listaVinculadaEx4.RemoveLast();
                        break;

                    case "6":
                        if (listaVinculadaEx4.Count == 0)
                        {
                            Console.WriteLine(errorMsg);
                            break;
                        }
                        Console.WriteLine("Qual o nome do produto?");
                        product = Console.ReadLine();
                        LinkedListNode<string> searchItem = listaVinculadaEx4.Find(product);
                        if (searchItem == null)
                        {
                            Console.WriteLine("Produto não encontrado.");
                            break;
                        }
                        listaVinculadaEx4.Remove(searchItem);
                        break;

                    case "7":
                        if (listaVinculadaEx4.Count == 0)
                        {
                            Console.WriteLine(errorMsg);
                            break;
                        }
                        listaVinculadaEx4.Clear();
                        break;

                    default:
                        Console.WriteLine("Não entendi o comando. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        continue;
                }

                Console.WriteLine($"Contagem: {listaVinculadaEx4.Count}");
            }

        }
    }
}

