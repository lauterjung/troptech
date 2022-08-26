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
            Console.WriteLine("======== CLIENTES =========");
            Console.WriteLine("[1] Cadastrar Cliente");
            Console.WriteLine("[2] Editar Cliente");
            Console.WriteLine("[3] Deletar Cliente");
            Console.WriteLine("[4] Buscar todos os Clientes");
            Console.WriteLine("[5] Buscar Cliente por nome");
            Console.WriteLine("[6] Buscar Cliente por CPF");
            Console.WriteLine("[0] Voltar");
            Console.WriteLine("============================\n");

            AskForInput();
        }

        public static void AskForInput()
        {
            Console.Write("Digite a opção desejada: ");
            _userInput = Console.ReadLine();

            ChooseOption();
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
                    _userInput = "";
                    SystemActions.Menu();
                    break;
                default:
                    Console.WriteLine("Operação inválida. Pressione enter para continuar...");
                    break;
            }
            Console.ReadKey();

            Menu();
        }

        public static Client AddClient()
        {
            Client nullClient = null;
            try
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
                return newClient;
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
            return nullClient;
        }

        public static void UpdateClient()
        {
            try
            {
                System.Console.Write("Qual o CPF do cliente a ser atualizado? ");
                string cpf = Console.ReadLine();

                Client searchedClient = _clientDAO.SearchClientByCpf(cpf);
                if (String.IsNullOrEmpty(searchedClient.Cpf))
                {
                    System.Console.WriteLine("Cliente não encontrado! Pressione qualquer tecla para continuar...");
                    return;
                }

                System.Console.WriteLine(searchedClient.ToString());

                if (ConfirmAction())
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
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void DeleteClient()
        {
            try
            {
                System.Console.Write("Qual o CPF do cliente a ser deletado? ");
                string cpf = Console.ReadLine();

                Client searchedClient = _clientDAO.SearchClientByCpf(cpf);
                if (String.IsNullOrEmpty(searchedClient.Cpf))
                {
                    System.Console.WriteLine("Cliente não encontrado! Pressione qualquer tecla para continuar...");
                    return;
                }

                System.Console.WriteLine(searchedClient.ToString());

                if (ConfirmAction())
                {
                    _clientDAO.DeleteClientById(searchedClient);
                    System.Console.WriteLine("Cliente deletado com sucesso!");
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Console.Clear();
                System.Console.WriteLine("O cliente possui pedidos! Primeiro remova os pedidos associados!");
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void SearchAllClients()
        {
            List<Client> clientList = new List<Client>();
            clientList = _clientDAO.SearchAllClients();
            Console.Clear();

            if (clientList.Count == 0)
            {
                System.Console.WriteLine("Nenhum cliente encontrado!");
                return;
            }

            foreach (Client client in clientList)
            {
                System.Console.WriteLine(client.ToString());
            }
        }

        public static void SearchClientByName()
        {
            System.Console.Write("Qual o nome do cliente a ser buscado? ");
            string name = Console.ReadLine();

            List<Client> clientList = _clientDAO.SearchClientsByName(name);
            Console.Clear();

            if (clientList.Count == 0)
            {
                System.Console.WriteLine("Nenhum cliente encontrado!");
                return;
            }

            foreach (Client client in clientList)
            {
                System.Console.WriteLine(client.ToString());
            }
        }

        public static void SearchClientById()
        {
            System.Console.Write("Qual o CPF do cliente a ser buscado? ");
            string cpf = Console.ReadLine();
            Client searchedClient = _clientDAO.SearchClientByCpf(cpf);

            if (String.IsNullOrEmpty(searchedClient.Cpf))
            {
                System.Console.WriteLine("Nenhum cliente encontrado!");
                return;
            }

            System.Console.WriteLine(searchedClient.ToString());
        }

        public static bool ConfirmAction()
        {
            bool answer = false;
            System.Console.Write("Digite 'S' caso você realmente deseja alterar/deletar esse cliente ");
            string inputString = Console.ReadLine();
            if (inputString.ToLower() == "s")
            {
                answer = true;
            }
            return answer;
        }
    }
}
