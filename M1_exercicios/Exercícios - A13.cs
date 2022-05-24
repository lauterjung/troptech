using System;

namespace primeiro_projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            // ex 1
            Console.WriteLine("Informe o código:");
            string codigo = Console.ReadLine();
            string classificacaoEx1 = "";
            if(codigo == "1")
            {
                classificacaoEx1 = "Alimento não-perecível";
            }
            else if(codigo == "2" || codigo == "3" || codigo == "4")
            {
                classificacaoEx1 = "Alimento perecível";
            }
            else if(codigo == "5" || codigo == "6")
            {
                classificacaoEx1 = "Vestuário";
            }
            else if(codigo == "7")
            {
                classificacaoEx1 = "Higiene pessoal";
            }
            else if(codigo == "8" || codigo == "9" || codigo == "10")
            {
                classificacaoEx1 = "Utensílios domésticos";
            }
            else
            {
                Console.WriteLine("Não entendi o código do produto!");
                Environment.Exit(1);
            }
            Console.WriteLine($"A classficiação do produto é {classificacaoEx1}.");

            // ex 2
            Console.WriteLine("Informe o código:");
            string codigoEx2 = Console.ReadLine();
            string classificacaoEx2 = "";
            switch (codigoEx2)
            {
                case "1":
                    classificacaoEx2 = "Alimento não-perecível";
                    break;
                case "2":
                case "3":
                case "4":
                    classificacaoEx2 = "Alimento perecível";
                    break;
                case "5":
                case "6":
                    classificacaoEx2 = "Vestuário";
                    break;
                case "7":
                    classificacaoEx2 = "Higiene pessoal";
                    break;
                case "8":
                case "9":
                case "10":
                    classificacaoEx2 = "Utensílios domésticos";
                    break;
                default:
                    Console.WriteLine("Não entendi o código do produto!");
                    Environment.Exit(1);
                    break;
            }
            Console.WriteLine($"A classficiação do produto é {classificacaoEx2}.");

            // // ex 3
            Console.WriteLine("Qual o preço do produto?");
            double preco = Convert.ToDouble(Console.ReadLine());
            string metodoPagamento = "";
            double totalPagamento = 0;
            Console.WriteLine("Qual o código do produto?");
            string codigoEx3 = Console.ReadLine();

            switch (codigoEx3)
            {
                case "1":
                    metodoPagamento = "À vista em dinheiro ou cheque, com 10% de desconto";
                    totalPagamento = preco * 0.9;
                    break;
                case "2":
                    metodoPagamento = "À vista com cartão de crédito, com 5% de desconto";
                    totalPagamento = preco * 0.95;
                    break;
                case "3":
                    metodoPagamento = "Em 2 vezes, preço normal de etiqueta sem juros";
                    totalPagamento = preco;
                    break;
                case "4":
                    metodoPagamento = "Em 3 vezes, preço de etiqueta com acréscimo de 10%";
                    totalPagamento = preco * 1.1;
                    break;
                default:
                    Console.WriteLine("Não entendi o código do produto!");
                    Environment.Exit(1);
                    break;
            }
            Console.WriteLine($"Você escolheu pagar {metodoPagamento}.");
            Console.WriteLine(String.Format("Você deverá pagar R${0:0.00}.",totalPagamento));

            // ex 4
            Console.WriteLine("Qual a idade do trabalhador?");
            int idade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Qual o tempo de serviço do trabalhador?");
            int tempoServico = Convert.ToInt32(Console.ReadLine());
            if(idade >= 65 || tempoServico >= 30 || (idade >= 60 || tempoServico >= 25))
            {
                Console.WriteLine("Ele pode se aposentar.");
            }
            else
            {
                Console.WriteLine("Ele NÃO pode se aposentar.");
            }
        }
    }
}
