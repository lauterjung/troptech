using System;

namespace A16
{
    class Program
    {
        // 0) Todos os códigos
        // ctrl + shift + f para ajeitar a identação
        // apagar excesso de espaços
        // blocos de {}
        // variáveis tipadas

        // 1) 
        // Console.WriteLine() introdutório
        // p: score
        // r: resposta
        // i: tentativa
        // n1: randomInt1
        // n2: randomInt2

        // 2)
        // correção do método Main()
        // mudança do nome de variáveis:
        // t: numeroTabuada
        // in para inicio
        // f para fim

        // 3) 
        // iniciar como double ao invés de castar depois
        // remoção comentários
        // troca de todas os nomes de variáveis
        // castar filho fora do loop
        // agrupar variáveis e writelines()

        // 4)
        // at: alturaTriangulo
        // bt: baseTriangulo
        // a: area
        static void Main(string[] args)
        {
            // Ex 1
            var score = 0;
            while (score < 10)
            {
                Console.WriteLine("Pratique a tabuada!");
                for (int tentativa = 0; tentativa < 10; tentativa++)
                {
                    int randomInt1 = new Random().Next(1, 10);
                    int randomInt2 = new Random().Next(1, 10);

                    Console.WriteLine(randomInt1 + " x " + randomInt2 + "? ");
                    int resposta = Convert.ToInt32(Console.ReadLine());

                    if (resposta == randomInt1 * randomInt2)
                    {
                        Console.WriteLine("Resposta Correta!");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Incorreto!!! A resposta é: {randomInt1 * randomInt2}");
                    }
                }
                Console.WriteLine("Sua pontuação é: " + score + "/10");

                if (score == 10)
                {
                    Console.WriteLine("Parabéns, você sabe a tabuada decor e salteado!");
                }
                else
                {
                    Console.WriteLine("Você precisa estudar mais! Vamos tentar novamente!");
                }
            }


            // Ex 2
            Console.WriteLine("Descubra a tabuada!");
            Console.Write("Qual tabuada você gostaria de consultar (1 a 10): ");
            var numeroTabuada = Convert.ToInt32(Console.ReadLine());

            Console.Write("Qual é o número de inicio: ");
            int inicio = Convert.ToInt32(Console.ReadLine());

            Console.Write("Qual é o número de fim: ");
            int fim = Convert.ToInt32(Console.ReadLine());

            if (numeroTabuada > 10 || numeroTabuada < 1)
            {
                Console.WriteLine("Valor inválido, tente novamente.");
                return;
            }

            for (int i = inicio; i <= fim; i++)
            {
                Console.WriteLine(numeroTabuada + " x " + i + " = " + i * numeroTabuada);
            }

            // Ex 3
            int numeroFilhos = 0;
            double salario = 0;
            int quantidadePessoas = 0;
            double somaSalario = 0;
            double maiorSalario = 0;
            int quantidadePessoasMenorQueCem = 0;
            double totalFilhos = 0;
            double mediaSalarioPopulacao = 0;
            double percentualPessoasComSalarioAte100 = 0;
            double mediaNumeroFilhos = 0;

            while (salario >= 0)
            {
                Console.Write("Salário: ");
                salario = Convert.ToDouble(Console.ReadLine());

                if (salario >= 0)
                {
                    Console.Write("Quantidade de filhos: ");
                    numeroFilhos = Convert.ToInt32(Console.ReadLine());

                    somaSalario += salario;
                    totalFilhos += numeroFilhos;
                    quantidadePessoas++;

                    if (salario > maiorSalario)
                    {
                        maiorSalario = salario;
                    }

                    if (salario <= 100)
                    {
                        quantidadePessoasMenorQueCem++;
                    }

                }
            }
            mediaSalarioPopulacao = somaSalario / quantidadePessoas;
            percentualPessoasComSalarioAte100 = (quantidadePessoasMenorQueCem * 100) / quantidadePessoas;
            mediaNumeroFilhos = totalFilhos / quantidadePessoas;

            Console.WriteLine("Média salarial da população: R$" + mediaSalarioPopulacao);
            Console.WriteLine("Média número de filhos: " + mediaNumeroFilhos);
            Console.WriteLine("Maior salário: " + maiorSalario);
            Console.WriteLine("Percentual de pessoas com salário até R$100,00: " + percentualPessoasComSalarioAte100 + "%");

            // Ex 4
            Console.Write("Digite a medida em cm da base do triângulo: ");
            var baseTriangulo = Convert.ToDouble(Console.ReadLine());
            Console.Write("Digite a medida em cm da altura do triângulo: ");
            var alturaTriangulo = Convert.ToDouble(Console.ReadLine());

            var area = (baseTriangulo * alturaTriangulo) / 2;
            Console.WriteLine("A área do triângulo é: " + area);
        }
    }
}
