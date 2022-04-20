using System;

namespace primeiro_projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            // ex 1
            string var1 = "2";
            string var2 = "5";
            Console.WriteLine(Convert.ToInt64(var1) + int.Parse(var2));

            // ex 2
            // Console.WriteLine("Digite uma fruta:");
            // string fruta = Console.ReadLine();
            // Console.WriteLine("Digite a cor da fruta:");
            // string cor = Console.ReadLine();
            // Console.WriteLine("Digite sua característica:");
            // string caracteristica = Console.ReadLine();
            // // forma 1
            // Console.WriteLine($"{fruta} é uma fruta {cor} e {caracteristica}");
            // // forma 2
            // string formatString = String.Format("{0} é uma fruta {1} e {2}", fruta, cor, caracteristica);
            // Console.WriteLine(formatString);

            // ex 3
            int numeroInteiro = 1;
            decimal numeroDecimal = 2.5m;
            string numeroEmString = "7";
            double numeroDouble = 3.7;

            decimal deInteiroParaDecimal = Convert.ToDecimal(numeroInteiro);
            int deDecimalParaInteiro = Convert.ToInt32(numeroDecimal);
            int deStringParaInteiro = Convert.ToInt32(numeroEmString);
            decimal deStringParaDecimal = Convert.ToDecimal(numeroEmString);
            decimal deDoubleParaDecimal = Convert.ToDecimal(numeroDouble);
            
            Console.WriteLine(deInteiroParaDecimal);
            Console.WriteLine(deDecimalParaInteiro);
            Console.WriteLine(deStringParaInteiro);
            Console.WriteLine(deStringParaDecimal);
            Console.WriteLine(deDoubleParaDecimal);

            // ex 4
            Console.WriteLine("Informe o símbolo:");
            string symbolString = Console.ReadLine();
            char symbolChar = Convert.ToChar(symbolString);
            // maneira 1
            Console.WriteLine(String.Format("      {0}      ", symbolChar));
            Console.WriteLine(String.Format("     {0}{0}{0}     ", symbolChar));
            Console.WriteLine(String.Format("    {0}{0}{0}{0}{0}    ", symbolChar));
            Console.WriteLine(String.Format("   {0}{0}{0}{0}{0}{0}{0}   ", symbolChar));
            Console.WriteLine(String.Format("  {0}{0}{0}{0}{0}{0}{0}{0}{0}  ", symbolChar));
            Console.WriteLine(String.Format(" {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0} ", symbolChar));
            Console.WriteLine(String.Format("{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", symbolChar));
            // maneira 2
            char s = symbolChar;
            Console.WriteLine($"      {s}      ");
            Console.WriteLine($"     {s}{s}{s}     ");
            Console.WriteLine($"    {s}{s}{s}{s}{s}    ");
            Console.WriteLine($"   {s}{s}{s}{s}{s}{s}{s}   ");
            Console.WriteLine($"  {s}{s}{s}{s}{s}{s}{s}{s}{s}  ");
            Console.WriteLine($" {s}{s}{s}{s}{s}{s}{s}{s}{s}{s}{s} ");
            Console.WriteLine($"{s}{s}{s}{s}{s}{s}{s}{s}{s}{s}{s}{s}{s}");
        }
    }
}
