using System.Collections.Generic;

namespace A5
{
    public static class AcoesDoSistema
    {
        private static string _userInput = "";
        private static List<Aluno> _listaAlunos = new List<Aluno>();
        private static List<Professor> _listaProfessores = new List<Professor>();
        public static void ChamarMenu()
        {
            Console.Clear();
            Console.WriteLine("===================");
            Console.WriteLine("1) Cadastrar aluno");
            Console.WriteLine("2) Cadastrar professor");
            Console.WriteLine("3) Listar alunos e professores");
            Console.WriteLine("4) Sair");
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
                    CadastrarProfessor();
                    break;
                case "3":
                    MostrarTodos();
                    break;
                case "4":
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
            Console.Write("Digite a idade: ");
            int idade = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a turma: ");
            string turma = Console.ReadLine();

            Console.Write("Digite o cep: ");
            string cep = Console.ReadLine();
            Console.Write("Digite o número: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o complemento: ");
            string complemento = Console.ReadLine();

            Endereco endereco = new Endereco(cep, numero, complemento);
            Aluno aluno = new Aluno(nome, idade, turma, endereco);
            _listaAlunos.Add(aluno);

            Console.WriteLine("Usuário cadastrado com sucesso!");
        }
        public static void CadastrarProfessor()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();
            Console.Write("Digite a matéria: ");
            string materia = Console.ReadLine();
            Console.Write("Digite o cpf: ");
            string cpf = Console.ReadLine();

            Console.Write("Digite o cep: ");
            string cep = Console.ReadLine();
            Console.Write("Digite o número: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o complemento: ");
            string complemento = Console.ReadLine();

            Endereco endereco = new Endereco(cep, numero, complemento);
            Professor professor = new Professor(nome, materia, cpf, endereco);
            _listaProfessores.Add(professor);

            Console.WriteLine("Usuário cadastrado com sucesso!");
        }

        public static void MostrarTodos()
        {
            Console.WriteLine("Lista de alunos cadastrados:");
            foreach (Aluno element in _listaAlunos)
            {
                element.Imprimir();
            }
            Console.WriteLine("\nLista de professores cadastrados:");
            foreach (Professor element in _listaProfessores)
            {
                element.Imprimir();
            }
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