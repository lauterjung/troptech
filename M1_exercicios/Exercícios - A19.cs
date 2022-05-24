using System;

namespace Aula19
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ex 1
            Console.Write("Entre com a sua senha: ");
            string password = Console.ReadLine();
            char[] charArray = password.ToCharArray();
            int countUpper = 0;
            int countLower = 0;
            int countNumbers = 0;
            int countSpecial = 0;

            for (int i = 0; i < charArray.Length; i++)
            {
                if(Char.IsUpper(charArray[i]))
                {
                    countUpper ++;
                }
                if(Char.IsLower(charArray[i]))
                {
                    countLower ++;
                }
                if(Char.IsDigit(charArray[i]))
                {
                    countNumbers ++;
                }
                if(!Char.IsLetterOrDigit(charArray[i]))
                {
                    countSpecial++;
                }
            }

            Console.WriteLine($"Letras maiúsculas: {countUpper}");
            Console.WriteLine($"Letras minúsculas: {countLower}");
            Console.WriteLine($"Números: {countNumbers}");
            Console.WriteLine($"Caracteres especiais: {countSpecial}");
            
            // Ex 2
            Console.Write("Entre com uma frase: ");
            string frase2 = Console.ReadLine();
            Console.WriteLine(frase2.ToUpper());

            // Ex 3
            Console.Write("Entre com uma frase: ");
            string frase3 = Console.ReadLine();
            string[] palavras = frase3.Split(' ');
            Console.WriteLine($"Número de palavras: {palavras.Length}");

            // Ex 4
            string[] palavras4 = { "Olá", "bem-vindo", "programador"};

            Console.Write("Entre com uma frase: ");
            string frase4 = Console.ReadLine();
            string[] stringArray4 = frase4.Split(' ');
            int count4 = 0;

            for (int i = 0; i < palavras4.Length; i++)
            {
                for (int j = 0; j < stringArray4.Length; j++)
                {
                    if (stringArray4[j].Contains(palavras4[i]))
                    {
                    count4++;
                    }
                }
            }
            Console.WriteLine($"{count4} palavras.");
        }
    }
}
