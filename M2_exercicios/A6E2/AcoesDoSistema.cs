using System.Collections.Generic;

namespace A6
{
    public static class AcoesDoSistema
    {
        private static Turma _turma = new Turma ("Turma 1");
        private static string _userInput = "";
        public static void ChamarMenu()
        {
            Console.Clear();
            Console.WriteLine("===================");
            Console.WriteLine("1) Cadastrar aluno");
            Console.WriteLine("2) Listar alunos");
            Console.WriteLine("3) Sair");
            Console.WriteLine("===================\n");
        }
        public static void PedirInput()
        {
            Console.Write("Digite a opção desejada: ");
            _userInput = Console.ReadLine();
        }
        public static void RealizarEscolha()
        {
            switch (_userInput)
            {
                case "1":
                    CadastrarAluno();
                    break;
                case "2":
                    MostrarTodos();
                    break;
                case "3":
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Não entendi a operação. Pressione enter para continuar...");
                    Console.ReadKey();
                    break;
            }
            Console.ReadKey();
        }

        public static void CadastrarAluno()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();
            Console.Write("Digite a matrícula: ");
            int matricula = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a nota da prova: ");
            int notaDaProva = Convert.ToInt32(Console.ReadLine());

            Aluno aluno = new Aluno(nome, matricula, notaDaProva);
            _turma.AdicionarAluno(aluno);

            Console.WriteLine("Usuário cadastrado com sucesso!");
        }

        public static void MostrarTodos()
        {
            Console.WriteLine("Lista de alunos cadastrados:");
            foreach (Aluno element in _turma.ListaAlunos)
            {
                element.Imprimir();
            }
            Console.WriteLine($"Média da turma: {_turma.CalcularMedia()}");
        }

        public static void RodarPrograma()
        {
            while (true)
            {
                ChamarMenu();
                PedirInput();
                RealizarEscolha();
            }
        }
    }
}