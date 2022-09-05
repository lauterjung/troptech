using System.Collections.Generic;

namespace A5
{
    public static class AcoesDoSistema
    {
        private static string _userInput = "";
        private static List<Paciente> _listaPacientes = new List<Paciente>();
        public static void ChamarMenu()
        {
            Console.Clear();
            Console.WriteLine("===================");
            Console.WriteLine("1) Cadastrar paciente");
            Console.WriteLine("2) Listar pacientes");
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
                    CadastrarCliente();
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

        public static void CadastrarCliente()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();
            Console.Write("Digite a idade: ");
            int idade = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o peso: ");
            double peso = Convert.ToDouble(Console.ReadLine());
            Console.Write("Digite a altura: ");
            double altura = Convert.ToDouble(Console.ReadLine());

            Imc imc = new Imc(peso, altura);
            Paciente paciente = new Paciente(nome, idade, imc);
            _listaPacientes.Add(paciente);

            Console.WriteLine("Usuário cadastrado com sucesso!");
        }

        public static void MostrarTodos()
        {
            foreach (Paciente element in _listaPacientes)
            {
                Console.WriteLine($"Paciente {element.Nome} - IMC: {element.ImcCalculado} - {element.CategoriaImc}");
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