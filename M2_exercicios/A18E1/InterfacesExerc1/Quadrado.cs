using System;
using System.Collections;

namespace InterfacesExerc1
{
    public class Quadrado : IAreaCalculavel
    {
        private double _lado;

        public Quadrado(double lado)
        {
            if (lado == 0)
                throw new System.Exception("Não é possível criar quadrado com lado igual a zero.");

            if (lado < 0)
                throw new System.Exception("Não é possível criar quadrado com lado negativo.");

            _lado = lado;
        }

        public double CalculaArea()
        {
            return Math.Round(_lado * _lado, 2);
        }
    }
}