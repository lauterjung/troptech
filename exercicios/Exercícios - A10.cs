using System;

namespace primeiro_projeto
{
    class Program
    {
        static void Main(string[] args)
        {
			// ex 1
            Console.WriteLine("      *      ");
            Console.WriteLine("     ***     ");
            Console.WriteLine("    *****    ");
            Console.WriteLine("   *******   ");
            Console.WriteLine("  *********  ");
            Console.WriteLine(" *********** ");
            Console.WriteLine("*************");

            Console.WriteLine("");
			
			// ex 2
            Console.WriteLine("      *      \n     ***     \n    *****    \n   *******   \n  *********  \n *********** \n*************");
			
			// ex 3
			Console.WriteLine("Qual é o seu nome?");
            string nome = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Olá " + nome);
			
			// ex 4
			Console.Write("**********   ");
            Console.Write("      **     **      \n");
            Console.Write("**********   ");
            Console.Write("      **     **      \n");
            Console.Write("**           ");
            Console.Write("*********************\n");
            Console.Write("**           ");
            Console.Write("*********************\n");
            Console.Write("**           ");
            Console.Write("      **     **      \n");
            Console.Write("**           ");
            Console.Write("*********************\n");
            Console.Write("**           ");
            Console.Write("*********************\n");
            Console.Write("**********   ");
            Console.Write("      **     **      \n");
            Console.Write("**********   ");
            Console.Write("      **     **      \n");
			
			// ex 5
			Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**********   ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("      **     **      \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**********   ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("      **     **      \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**           ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("*********************\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**           ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("*********************\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**           ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("      **     **      \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**           ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("*********************\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**           ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("*********************\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**********   ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("      **     **      \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**********   ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("      **     **      \n");
            Console.ForegroundColor = ConsoleColor.White;
			
			// ex 6
			Console.WriteLine("Qual é o nome da rua?");
            string rua = Console.ReadLine();
            Console.WriteLine("Qual é o bairro?");
            string bairro = Console.ReadLine();
            Console.WriteLine("Qual é a cidade?");
            string cidade = Console.ReadLine();
            Console.WriteLine("Qual é o número da casa?");
            string numero = Console.ReadLine();
            Console.WriteLine("Rua: " + rua);
            Console.WriteLine("Bairro: " + bairro);
            Console.WriteLine("Cidade: " + cidade);
            Console.WriteLine("Número da casa: " + numero);
        }
    }
}
