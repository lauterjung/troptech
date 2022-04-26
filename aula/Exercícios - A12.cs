using System;

namespace primeiro_projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            // ex 1
            Console.WriteLine("Digite a variável 1:");
            decimal var1 = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Digite a variável 2:");
            decimal var2 = Convert.ToDecimal(Console.ReadLine());
            decimal soma = var1 + var2;
            decimal subtracao = var1 - var2;
            decimal multiplicacao = var1 * var2;
            decimal divisao = var1 / var2;
            Console.WriteLine($"{var1} + {var2} = {soma}");
            Console.WriteLine($"{var1} - {var2} = {subtracao}");
            Console.WriteLine($"{var1} * {var2} = {multiplicacao}");
            Console.WriteLine($"{var1} / {var2} = {divisao}");

            // ex 2
            Console.WriteLine("Qual o tamanho do lado do triângulo?");
            double lado = Convert.ToDouble(Console.ReadLine());
            double area = Math.Pow(lado, 2) * Math.Sqrt(3)/4;
            Console.WriteLine($"A área do triângulo é de {area} u²");

            // ex 3
            Console.WriteLine("Informe o tamanho do lado 1:");
            double lado1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Informe o tamanho do lado 2:");
            double lado2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Informe o tamanho do lado 3:");
            double lado3 = Convert.ToDouble(Console.ReadLine());
            bool equilatero = lado1 == lado2 && lado2 == lado3 && lado1 == lado3;
            bool escaleno = lado1 != lado2 && lado2 != lado3 && lado1 != lado3;
            bool isoceles = (lado1 == lado2 && lado1 != lado3) ||
                            (lado2 == lado3 && lado1 != lado2) ||
                            (lado1 == lado3 && lado1 != lado2);
            Console.WriteLine($"Equilátero: {equilatero}");
            Console.WriteLine($"Escaleno: {escaleno}");
            Console.WriteLine($"Isóceles: {isoceles}");

            // ex 4
            Console.WriteLine("Informe a sua idade:");
            int idade = Convert.ToInt16(Console.ReadLine());
            bool maiorDeIdade = idade >= 18;
            Console.WriteLine($"Maior de idade: {maiorDeIdade}");

            // ex 5
            Console.WriteLine("Informe um número:");
            int numero = Convert.ToInt16(Console.ReadLine());
            int numeroConvertido = 2 * numero;
            numeroConvertido++;
            Console.WriteLine($"O número convertido é: {numeroConvertido}");

            // ex 6
            Console.WriteLine("Digite um valor:");
            int var3 = Convert.ToInt16(Console.ReadLine());
            var soma2 = var3;
            var subtracao2 = var3;
            var multiplicacao2 = var3;
            var divisao2 = var3;

            Console.WriteLine($"{var3} + 2 = {soma2 += 2}");
            Console.WriteLine($"{var3} - 2 = {subtracao2 -= 2}");
            Console.WriteLine($"{var3} * 2 = {multiplicacao2 *= 2}");
            Console.WriteLine($"{var3} / 2 = {divisao2 /= 2}");
        }
    }
}
