using System;

namespace Calculadora
{
    public static class Operacoes
    {
        public static double Dividir(double x, double y)
        {
            if (y == 0)
                throw new Exception("Não é possível dividir por zero");
            return Math.Round(x / y, 2);
        }

        public static double Multiplicar(double x, double y)
        {
            return Math.Round(x * y, 2);
        }
    }
}