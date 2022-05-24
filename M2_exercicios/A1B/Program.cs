using System;

namespace A1B
{
    class Program
    {
        static void Main(string[] args)
        {
            Pets[] pets = new Pets[5];
            
            for (int i = 0; i < pets.Length; i++)
            {
                Console.Write("Informe o nome: ");
                string name = Console.ReadLine();
                Console.Write("Informe o tipo: ");
                string type = Console.ReadLine();
                Pets pet = new Pets(name, type);
                pets[i] = pet;
            }

            for (int i = 0; i < pets.Length; i++)
            {
                Console.WriteLine($"Nome: {pets[i].Name}, Tipo: {pets[i].Type}");
            }
            Console.WriteLine($"Nº de cachorros: {Pets.nOfDogs}");
            Console.WriteLine($"Nº de gatos: {Pets.nOfCats}");
            Console.WriteLine($"Nº de peixes: {Pets.nOfFishes}");
        }
    }
}
