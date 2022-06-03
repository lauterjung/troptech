using System;
using System.Collections.Generic;

namespace A8
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal cachorro = new Animal();
            cachorro.Nome = "Bibi";
            cachorro.Dono = "Carlos";
            cachorro.Categoria = Animal.CategoriaAnimal.Cachorro;

            Animal gato = new Animal();
            gato.Nome = "Tomilho";
            gato.Dono = "Anna";
            gato.Categoria = Animal.CategoriaAnimal.Cachorro;

            Animal tartaruga = new Animal();
            tartaruga.Nome = "Clotilde";
            tartaruga.Dono = "Andre";
            tartaruga.Categoria = Animal.CategoriaAnimal.Cachorro;

            Animal peixe = new Animal();
            peixe.Nome = "Nemo";
            peixe.Dono = "Elias";
            peixe.Categoria = Animal.CategoriaAnimal.Peixe;
        }
    }
}
