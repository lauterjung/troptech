using System;

namespace InterfacesExerc1
{
    public class Retangulo : IAreaCalculavel
    {
        private double _base;
        private double _altura;

        public Retangulo(double @base, double altura)
        {
            if (@base < 0)
                throw new System.Exception("Não é possível criar retângulo com base negativa.");
            if (@base == 0)
                throw new System.Exception("Não é possível criar retângulo com base zerada.");
            if (altura == 0)
                throw new System.Exception("Não é possível criar retângulo com altura zerada.");
            if (altura < 0)
                throw new System.Exception("Não é possível criar retângulo com altura negativa.");

            _base = @base;
            _altura = altura;
        }

        public double CalculaArea()
        {
            return Math.Round(_base * _altura, 2);
        }
    }
}