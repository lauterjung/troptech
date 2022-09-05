using System;
using System.Collections.Generic;

namespace A7
{
    class Program
    {
        static void Main(string[] args)
        {
            Agenda agenda = new Agenda();

            while (true)
            {
                Console.Write("Digite o nome: ");
                string name = Console.ReadLine();
                if (name.ToLower() == "encerrar")
                {
                    break;
                }
                Console.Write("Digite o telefone: ");
                string phoneNumber = Console.ReadLine();

                Contact contact = new Contact(name, phoneNumber);
                agenda.AddContact(contact);
            }
            Console.Write("Digite o nome a ser pesquisado: ");
            string searchName = Console.ReadLine();

            if (agenda.SearchContact(searchName) == true)
            {
                Console.WriteLine("A agenda contém o contato.");
            }
            else
            {
                Console.WriteLine("A agenda não contém o contato.");
            }

            Console.Write("Digite o nome a ser removido: ");
            string removeName = Console.ReadLine();

            agenda.RemoveContact(removeName);

            agenda.ShowAll();
            System.Console.WriteLine("Ordenando lista...");
            List<string> sortedList = new List<string>();
            sortedList = agenda.GetSortedNames();
            foreach (string element in sortedList)
            {
                System.Console.WriteLine(element);
            }
        }
    }
}
