using System;

namespace InterfacesExerc1
{
    public class Circulo : IAreaCalculavel
    {
        private double _raio;

        public Circulo(double raio)
        {
            if (raio < 0)
                throw new Exception("Não é possível criar círculo com raio negativo.");
            if (raio == 0)
                throw new Exception("Não é possível criar círculo com raio zerado.");
            _raio = raio;
        }

        public double CalculaArea()
        {
            var area = Math.PI * Math.Pow(_raio, 2);
            return Math.Round(area, 2);
        }
    }
}