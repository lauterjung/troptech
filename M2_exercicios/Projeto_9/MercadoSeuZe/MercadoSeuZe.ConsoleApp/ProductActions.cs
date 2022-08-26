using System;
using System.Collections.Generic;
using MercadoSeuZe.ClassLib;

namespace MercadoSeuZe
{
    public static class ProductActions
    {
        private static string _userInput;
        private static ProductDAO _productDAO = new ProductDAO();

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("========= PRODUTOS =========");
            Console.WriteLine("[1] Cadastrar Produto");
            Console.WriteLine("[2] Editar Produto");
            Console.WriteLine("[3] Deletar Produto");
            Console.WriteLine("[4] Buscar todos os Produtos");
            Console.WriteLine("[5] Buscar Produto por descrição");
            Console.WriteLine("[6] Buscar Produto por identificador");
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

        public static void AddProduct()
        {
            try
            {
                System.Console.Write("Digite o nome: ");
                string name = Console.ReadLine();
                System.Console.Write("Digite a descricao: ");
                string description = Console.ReadLine();
                System.Console.Write("Digite a data de validade (AAAA-MM-DD): ");
                DateTime expirationDate = Convert.ToDateTime(Console.ReadLine());
                System.Console.Write("Digite o preço: ");
                double unitPrice = Convert.ToDouble(Console.ReadLine());
                System.Console.Write("Digite a unidade: ");
                string unit = Console.ReadLine();
                System.Console.Write("Digite a quantidade em estoque: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                Product newProduct = new Product(name, description, expirationDate, unitPrice, unit, quantity);

                _productDAO.AddProduct(newProduct);
                System.Console.WriteLine("Produto cadastrado com sucesso!");
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void UpdateProduct()
        {
            try
            {
                System.Console.Write("Qual o ID do produto a ser atualizado? ");
                string productId = Console.ReadLine();

                Product searchedProduct = _productDAO.SearchProductById(productId);
                if (searchedProduct.ProductId == 0)
                {
                    System.Console.WriteLine("Produto não encontrado! Pressione qualquer tecla para continuar...");
                    return;
                }

                System.Console.WriteLine(searchedProduct.ToString());

                if (ConfirmAction())
                {
                    System.Console.Write("Digite o nome: ");
                    string name = Console.ReadLine();
                    System.Console.Write("Digite a descricao: ");
                    string description = Console.ReadLine();
                    System.Console.Write("Digite a data de validade (AAAA-MM-DD): ");
                    DateTime expirationDate = Convert.ToDateTime(Console.ReadLine());
                    System.Console.Write("Digite o preço: ");
                    double unitPrice = Convert.ToDouble(Console.ReadLine());
                    System.Console.Write("Digite a unidade: ");
                    string unit = Console.ReadLine();
                    System.Console.Write("Digite a quantidade em estoque: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    Product modifiedProduct = new Product(name, description, expirationDate, unitPrice, unit, quantity);
                    modifiedProduct.ProductId = Convert.ToInt32(productId);

                    _productDAO.UpdateProduct(modifiedProduct);
                    System.Console.WriteLine("Produto alterado com sucesso!");
                }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void DeleteProduct()
        {
            try
            {
                System.Console.Write("Qual o ID do produto a ser deletado? ");
                string productId = Console.ReadLine();

                Product searchedProduct = _productDAO.SearchProductById(productId);
                if (searchedProduct.ProductId == 0)
                {
                    System.Console.WriteLine("Produto não encontrado! Pressione qualquer tecla para continuar...");
                    return;
                }

                System.Console.WriteLine(searchedProduct.ToString());

                if (ConfirmAction())
                {
                    _productDAO.DeleteProductById(searchedProduct);
                    System.Console.WriteLine("Produto deletado com sucesso!");
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Console.Clear();
                System.Console.WriteLine("O produto está em pedidos abertos! Primeiro remova os pedidos associados!");
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void SearchAllProducts()
        {
            List<Product> productList = new List<Product>();
            productList = _productDAO.SearchAllProducts();
            Console.Clear();

            if (productList.Count == 0)
            {
                System.Console.WriteLine("Nenhum produto encontrado!");
                return;
            }

            foreach (Product product in productList)
            {
                System.Console.WriteLine(product.ToString());
            }
        }

        public static void SearchProductsByDescription()
        {
            System.Console.Write("Qual a descrição do produto a ser buscado? ");
            string description = Console.ReadLine();

            List<Product> productList = _productDAO.SearchProductsByDescription(description);
            Console.Clear();

            if (productList.Count == 0)
            {
                System.Console.WriteLine("Nenhum produto encontrado!");
                return;
            }

            foreach (Product product in productList)
            {
                System.Console.WriteLine(product.ToString());
            }
        }

        public static void SearchProductsById()
        {
            try
            {
                System.Console.Write("Qual o ID do produto a ser buscado? ");
                string productId = Console.ReadLine();

                Product searchedProduct = _productDAO.SearchProductById(productId);
                Console.Clear();

                if (searchedProduct.ProductId == 0)
                {
                    System.Console.WriteLine("Nenhum produto encontrado!");
                    return;
                }

                System.Console.WriteLine(searchedProduct.ToString());
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static bool ConfirmAction()
        {
            bool answer = false;
            System.Console.Write("Digite 'S' caso você realmente deseja alterar/deletar esse produto ");
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
