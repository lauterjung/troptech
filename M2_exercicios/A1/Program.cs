using System;
using System.Collections.Generic;

namespace A1
{
    class Program
    {
        static void Main(string[] args)
        {
            // ItemDaAgenda[] itens = new ItemDaAgenda[2];
            LinkedList<ItemDaAgenda> listaVinculada = new LinkedList<ItemDaAgenda>();

            while (true)
            {
                Console.Write("Informe o nome: ");
                string name = Console.ReadLine();
                Console.Write("Informe o telefone: ");
                string phoneNumber = Console.ReadLine();
                ItemDaAgenda itemAgenda = new ItemDaAgenda(name, phoneNumber);
                Console.Write("Informe o endereço: ");
                itemAgenda.Address = Console.ReadLine();
                Console.Write("Informe a profissão: ");
                itemAgenda.Job = Console.ReadLine();
                // itens[i] = itemAgenda;
                listaVinculada.AddLast(itemAgenda);
                Console.WriteLine($"Nº itens cadastrados: {ItemDaAgenda.ItemCount}");
                Console.WriteLine("Deseja inserir novo item?");
                string newItem = Console.ReadLine();
                if (newItem.ToLower() == "s")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            // for (int i = 0; i < ItemDaAgenda.ItemCount; i++)
            // {
            //     Console.Write($"{itens[i].Name}, Tel. {itens[i].PhoneNumber}, End. {itens[i].Address}, Profissão {itens[i].Job}");
            //     Console.WriteLine();
            // }

            foreach (ItemDaAgenda item in listaVinculada)
            {
                Console.Write($"{item.Name}, Tel. {item.PhoneNumber}, End. {item.Address}, Profissão {item.Job}");
                Console.WriteLine();
            }

        }
    }
}
