using System;
using System.Collections.Generic;
using MercadoSeuZe.ClassLib;

namespace MercadoSeuZe
{
    public static class ClientActions
    {
        private static string _userInput;
        private static ClientDAO _clientDAO = new ClientDAO();

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("[1] Cadastrar Cliente");
            Console.WriteLine("[2] Editar Cliente");
            Console.WriteLine("[3] Deletar Cliente");
            Console.WriteLine("[4] Buscar todos os Clientes");
            Console.WriteLine("[5] Buscar Cliente por nome");
            Console.WriteLine("[6] Buscar Cliente por CPF");
            Console.WriteLine("[0] Voltar");
            Console.WriteLine("============================\n");
        }

        public static void AskForInput()
        {
            Console.Write("Digite a opção desejada: ");
            _userInput = Console.ReadLine();
        }

        public static void ChooseOption()
        {
            Console.Clear();
            switch (_userInput)
            {
                case "1":
                    AddClient();
                    break;
                case "2":
                    UpdateClient();
                    break;
                case "3":
                    DeleteClient();
                    break;
                case "4":
                    SearchAllClients();
                    break;
                case "5":
                    SearchClientByName();
                    break;
                case "6":
                    SearchClientById();
                    break;
                case "0":
                    return;
                    break;
                default:
                    Console.WriteLine("Operação inválida. Pressione enter para continuar...");
                    break;
            }
            Console.ReadKey();
        }

        public static void AddClient()
        {
            System.Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine();
            System.Console.Write("Digite o nome: ");
            string name = Console.ReadLine();
            System.Console.Write("Digite a data de nascimento (AAAA-MM-DD): ");
            DateTime birthDate = Convert.ToDateTime(Console.ReadLine());
            System.Console.Write("Digite a rua: ");
            string street = Console.ReadLine();
            System.Console.Write("Digite o número da casa: ");
            int houseNumber = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Digite o bairro: ");
            string borough = Console.ReadLine();
            System.Console.Write("Digite o CEP: ");
            string postalCode = Console.ReadLine();
            System.Console.Write("Digite o complemento (pode ser vazio): ");
            string complement = Console.ReadLine();

            Address newAddress = new Address(street, houseNumber, borough, postalCode, complement);
            Client newClient = new Client(cpf, name, birthDate, newAddress);

            _clientDAO.AddClient(newClient);
            System.Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        public static void UpdateClient()
        {
            System.Console.Write("Qual o CPF do cliente a ser atualizado? ");
            string cpf = Console.ReadLine();

            Client searchedClient = _clientDAO.ViewClientByCpf(cpf);
            if (searchedClient.Cpf == "") /////// VERIFICAR!!!
            {
                System.Console.WriteLine("Cliente não encontrado! Pressione qualquer tecla para continuar...");
                return;
            }

            System.Console.WriteLine(searchedClient.ToString());

            if (ConfirmAction(cpf))
            {
                System.Console.Write("Digite o CPF: ");
                string newCpf = Console.ReadLine();
                System.Console.Write("Digite o nome: ");
                string name = Console.ReadLine();
                System.Console.Write("Digite a data de nascimento (AAAA-MM-DD): ");
                DateTime birthDate = Convert.ToDateTime(Console.ReadLine());
                System.Console.Write("Digite a rua: ");
                string street = Console.ReadLine();
                System.Console.Write("Digite o número da casa: ");
                int houseNumber = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Digite o bairro: ");
                string borough = Console.ReadLine();
                System.Console.Write("Digite o CEP: ");
                string postalCode = Console.ReadLine();
                System.Console.Write("Digite o complemento (pode ser vazio): ");
                string complement = Console.ReadLine();

                Address modifiedAddress = new Address(street, houseNumber, borough, postalCode, complement);
                Client modifiedClient = new Client(cpf, name, birthDate, modifiedAddress);

                _clientDAO.UpdateClient(modifiedClient);
                System.Console.WriteLine("Cliente alterado com sucesso!");
            }
        }

        public static void DeleteClient()
        {
            System.Console.Write("Qual o CPF do cliente a ser deletado? ");
            string cpf = Console.ReadLine();

            Client searchedClient = _clientDAO.ViewClientByCpf(cpf);
            if (searchedClient.Cpf == "") ////// VERIFICAR!!!
            {
                System.Console.WriteLine("Produto não encontrado! Pressione qualquer tecla para continuar...");
                return;
            }

            System.Console.WriteLine(searchedClient.ToString());

            if (ConfirmAction(cpf))
            {
                _clientDAO.DeleteFromClientssById(searchedClient);
                System.Console.WriteLine("Cliente deletado com sucesso!");
            }
        }

        public static void SearchAllClients()
        {
            List<Client> clientList = new List<Client>();
            clientList = _clientDAO.ViewAllClients();

            foreach (Client client in clientList)
            {
                System.Console.WriteLine(client.ToString());
            }
        }

        public static void SearchClientByName()
        {
            System.Console.Write("Qual o nome do cliente a ser buscado? ");
            string name = Console.ReadLine();

            List<Client> clientList = _clientDAO.ViewClientByName(name);

            foreach (Client client in clientList)
            {
                System.Console.WriteLine(client.ToString());
            }
        }

        public static void SearchClientById()
        {
            System.Console.Write("Qual o CPF do cliente a ser buscado? ");
            string cpf = Console.ReadLine();

            Client searchedClient = _clientDAO.ViewClientByCpf(cpf);
            System.Console.WriteLine(searchedClient.ToString());
        }

        public static bool ConfirmAction(string cpf)
        {
            bool answer = false;
            System.Console.Write("Digite 'S' caso você realmente deseja alterar/deletar esse cliente ");
            string inputString = Console.ReadLine();
            if (inputString == "S")
            {
                answer = true;
            }
            return answer;
        }

        public static void Run()
        {
            while (_userInput != "0")
            {
                Menu();
                AskForInput();
                ChooseOption();
            }
            _userInput = "";
        }
    }
}
