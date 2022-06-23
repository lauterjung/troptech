using System;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Dado que sou um usuário
            Quando solicitar operação de multiplicação
            E informar 2 para primeiro valor
            E informar 4 para segundo valor
            Deve apresentar o resultado 8
            */
            var multiplicacaoA = Operacoes.Multiplicar(2, 4);
            if (multiplicacaoA != 8)
                Console.WriteLine($"Caso de Teste A: O resultado deveria ser 8 mas é {multiplicacaoA}");
            else
                Console.WriteLine($"Caso de Teste A: OK");

            /*
            Dado que sou um usuário
            Quando solicitar operação de multiplicação
            E informar 0 para primeiro valor
            E informar 3 para segundo valor
            Deve apresentar o resultado 0
            */
            var multiplicacaoB = Operacoes.Multiplicar(0, 3);
            if (multiplicacaoB != 0)
                Console.WriteLine($"Caso de Teste B: O resultado deveria ser 0 mas é {multiplicacaoB}");
            else
                Console.WriteLine($"Caso de Teste B: OK");

            /*
            Dado que sou um usuário
            Quando solicitar operação de multiplicação
            E informar 7 para primeiro valor
            E informar 0 para segundo valor
            Deve apresentar o resultado 0
            */
            var multiplicacaoC = Operacoes.Multiplicar(7, 0);
            if (multiplicacaoC != 0)
                Console.WriteLine($"Caso de Teste C: O resultado deveria ser 0 mas é {multiplicacaoC}");
            else
                Console.WriteLine($"Caso de Teste C: OK");

            /*
            Dado que sou um usuário
            Quando solicitar operação de multiplicação
            E informar -7 para primeiro valor
            E informar 2 para segundo valor
            Deve apresentar o resultado -14
            */
            var multiplicacaoD = Operacoes.Multiplicar(-7, 2);
            if (multiplicacaoD != -14)
                Console.WriteLine($"Caso de Teste D: O resultado deveria ser -14 mas é {multiplicacaoD}");
            else
                Console.WriteLine($"Caso de Teste D: OK");

            /*
            Dado que sou um usuário
            Quando solicitar operação de multiplicação
            E informar -7 para primeiro valor
            E informar -2 para segundo valor
            Deve apresentar o resultado 14
            */
            var multiplicacaoE = Operacoes.Multiplicar(-7, -2);
            if (multiplicacaoE != 14)
                Console.WriteLine($"Caso de Teste E: O resultado deveria ser 14 mas é {multiplicacaoE}");
            else
                Console.WriteLine($"Caso de Teste E: OK");

            /*
            Dado que sou um usuário
            Quando solicitar operação de multiplicação
            E informar 7,37 para primeiro valor
            E informar 2,02 para segundo valor
            Deve apresentar o resultado 14,89
            */
            var multiplicacaoF = Operacoes.Multiplicar(7.37, 2.02);
            if (multiplicacaoF != 14.89)
                Console.WriteLine($"Caso de Teste F: O resultado deveria ser 14.89 mas é {multiplicacaoF}");
            else
                Console.WriteLine($"Caso de Teste F: OK");

            /*
            Dado que sou um usuário
            Quando solicitar operação de divisão
            E informar 10 para primeiro valor
            E informar 2 para segundo valor
            Deve apresentar o resultado 5
            */
            var divisaoG = Operacoes.Dividir(10, 2);
            if (divisaoG != 5)
                Console.WriteLine($"Caso de Teste G: O resultado deveria ser 5 mas é {divisaoG}");
            else
                Console.WriteLine($"Caso de Teste G: OK");

            /*
           Dado que sou um usuário
           Quando solicitar operação de divisão
           E informar 7 para primeiro valor
           E informar 2 para segundo valor
           Deve apresentar o resultado 3,5
           */
            var divisaoH = Operacoes.Dividir(7, 2);
            if (divisaoH != 3.5)
                Console.WriteLine($"Caso de Teste H: O resultado deveria ser 3.5 mas é {divisaoH}");
            else
                Console.WriteLine($"Caso de Teste H: OK");

            /*
            Dado que sou um usuário
            Quando solicitar operação de divisão
            E informar 8 para primeiro valor
            E informar 0 para segundo valor
            Deve apresentar um erro informando que não é possível realizar divisão por zero
            */
            try
            {
                var divisaoI = Operacoes.Dividir(8, 0);
                Console.WriteLine($"Caso de Teste I: Falhou, deveria ocorrer erro pois não é possível dividir por zero");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Não é possível dividir por zero")
                    Console.WriteLine($"Caso de Teste I: OK");
                else
                    Console.WriteLine($"Caso de Teste I: Falhou, esperava-se exceção de divisão por zero.");
            }

            /*
            Dado que sou um usuário
            Quando solicitar operação de divisão
            E informar 0 para primeiro valor
            E informar 8 para segundo valor
            Deve apresentar o resultado 0
            */
            var divisaoJ = Operacoes.Dividir(0, 8);
            if (divisaoJ != 0)
                Console.WriteLine($"Caso de Teste J: O resultado deveria ser 0 mas é {divisaoJ}");
            else
                Console.WriteLine($"Caso de Teste J: OK");

            /*
            Dado que sou um usuário
            Quando solicitar operação de divisão
            E informar 14,98 para primeiro valor
            E informar 3 para segundo valor
            Deve apresentar o resultado 4,99
            */
            var divisaoK = Operacoes.Dividir(14.98, 3);
            if (divisaoK != 4.99)
                Console.WriteLine($"Caso de Teste K: O resultado deveria ser 4.99 mas é {divisaoK}");
            else
                Console.WriteLine($"Caso de Teste K: OK");
        }
    }
}
