using System;
using System.Collections.Generic;
using System.Numerics;

namespace A12
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IAreaCalculavel> lista = new List<IAreaCalculavel>();
            Quadrado quadrado = new Quadrado(5);
            Retangulo retangulo = new Retangulo(5, 10);
            Circulo circulo = new Circulo(5);

            lista.Add(quadrado);
            lista.Add(retangulo);
            lista.Add(circulo);

            foreach (IAreaCalculavel item in lista)
            {
                System.Console.WriteLine(item.CalcularArea());
            }
        }
    }
}
