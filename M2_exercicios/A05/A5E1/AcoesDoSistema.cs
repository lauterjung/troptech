using System.Collections.Generic;

namespace A5
{
    public static class AcoesDoSistema
    {
        private static string _userInput = "";
        private static List<Cliente> _listaClientes = new List<Cliente>();
        public static void ChamarMenu()
        {
            Console.Clear();
            Console.WriteLine("===================");
            Console.WriteLine("1) Cadastrar cliente");
            Console.WriteLine("2) Listar clientes");
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
            Console.Write("Digite a rua: ");
            string rua = Console.ReadLine();
            Console.Write("Digite o bairro: ");
            string bairro = Console.ReadLine();
            Console.Write("Digite o número: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a cidade: ");
            string cidade = Console.ReadLine();
            Console.Write("Digite o estado: ");
            string estado = Console.ReadLine();

            Endereco endereco = new Endereco(rua, bairro, numero, cidade, estado);
            Cliente cliente = new Cliente(nome, idade, endereco);
            _listaClientes.Add(cliente);

            Console.WriteLine("Usuário cadastrado com sucesso!");
        }


        public static void MostrarTodos()
        {
            foreach (Cliente element in _listaClientes)
            {
                Console.WriteLine($"{element.Nome} - {element.EnderecoPessoal.Cidade}");
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