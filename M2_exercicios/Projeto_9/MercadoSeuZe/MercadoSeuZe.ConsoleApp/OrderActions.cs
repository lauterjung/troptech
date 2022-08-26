using System;
using System.Collections.Generic;
using MercadoSeuZe.ClassLib;
using MercadoSeuZe.ClassLib.Exceptions;

namespace MercadoSeuZe
{
    public static class OrderActions
    {
        private static string _userInput;
        private static OrderDAO _orderDAO = new OrderDAO();
        private static ClientDAO _clientDAO = new ClientDAO();
        private static ProductDAO _productDAO = new ProductDAO();

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("========= PRODUTOS =========");
            Console.WriteLine("[1] Cadastrar Pedido");
            Console.WriteLine("[2] Editar Pedido");
            Console.WriteLine("[3] Deletar Pedido");
            Console.WriteLine("[4] Buscar todos os Pedidos");
            Console.WriteLine("[5] Buscar Pedido por identificador");
            Console.WriteLine("[6] Buscar Pedidos por CPF do cliente");
            Console.WriteLine("[7] Buscar Pedidos por ID do produto");
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
                    AddOrder();
                    break;
                case "2":
                    UpdateOrder();
                    break;
                case "3":
                    DeleteOrder();
                    break;
                case "4":
                    SearchAllOrders();
                    break;
                case "5":
                    SearchOrdersById();
                    break;
                case "6":
                    SearchOrdersByClientCpf();
                    break;
                case "7":
                    SearchOrdersByProductId();
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

        public static void AddOrder()
        {
            try
            {
                System.Console.Write("Digite o CPF do cliente: ");
                string clientId = Console.ReadLine();
                Client client = _clientDAO.SearchClientByCpf(clientId);

                if (String.IsNullOrEmpty(client.Cpf))
                {
                    System.Console.WriteLine("Cliente não encontrado! Use o menu de clientes para cadastrá-lo...");
                    return;
                }

                System.Console.Write("Digite o ID do produto: ");
                string productId = Console.ReadLine();
                Product orderProduct = _productDAO.SearchProductById(productId); ;

                if (orderProduct.ProductId == 0)
                {
                    System.Console.WriteLine("Produto não encontrado!");
                    Console.ReadLine();
                    return;
                }

                System.Console.Write("Digite a quantidade desejada: ");
                int productQuantity = Convert.ToInt32(Console.ReadLine());

                Order newOrder = new Order(orderProduct, productQuantity, client);
                _orderDAO.AddOrder(newOrder);
                System.Console.WriteLine("Pedido cadastrado com sucesso!");
            }

            catch (InsuficientQuantityException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (ZeroOrNegativeQuantityException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void UpdateOrder()
        {
            try
            {
                System.Console.Write("Qual o ID do pedido a ser atualizado? ");
                string orderId = Console.ReadLine();

                Order searchedOrder = _orderDAO.SearchOrderById(orderId);
                if (searchedOrder.OrderId == 0)
                {
                    System.Console.WriteLine("Pedido não encontrado! Pressione qualquer tecla para continuar...");
                    return;
                }

                System.Console.WriteLine(searchedOrder.ToString());

                if (ConfirmAction())
                {
                    System.Console.Write("Digite o CPF do cliente: ");
                    string clientId = Console.ReadLine();
                    Client client = _clientDAO.SearchClientByCpf(clientId);

                    if (String.IsNullOrEmpty(client.Cpf))
                    {
                        System.Console.WriteLine("Cliente não encontrado!");
                        return;
                    }

                    System.Console.Write("Digite o ID do produto: ");
                    string productId = Console.ReadLine();
                    Product orderProduct = _productDAO.SearchProductById(productId); ;

                    if (orderProduct.ProductId == 0)
                    {
                        System.Console.WriteLine("Produto não encontrado!");
                        return;
                    }

                    System.Console.Write("Digite a quantidade desejada: ");
                    int productQuantity = Convert.ToInt32(Console.ReadLine());

                    Order newOrder = new Order(orderProduct, productQuantity, client);
                    newOrder.OrderId = searchedOrder.OrderId;

                    _orderDAO.UpdateOrder(newOrder, searchedOrder);

                    System.Console.WriteLine("Pedido atualizado com sucesso!");
                }
            }
            catch (InsuficientQuantityException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (ZeroOrNegativeQuantityException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void DeleteOrder()
        {
            try
            {
                System.Console.Write("Qual o ID do pedido a ser deletado? ");
                string orderId = Console.ReadLine();

                Order searchedOrder = _orderDAO.SearchOrderById(orderId);
                if (searchedOrder.OrderId == 0)
                {
                    System.Console.WriteLine("Pedido não encontrado! Pressione qualquer tecla para continuar...");
                    return;
                }

                System.Console.WriteLine(searchedOrder.ToString());

                if (ConfirmAction())
                {
                    _orderDAO.DeleteOrderById(searchedOrder);

                    System.Console.WriteLine("Pedido deletado com sucesso!");
                }
            }
            catch (Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void SearchAllOrders()
        {
            List<Order> orderList = new List<Order>();
            orderList = _orderDAO.SearchAllOrders();
            Console.Clear();

            if (orderList.Count == 0)
            {
                System.Console.WriteLine("Nenhum pedido encontrado!");
                return;
            }

            foreach (Order order in orderList)
            {
                System.Console.WriteLine(order.ToString());
            }
        }

        public static void SearchOrdersById()
        {
            System.Console.Write("Qual o ID do produto a ser buscado? ");
            string orderId = Console.ReadLine();
            Order searchedOrder = _orderDAO.SearchOrderById(orderId);
            Console.Clear();

            if (searchedOrder.OrderId == 0)
            {
                System.Console.WriteLine("Nenhum pedido encontrado!");
                return;
            }
            System.Console.WriteLine(searchedOrder.ToString());
        }

        public static void SearchOrdersByClientCpf()
        {
            System.Console.Write("Qual o CPF do cliente do pedido a ser buscado? ");
            string cpf = Console.ReadLine();

            List<Order> orderList = _orderDAO.SearchOrdersByClientCpf(cpf);
            Console.Clear();

            if (orderList.Count == 0)
            {
                System.Console.WriteLine("Nenhum pedido encontrado!");
                return;
            }

            foreach (Order order in orderList)
            {
                System.Console.WriteLine(order.ToString());
            }
        }

        public static void SearchOrdersByProductId()
        {
            System.Console.Write("Qual o ID do produto do pedido a ser buscado? ");
            string productId = Console.ReadLine();

            List<Order> orderList = _orderDAO.SearchOrdersByProductId(productId);
            Console.Clear();

            if (orderList.Count == 0)
            {
                System.Console.WriteLine("Nenhum pedido encontrado!");
                return;
            }

            foreach (Order order in orderList)
            {
                System.Console.WriteLine(order.ToString());
            }
        }

        public static bool ConfirmAction()
        {
            bool answer = false;
            System.Console.Write("Digite 'S' caso você realmente deseja alterar/deletar esse pedido ");
            string inputString = Console.ReadLine();
            if (inputString.ToLower() == "s")
            {
                answer = true;
            }
            return answer;
        }

        public static void Run()
        {
            Menu();
        }
    }
}
