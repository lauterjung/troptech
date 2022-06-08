using System;
using System.Collections.Generic;

namespace A10E1
{
    class Program
    {
        static void Main(string[] args)
        {
            var cardapio = new List<ItemDoCardapio>();
            cardapio.Add(new Bebida(1, "Coca-Cola", "Bebida gaseificada de cola", 4.50));
            cardapio.Add(new Comida(2, "X-Burguer", "Blend de carnes nobres com queijo cheddar e pão brioche", 10.00));

            foreach (ItemDoCardapio item in cardapio)
            {
                item.ImprimirDesconto();
            }
            foreach (ItemDoCardapio item in cardapio)
            {
                item.ImprimirDesconto2();
            }
        }
    }
}
