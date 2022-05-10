using System;

namespace primeiro_projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultado = media >= 7 ? "Aprovado" : "Reprovado";
			
			Console.Clear();
        }
    }
}

Úteis no Console

cls -> utilize para limpar o console
dotnet new console -> utilizar para criar um novo projeto na última versão do .net instalada na sua máquina
dotnet new console --framework net5.0 -> utilize para criar um novo projeto na versão 5.0 quando existir uma versão mais nova instalada na máquina
cd {caminho de uma pasta} --> utilize para ir para alguma pasta no cmd
code -> utilize para abrir o code na pasta que está o cmd
dotnet run -> utilize para rodar o projeto
ctrl + k + c -> para comentar um código
ctrl + k + u -> para descomentar um código 
[21:09] Prof. Anna Laura: 🎬conteúdos Mais uma dica de atalhos, dessa vez do @Gabriel Henrique Almeida Ludwig. 

ALT + SHIFT + F -> Use para identar o código 

Console.CursorLeft

internalConsole - > “integratedTerminal”.

int[] x; // pode armazenar valores inteiros
string[] s; // pode armazenar valores em texto
double[] d; // pode armazenar valores numéricos com virgula
Student[] stud1; // pode armazenar objetos de classes


// Two-dimensional array.
int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
// The same array with dimensions specified.
int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
// A similar array with string elements.
string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };

// Three-dimensional array.
int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                 { { 7, 8, 9 }, { 10, 11, 12 } } };
// The same array with dimensions specified.
int[,,] array3Da = new int[2, 2, 3] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                       { { 7, 8, 9 }, { 10, 11, 12 } } };