using System;

namespace primeiro_projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            // ex 1
            Console.Write("Digite um número: ");
            int numeroTabuadaEx1 = Convert.ToInt32(Console.ReadLine());
            if(numeroTabuadaEx1 < 1 || numeroTabuadaEx1 > 10){
                Console.WriteLine("Número inválido. Tente novamente.");
                return;
            }
            for(int i = 1; i <= 10; i++) {
                Console.WriteLine($"{numeroTabuadaEx1} x {i} = {numeroTabuadaEx1*i}");
            }

            // ex 2
            Console.Write("Digite um número: ");
            int numeroTabuadaEx2 = Convert.ToInt32(Console.ReadLine());
            if(numeroTabuadaEx2 < 1 || numeroTabuadaEx2 > 10){
                Console.WriteLine("Número inválido. Tente novamente.");
                return;
            }

            Console.Write("Digite o início: ");
            int inicio = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o final: ");
            int fim = Convert.ToInt32(Console.ReadLine());
            if(fim < inicio){
                Console.WriteLine("Número inválido. Tente novamente.");
                return;
            }

            for(int i = inicio; i <= fim; i++) {
                Console.WriteLine($"{numeroTabuadaEx2} x {i} = {numeroTabuadaEx2*i}");
            }

            // ex 3
            int menor = 0;
            int maior = 0;
            for(int i = 1; i <= 5; i++) {
                Console.Write("Digite um número: ");
                int numeroAtual = Convert.ToInt32(Console.ReadLine());
                if (i == 1){
                    menor = numeroAtual;
                    maior = numeroAtual;
                }

                if(numeroAtual >= maior){
                    maior = numeroAtual;
                }
                if(numeroAtual <= menor){
                    menor = numeroAtual;
                }
            }
            Console.WriteLine($"O menor número foi {menor} e o maior número foi {maior}.");

            // ex 4
            double contagem = 0;
            double salario = 0;
            double totalSalario = 0;
            double totalFilhos = 0;
            double contagemMenorCem = 0;
            double maiorSalario = 0;
            Console.WriteLine("Para encerrar o programa, entre um salário negativo.");

            while(salario >= 0) {
                Console.Write("Informe o salário: ");
                salario = Convert.ToDouble(Console.ReadLine());
                
                if(salario < 0) {
                    break;
                }

                Console.Write("Informe o número de filhos: ");
                int numeroFilhos = Convert.ToInt32(Console.ReadLine());

                if(salario > maiorSalario){
                    maiorSalario = salario;
                }
                if(salario < 100){
                    contagemMenorCem++;
                }

                totalSalario = totalSalario + salario;
                totalFilhos = totalFilhos + numeroFilhos;
                contagem++;
            }

            Console.WriteLine("INFORMAÇÕES");
            Console.WriteLine(String.Format("a) Média do salário da população: R${0:0.00}.", totalSalario/contagem));
            Console.WriteLine(String.Format("b) Média do número de filhos: {0:0.00}.",totalFilhos/contagem));
            Console.WriteLine(String.Format("c) Maior salário: R${0:0.00}.", maiorSalario));
            Console.WriteLine(String.Format("d) Percentual de pessoas com salário até R$100,00: {0:0.00}%.", contagemMenorCem/contagem*100));
        
            // ex 5
            Console.WriteLine("Digite um número: ");
            int numeroAsteriscos = Convert.ToInt32(Console.ReadLine());
            if(numeroAsteriscos < 5){
                Console.WriteLine("Número inválido. Tente novamente.");
                return;
            }

            for(int i = 1; i <= numeroAsteriscos-1; i++) {
                for(int j = numeroAsteriscos-1; j >= i; j--){
                    Console.Write(" ");
                }
                Console.Write("*");
                for(int k = 1; k <= i-1; k++){
                    Console.Write("*");
                    Console.Write("*");
                }
                Console.WriteLine("");                    
            }
        }
    }
}
