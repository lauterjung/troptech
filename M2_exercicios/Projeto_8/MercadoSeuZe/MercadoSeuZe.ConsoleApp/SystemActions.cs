using System;
using MercadoSeuZeDAO;

namespace MercadoSeuZe
{
    public static class SystemActions
    {
        private static string _userInput;
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("[1] Cadastrar Produto");
            Console.WriteLine("[2] Editar Produto");
            Console.WriteLine("[3] Deletar Produto");
            Console.WriteLine("[4] Buscar todos os Produtos");
            Console.WriteLine("[5] Buscar Produto por descrição");
            Console.WriteLine("[6] Buscar Produto por identificador");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("============================\n");
        }

        public static void AskForInput()
        {
            Console.Write("Digite a opção desejada: ");
            _userInput = Console.ReadLine();
        }

        public static void ChooseOption()
        {
            // Console.Clear();
            switch (_userInput)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    UpdateProduct();
                    break;
                case "3":
                    DeleteProduct();
                    break;
                case "4":
                    SearchAllProducts();
                    break;
                case "5":
                    SearchProductsByDescription();
                    break;
                case "6":
                    SearchProductsById();
                    break;
                case "0":
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Operação inválida. Pressione enter para continuar...");
                    Console.ReadKey();
                    break;
            }
        
            Console.ReadKey();
        }

        public static void AddProduct()
        {
            System.Console.Write("Digite o nome: ");
            string product = Console.ReadLine();
            System.Console.Write("Digite a descricao: ");
            string description = Console.ReadLine();
            System.Console.Write("Digite a data de validade (AAAA-MM-DD): ");
            string expirationDate = Console.ReadLine();
            System.Console.Write("Digite o preço: ");
            string price = Console.ReadLine();
            System.Console.Write("Digite a unidade: ");
            string unit = Console.ReadLine();
            System.Console.Write("Digite a quantidade em estoque: ");
            string stockQuantity = Console.ReadLine();

            ProductDAO.InsertIntoProducts(product, description, expirationDate, price, unit, stockQuantity);
            System.Console.WriteLine("Produto cadastrado com sucesso!");
        }

        public static void UpdateProduct()
        {
            System.Console.Write("Qual o ID do produto a ser atualizado? ");
            string product_id = Console.ReadLine();

            if (ConfirmAction(product_id))
            {
                System.Console.Write("Digite o nome: ");
                string product = Console.ReadLine();
                System.Console.Write("Digite a descricao: ");
                string description = Console.ReadLine();
                System.Console.Write("Digite a data de validade (AAAA-MM-DD): ");
                string expirationDate = Console.ReadLine();
                System.Console.Write("Digite o preço: ");
                string price = Console.ReadLine();
                System.Console.Write("Digite a unidade: ");
                string unit = Console.ReadLine();
                System.Console.Write("Digite a quantidade em estoque: ");
                string stockQuantity = Console.ReadLine();
                ProductDAO.UpdateProducts(product_id, product, description, expirationDate, price, unit, stockQuantity);
                System.Console.WriteLine("Produto alterado com sucesso!");
            }
        }

        public static void DeleteProduct()
        {
            System.Console.Write("Qual o ID do produto a ser deletado? ");
            string product_id = Console.ReadLine();

            if (ConfirmAction(product_id))
            {
                ProductDAO.DeleteFromProductsById(product_id);
                System.Console.WriteLine("Produto deletado com sucesso!");
            }
        }

        public static void SearchAllProducts()
        {
            ProductDAO.ViewAllProducts();
        }

        public static void SearchProductsByDescription()
        {
            System.Console.Write("Qual a descrição do produto a ser buscado? ");
            string description = Console.ReadLine();

            ProductDAO.ViewProductByDescription(description);
        }

        public static void SearchProductsById()
        {
            System.Console.Write("Qual o ID do produto a ser buscado? ");
            string product_id = Console.ReadLine();

            ProductDAO.ViewProductById(product_id);
        }

        public static bool ConfirmAction(string product_id)
        {
            bool answer = false;
            ProductDAO.ViewProductById(product_id);
            System.Console.Write("Digite 'S' caso você realmente deseja alterar/deletar esse produto ");
            string inputString = Console.ReadLine();
            if (inputString == "S")
            {
                answer = true;
            }

            return answer;
        }

        public static void RunProgram()
        {
            while (true)
            {
                Menu();
                AskForInput();
                ChooseOption();
            }
        }
    }
}
